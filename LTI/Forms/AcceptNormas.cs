using LTI.Data;
using LTI.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LTI.Forms
{
    public partial class AcceptNormas : Form
    {
        private static string ConfirmationBoxUnChecked = "Debes hacer clic en la casilla de verificación para confirmar estar de acuerdo con las normas de este laboratorio.";
        private bool isStudent = false;
        String info;
        String displayName;
        String loginName;
        String domain;
        String computerName;
        private bool dataLoaded = false;
        String error = "";
        DateTime registeredDate; 

        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public AcceptNormas(bool _isStudent, String _info, String _displayName)
        {

            InitializeComponent();
            info = _info;
            displayName = _displayName;
            isStudent = _isStudent;
            int charLocation = info.IndexOf("\\");
            loginName = info.Substring(charLocation + 1);
            domain = info.Substring(0, charLocation);
            computerName = Environment.MachineName.ToString();
            registeredDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    //MessageBox.Show("Debes aceptar las normas de uso de este laboratorio para continuar utilizando este equipo.", "Laboratorio de Tecnología de la Información");
                    e.Cancel = true;
                    break;
            }
            base.OnFormClosing(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (Disclaimer.Checked)
            {
                if (Dologic())
                {
                    MessageBox.Show("¡Gracias por su tiempo y colaboración!");
                }
                else
                {
                    MessageBox.Show("Lo sentimos, inténtelo de nuevo la próxima vez que inicie sesión.");
                    MessageBox.Show(error);
                }
                Application.Exit();
            }
            else
            {
                MessageBox.Show(ConfirmationBoxUnChecked, "LTI");
                button1.Enabled = true;
            }
            
        }
        private bool Dologic()
        {
            Student student = null;
            Teacher teacher = null;
            bool result = true;

            if (isStudent)
            {
                try
                {
                    student = new Student()
                    {
                        DisplayName = displayName,
                        LoginName = loginName,
                        RegisteredDate = registeredDate,
                        Domain = domain,
                        ComputerName = computerName,
                        HasFilledSurvey = false
                    };
                    if (SwitchButton.Text.Equals("-"))
                    {
                        int asig_code = Int32.Parse(optionalSubjects.SelectedValue.ToString());
                        int teach_code = Int32.Parse(optionalTeachers.SelectedValue.ToString());

                        var asig = _context.Subjects.Where(s => s.SubjectID == asig_code).FirstOrDefault();
                        var teach = _context.Teachers.Where(t => t.TeacherID == teach_code).FirstOrDefault();

                        student.SubjectSection = optionalSection.Text;
                        student.SubjectName = asig.SubjectName;
                        student.Teacher = teach;
                        student.SubjectCode = asig.SubjectCode;
                    }
                    _context.Students.Add(student);
                    _context.SaveChanges();

                }
                catch(Exception exp)
                {
                    Console.WriteLine(exp.Message);
                    result = false;
                    error = exp.Message;
                }
            }
            else
            {
                try
                {
                    teacher = new Teacher()
                    {
                        DisplayName = displayName,
                        LoginName = loginName,
                        RegisteredDate = registeredDate,
                        Domain = domain,
                        ComputerName = computerName,
                        HasFilledSurvey = false
                    };
                    _context.Teachers.Add(teacher);
                    _context.SaveChanges();
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                    result = false;
                    error = exp.Message;
                }
            }
            return result;
        }

        private void AcceptNormas_Load(object sender, EventArgs e)
        {
            var normas = _context.Normas.Select(n => n);
            int counter = 1;
            foreach(Norma norma in normas)
            {
                Terms.AppendText(counter.ToString() +") "+ norma.NormaContent +"\n\n");
                counter++;
            }
            optionalSubjects.Enabled = false;
            optionalTeachers.Enabled = false;
            optionalSection.Enabled = false;

            Terms.ScrollToCaret();
            Terms.AutoWordSelection = false;
          
            Terms.HideSelection = true;
            Terms.Capture = false;

        }

        private void SwitchButton_Click(object sender, EventArgs e)
        {
            if (!dataLoaded)
            {
                //Load combobox information
                // this.subjectsTableAdapter.Fill(this.lTISignsDataSet1.Subjects);
                // this.teachersTableAdapter.Fill(this.lTISignsDataSet.Teachers);
                fillLists();
                dataLoaded = true;
            }

            if (SwitchButton.Text.Equals("+"))
            {
                //Enable TextBoxex
                optionalSubjects.Enabled = true;
                optionalSection.Enabled = true;
                optionalTeachers.Enabled = true;

                optionalSection.Text = "01";

                SwitchButton.Text = "-";

                if(optionalSubjects.Items.Count > 0)
                {
                    optionalSubjects.SelectedIndex = 0;
                }
                 if(optionalTeachers.Items.Count > 0)
                {
                    optionalTeachers.SelectedIndex = 0;
                }

                //Refresh Teachers List
                fillLists();

            }
            else
            {
                //Disable Textboxex
               optionalSubjects.Enabled = false;
               optionalSection.Enabled = false;
               optionalTeachers.Enabled = false;

               SwitchButton.Text = "+";

               optionalSubjects.SelectedIndex = -1;
               optionalTeachers.SelectedIndex = -1;

            }
        }

        private void fillLists()
        {
            var asigs = _context.Subjects.OrderBy(s => s.SubjectName).Select(s => s);
            var teachs = _context.Teachers.OrderBy(t => t.DisplayName).Select(t => t);

            optionalSubjects.DisplayMember = "SubjectName";
            optionalSubjects.ValueMember = "SubjectID";
            optionalSubjects.DataSource = asigs.ToArray();

            optionalTeachers.DisplayMember = "DisplayName";
            optionalTeachers.ValueMember = "TeacherID";
            optionalTeachers.DataSource = teachs.ToArray();

        }
    }
}
