using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LTI.Forms;
using System.Diagnostics;
using System.Net.Http;
using System.DirectoryServices;
using System.ComponentModel;
using LTI.Data;
using LTI.Models;

namespace LTI
{
    static class Program
    {
        private static ApplicationDbContext _context = new ApplicationDbContext();
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Myconfiguration _surveyUrl = _context.Configurations.Where(c => c.Key.ToLower().Equals("survey_url")).FirstOrDefault();
            Myconfiguration _surveyDisplayMode = _context.Configurations.Where(c => c.Key.ToLower().Equals("fullscreen")).FirstOrDefault();

            string SurveyUrl = _surveyUrl.Value;

            bool DisplaySurveyFullScreenMode = false; //_surveyDisplayMode.Value

            if (_surveyDisplayMode.Value.ToLower().Equals("true"))
            {
                DisplaySurveyFullScreenMode = true;
            }

            String info = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            String displayName = System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName;

            int charLocation = info.IndexOf("\\");
            string loginName = info.Substring(charLocation + 1);
            string domain = info.Substring(0, charLocation);
            string userDisplayName = displayName;

            bool isStudent = false;
            if (domain.ToUpper().Equals("INTEC"))
            {
                isStudent = true;
            }

            /**
             * Determine if there is an active trimestre. If there isnt show "Rules Reminder",
             * otherwise verify if the user exists in the appropiate table.
             * */
            var trimestres = _context.Trimestres.Select(t => t);
            Trimestre trimestres_actual = null;
            foreach (Trimestre t in trimestres)
            {
                if (t.Active == 1)
                {
                    trimestres_actual = t;
                    break;
                }
            }

            //If it's Survey Time
            Myconfiguration configs = _context.Configurations.Where(c => c.Key.ToLower().Equals("survey")).FirstOrDefault();
            bool isSurveyTime = false;
            if (configs.Value.ToLower().Equals("true"))
            {
                //Show survey - Then verify if we need to show the normas
                isSurveyTime = true;
                //ShowSurvey(SurveyUrl, DisplaySurveyFullScreenMode);
            }

            //Verify if Show Normas
            Student student = null;
            Teacher teacher = null;
            if (trimestres_actual != null)
            {
                if (isStudent) //look in Students table
                {
                    
                    try
                    {
                        //Get user
                        student = _context.Students.Where(s => s.LoginName.ToLower().Equals(loginName.ToLower())).FirstOrDefault();

                        if (student != null)
                        {
                            //If the user in the table have signed in the trimestre_actual tirmestre dates range.
                            if (student.RegisteredDate >= trimestres_actual.StartDate && student.RegisteredDate <= trimestres_actual.EndDate)
                            {
                                //Show "Rules Reminder"
                                Application.Run(new RulesReminder(displayName));
                            }
                            else
                            {
                                //Move user to History

                                //  1. Create HistoryStudent object
                                HistoryStudent Hstudent = new HistoryStudent()
                                {
                                    LoginName = student.LoginName,
                                    DisplayName = student.DisplayName,
                                    RegisteredDate = student.RegisteredDate,
                                    Domain = student.Domain,
                                    ComputerName = student.ComputerName,
                                    SubjectName = student.SubjectName,
                                    SubjectSection = student.SubjectSection,
                                    HasFilledSurvey = student.HasFilledSurvey
                                };
                                _context.HistoryStudents.Add(Hstudent);
                                _context.SaveChanges();

                                //  2. Delete student form Table Students
                                _context.Students.Remove(student);
                                _context.SaveChanges();

                                //Show "Main Form"
                                Application.Run(new AcceptNormas(isStudent, info, displayName));
                            }
                        }
                        else
                        {
                            //Show main form
                            Application.Run(new AcceptNormas(isStudent, info, displayName));
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine("Error: " + exp.Message);
                        Application.Run(new RulesReminder(displayName));
                        Application.Exit();
                    }
                }
                else //look in teachers table
                {
                    
                    try
                    {
                        //Get user
                        teacher = _context.Teachers.Where(t => t.LoginName.ToLower().Equals(loginName.ToLower())).FirstOrDefault();

                        if (teacher != null)
                        {
                            //If the user in the table have signed in the trimestre_actual tirmestre dates range.
                            if (teacher.RegisteredDate >= trimestres_actual.StartDate && teacher.RegisteredDate <= trimestres_actual.EndDate)
                            {
                                //Show "Rules Reminder"
                                Application.Run(new RulesReminder(displayName));
                            }
                            else
                            {
                                //Move user to History

                                //  1. Create HistoryStudent object
                                HistoryTeacher Hteacher = new HistoryTeacher()
                                {
                                    LoginName = teacher.LoginName,
                                    DisplayName = teacher.DisplayName,
                                    RegisteredDate = teacher.RegisteredDate,
                                    Domain = teacher.Domain,
                                    ComputerName = teacher.ComputerName,
                                    HasFilledSurvey = teacher.HasFilledSurvey
                                };
                                _context.HistoryTeachers.Add(Hteacher);
                                _context.SaveChanges();

                                //  2. Delete student form Table Students
                                _context.Teachers.Remove(teacher);
                                _context.SaveChanges();

                                //Show "Main Form"
                                Application.Run(new AcceptNormas(isStudent, info, displayName));
                            }
                        }
                        else
                        {
                            //Show main form
                            Application.Run(new AcceptNormas(isStudent, info, displayName));
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine("Error: " + exp.Message);
                        Application.Run(new RulesReminder(displayName));
                        Application.Exit();
                    }
                }
            }

            //Verify if Show Survey
            if (isSurveyTime)
            {
                //Get users
                student = _context.Students.Where(s => s.LoginName.ToLower().Equals(loginName.ToLower())).FirstOrDefault();
                teacher = _context.Teachers.Where(t => t.LoginName.ToLower().Equals(loginName.ToLower())).FirstOrDefault();

                if (IsIntecStudent(loginName)) // Verify if student's id is numeric -
                {
                    if (student != null && !domain.Equals("INTECADM"))
                    {
                        if (!student.HasFilledSurvey)
                        {
                            ShowSurvey(SurveyUrl, DisplaySurveyFullScreenMode);
                            student.HasFilledSurvey = true;
                            _context.SaveChanges();
                        }
                    }
                }
            }
        }

        private static bool IsIntecStudent(string _id)
        {
            long id = 0;
            try
            {
                id = Int64.Parse(_id);
                return true;
            }
            catch (Exception exp) {
                Console.WriteLine(exp.Message);
                Console.WriteLine("User without numeric id: Not INTEC active Student.");
            }
            return false;

        }

        private static void ShowSurvey(string _surveyUrl, bool _isFullScreen)
        {
            string original_url = _surveyUrl;
            bool isFullScreen = _isFullScreen;

            ProcessStartInfo startInfo = new ProcessStartInfo(@"C:\Program Files\Internet Explorer\iexplore.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            if (isFullScreen)
            {
                startInfo.Arguments = @" -k " + original_url;
            }
            else
            {
                startInfo.Arguments = original_url;
            }

            var process = Process.Start(startInfo);

            bool loop = true;
            while (loop)
            {

                foreach (SHDocVw.InternetExplorer iexplorer in new SHDocVw.ShellWindowsClass())
                {
                    if (iexplorer.LocationURL.Contains("formResponse"))
                    {
                        loop = false;
                        iexplorer.Navigate(@"https://www.intec.edu.do");
                        process.Kill();
                    }
                    if (process.HasExited)
                    {
                        loop = false;
                    }
                }
            }
            startInfo.Arguments = @"https://www.intec.edu.do";
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            process = Process.Start(startInfo);
        }
    }
}
