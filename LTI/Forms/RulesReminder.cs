using System;
using System.Windows.Forms;
using LTI.Models;
using LTI.Data;
using System.Linq;

namespace LTI.Forms
{
    public partial class RulesReminder : Form
    {
        bool uiClosing = false;
        string username;
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public RulesReminder(string _username)
        {
            InitializeComponent();
            this.username = _username;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!uiClosing)
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
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uiClosing = true;
            this.Close();
        }

        private void RulesReminder_Load(object sender, EventArgs e)
        {
            Myconfiguration RulesReminderText = _context.Configurations.Where(c => c.Key.ToUpper().Equals("RULES_REMINDER_TEXT")).FirstOrDefault();
            userNameLabel.Text = username;
            DisclamerLabel.Text = RulesReminderText.Value;
        }
    }
}
