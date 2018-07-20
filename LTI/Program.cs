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

            string TRUE = "TRUE";
            string FALSE = "FALSE";
            string ACCEPT_TERMS = "ACCEPT_TERMS";
            string SURVEY_TIME_STUDENT = "SURVEY_TIME_STUDENT";
            string SURVEY_TIME_TEACHER = "SURVEY_TIME_TEACHER";
            string SURVEY_URL_STUDENT = "SURVEY_URL_STUDENT";
            string FULLSCREEN_STUDENT = "FULLSCREEN_STUDENT";
            string SURVEY_URL_TEACHER = "SURVEY_URL_TEACHER";
            string FULLSCREEN_TEACHER = "FULLSCREEN_TEACHER";
            string SHOW_RULES_REMINDER = "SHOW_RULES_REMINDER";

            var configs = _context.Configurations.Select(c => c);
            Myconfiguration AcceptTermsCF = configs.Where(c => c.Key.ToUpper().Equals(ACCEPT_TERMS)).FirstOrDefault();
            Myconfiguration ShowRulesReminderCF = configs.Where(c => c.Key.ToUpper().Equals(SHOW_RULES_REMINDER)).FirstOrDefault();
            Myconfiguration StudentSurveyTimeCF = configs.Where(c => c.Key.ToUpper().Equals(SURVEY_TIME_STUDENT)).FirstOrDefault();
            Myconfiguration TeacherSurveyTimeCF = configs.Where(c => c.Key.ToUpper().Equals(SURVEY_TIME_TEACHER)).FirstOrDefault();
            Myconfiguration StudentFullscreenCF = configs.Where(c => c.Key.ToUpper().Equals(FULLSCREEN_STUDENT)).FirstOrDefault();
            Myconfiguration TeacherFullscreenCF = configs.Where(c => c.Key.ToUpper().Equals(FULLSCREEN_TEACHER)).FirstOrDefault();
            Myconfiguration StudentLinkCF = configs.Where(c => c.Key.ToUpper().Equals(SURVEY_URL_STUDENT)).FirstOrDefault();
            Myconfiguration TeacherLinkCF = configs.Where(c => c.Key.ToUpper().Equals(SURVEY_URL_TEACHER)).FirstOrDefault();

            // Myconfiguration _surveyUrl = _context.Configurations.Where(c => c.Key.ToLower().Equals("survey_url")).FirstOrDefault();
            // Myconfiguration _surveyDisplayMode = _context.Configurations.Where(c => c.Key.ToLower().Equals("fullscreen")).FirstOrDefault();

            string StudentSurveyUrl = StudentLinkCF.Value;
            string TeacherSurveyUrl = TeacherLinkCF.Value;
            bool StudentSurveyFullscreen = false;
            bool TeacherSurveyFullscreen = false;
            bool isSurveyTimeStudent = false;
            bool isSurveyTimeTeacher = false;
            bool showRulesReminder = false;
            bool showAcceptTermsForm = false;

            if (StudentFullscreenCF.Value.Equals(TRUE))
            {
                StudentSurveyFullscreen = true;
            }
            if (TeacherFullscreenCF.Value.Equals(TRUE))
            {
                TeacherSurveyFullscreen = true;
            }
            if (StudentSurveyTimeCF.Value.Equals(TRUE))
            {
                isSurveyTimeStudent = true;
            }
            if (TeacherSurveyTimeCF.Value.Equals(TRUE))
            {
                isSurveyTimeTeacher = true;
            }
            if (AcceptTermsCF.Value.Equals(TRUE))
            {
                showAcceptTermsForm = true;
            }
            if (ShowRulesReminderCF.Value.Equals(TRUE))
            {
                showRulesReminder = true;
            }


            String info = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            String displayName = System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName;

            

            int charLocation = info.IndexOf("\\");
            string loginName = info.Substring(charLocation + 1);
            string domain = info.Substring(0, charLocation);
            string userDisplayName = displayName;

            if (!IsNotRegisteredEmployee(loginName))
            {
                return;
            }

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

            //Verify if Show Normas
            Student student = null;
            Teacher teacher = null;
            if (showAcceptTermsForm)
            {
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
                                    if (showRulesReminder)
                                    {
                                        //Show "Rules Reminder"
                                        Application.Run(new RulesReminder(displayName));
                                    }
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
                                DateTime today = DateTime.Now;
                                if(today >= trimestres_actual.StartDate && today <= trimestres_actual.EndDate)
                                {
                                    Application.Run(new AcceptNormas(isStudent, info, displayName));
                                }
                            }
                        }
                        catch (Exception exp)
                        {
                            Console.WriteLine("Error: " + exp.Message);
                            if (showRulesReminder)
                            {
                                //Show "Rules Reminder"
                                Application.Run(new RulesReminder(displayName));
                            }
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
                                    if (showRulesReminder)
                                    {
                                        //Show "Rules Reminder"
                                        Application.Run(new RulesReminder(displayName));
                                    }
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
                                DateTime today = DateTime.Now;
                                if (today >= trimestres_actual.StartDate && today <= trimestres_actual.EndDate)
                                {
                                    Application.Run(new AcceptNormas(isStudent, info, displayName));
                                }
                            }
                        }
                        catch (Exception exp)
                        {
                            Console.WriteLine("Error: " + exp.Message);
                            if (showRulesReminder)
                            {
                                //Show "Rules Reminder"
                                Application.Run(new RulesReminder(displayName));
                            }
                            Application.Exit();
                        }
                    }
                }
            }

            //Verify if Show Survey
            if (isSurveyTimeStudent)
            {
                //Get user
                student = _context.Students.Where(s => s.LoginName.ToLower().Equals(loginName.ToLower())).FirstOrDefault();

                if (IsIntecStudent(loginName)) // Verify if student's id is numeric -
                {
                    if (student != null && !domain.Equals("INTECADM"))
                    {
                        while (!student.HasFilledSurvey)
                        {
                            bool s = ShowSurvey(StudentSurveyUrl, StudentSurveyFullscreen);
                            if (s)
                            {
                                student.HasFilledSurvey = true;
                                _context.SaveChanges();
                                
                            }
                            
                        }
                     //   MessageBox.Show("¡Gracias! Ya puedes continuar utilizando este equipo.");
                    }
                }
            }
            if (isSurveyTimeTeacher)
            {
                //Get user
                teacher = _context.Teachers.Where(t => t.LoginName.ToLower().Equals(loginName.ToLower())).FirstOrDefault();
                if (IsNotRegisteredEmployee(loginName))
                {
                    if (teacher != null && domain.Equals("INTECADM"))
                    {
                        while (!teacher.HasFilledSurvey)
                        {
                            bool s = ShowSurvey(TeacherSurveyUrl, TeacherSurveyFullscreen);
                            if (s)
                            {
                                teacher.HasFilledSurvey = true;
                                _context.SaveChanges();
                            }

                        }
                       // MessageBox.Show("¡Gracias! Ya puedes continuar utilizando este equipo.");
                    }
                }
            }
        }

        private static bool IsNotRegisteredEmployee(string loginName)
        {
            var listado = _context.Admins.Select(a => a);
            foreach(Admin a in listado)
            {
                Teacher te = _context.Teachers.Where(t => t.TeacherID == a.TeacherID).FirstOrDefault();
                if(te != null)
                {
                    if (loginName.Equals(te.LoginName))
                    {
                        return false;
                    }
                }
                
            }
            return true;

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

        private static bool ShowSurvey(string _surveyUrl, bool _isFullScreen)
        {
            string original_url = _surveyUrl;
            bool isFullScreen = _isFullScreen;
            bool result = true;
            bool normalStatus = false;

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
                        normalStatus = true;
                    }
                }
                if (process.HasExited)
                {
                    loop = false;
                    if (!normalStatus)
                    {
                        result = false;
                    }
                    
                }
                foreach(var current_process in Process.GetProcesses())
                {
                    //Do not allow navigation in most use browser while survey is showing!
                    if (current_process.ProcessName.ToLower().Equals("chrome") || current_process.ProcessName.ToLower().Equals("microsoftedge") || current_process.ProcessName.ToLower().Equals("microsoftedgecp") || current_process.ProcessName.ToLower().Equals("firefox") || current_process.ProcessName.ToLower().Equals("iexplore"))
                    {
                        if (current_process.Id != process.Id)
                        {
                            try
                            {
                                current_process.CloseMainWindow();
                                //MessageBox.Show("Para navegar en internet primero debes de llenar la encuesta de satisfacción.");
                            }
                            catch (Exception exp)
                            {
                                Console.WriteLine("Error, couldn't close browser: " + exp.Message);
                            }
                            //MessageBox.Show("Por favor, llene la encuesta.!");
                        }
                    }
                }
            }
            if (result)
            {
                startInfo.Arguments = @"-extoff https://www.intec.edu.do";
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                process = Process.Start(startInfo);
            }
            return result;
        }
    }
}
