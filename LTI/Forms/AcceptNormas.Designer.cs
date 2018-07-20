namespace LTI.Forms
{
    partial class AcceptNormas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SwitchButton = new System.Windows.Forms.Button();
            this.Terms = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.Disclaimer = new System.Windows.Forms.CheckBox();
            this.optionalTeachers = new System.Windows.Forms.ComboBox();
            this.optionalSubjects = new System.Windows.Forms.ComboBox();
            this.optionalSection = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LoadingAppIcon = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingAppIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Controls.Add(this.LoadingAppIcon);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1057, 45);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(220, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(650, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "NORMAS DEL LABORATORIO DE TECNOLOGIA DE LA INFORMACION";
            // 
            // SwitchButton
            // 
            this.SwitchButton.BackColor = System.Drawing.Color.Red;
            this.SwitchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SwitchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SwitchButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SwitchButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.SwitchButton.Location = new System.Drawing.Point(14, 75);
            this.SwitchButton.Name = "SwitchButton";
            this.SwitchButton.Size = new System.Drawing.Size(37, 26);
            this.SwitchButton.TabIndex = 2;
            this.SwitchButton.Text = "+";
            this.SwitchButton.UseVisualStyleBackColor = false;
            this.SwitchButton.Click += new System.EventHandler(this.SwitchButton_Click);
            // 
            // Terms
            // 
            this.Terms.BackColor = System.Drawing.Color.White;
            this.Terms.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Terms.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Terms.HideSelection = false;
            this.Terms.Location = new System.Drawing.Point(12, 106);
            this.Terms.Name = "Terms";
            this.Terms.ReadOnly = true;
            this.Terms.Size = new System.Drawing.Size(1033, 494);
            this.Terms.TabIndex = 1;
            this.Terms.Text = "";
            this.Terms.TextChanged += new System.EventHandler(this.Terms_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.Disclaimer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 606);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1057, 105);
            this.panel2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkRed;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(13, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1032, 53);
            this.button1.TabIndex = 1;
            this.button1.Text = "ACEPTO";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Disclaimer
            // 
            this.Disclaimer.AutoSize = true;
            this.Disclaimer.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Disclaimer.ForeColor = System.Drawing.Color.DarkRed;
            this.Disclaimer.Location = new System.Drawing.Point(16, 7);
            this.Disclaimer.Name = "Disclaimer";
            this.Disclaimer.Size = new System.Drawing.Size(924, 28);
            this.Disclaimer.TabIndex = 0;
            this.Disclaimer.Text = "Estoy de acuerdo: el incumplimiento a cualquiera de estas normas puede acarrear s" +
    "ansiones académicas.";
            this.Disclaimer.UseVisualStyleBackColor = true;
            this.Disclaimer.CheckedChanged += new System.EventHandler(this.Disclaimer_CheckedChanged);
            // 
            // optionalTeachers
            // 
            this.optionalTeachers.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionalTeachers.FormattingEnabled = true;
            this.optionalTeachers.Location = new System.Drawing.Point(68, 75);
            this.optionalTeachers.Name = "optionalTeachers";
            this.optionalTeachers.Size = new System.Drawing.Size(223, 26);
            this.optionalTeachers.TabIndex = 3;
            // 
            // optionalSubjects
            // 
            this.optionalSubjects.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionalSubjects.FormattingEnabled = true;
            this.optionalSubjects.Location = new System.Drawing.Point(753, 74);
            this.optionalSubjects.Name = "optionalSubjects";
            this.optionalSubjects.Size = new System.Drawing.Size(242, 26);
            this.optionalSubjects.TabIndex = 4;
            // 
            // optionalSection
            // 
            this.optionalSection.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionalSection.Location = new System.Drawing.Point(469, 77);
            this.optionalSection.Name = "optionalSection";
            this.optionalSection.Size = new System.Drawing.Size(100, 23);
            this.optionalSection.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(463, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sección (opcional)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(750, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Asignatura (opcional)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(65, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Profesor/a (opcional)";
            // 
            // LoadingAppIcon
            // 
            this.LoadingAppIcon.Image = global::LTI.Properties.Resources.loading_app;
            this.LoadingAppIcon.Location = new System.Drawing.Point(1006, 4);
            this.LoadingAppIcon.Name = "LoadingAppIcon";
            this.LoadingAppIcon.Size = new System.Drawing.Size(37, 37);
            this.LoadingAppIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LoadingAppIcon.TabIndex = 2;
            this.LoadingAppIcon.TabStop = false;
            // 
            // AcceptNormas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1057, 711);
            this.ControlBox = false;
            this.Controls.Add(this.SwitchButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.optionalSection);
            this.Controls.Add(this.optionalSubjects);
            this.Controls.Add(this.optionalTeachers);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Terms);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AcceptNormas";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AcceptNormas";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AcceptNormas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingAppIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox Terms;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox Disclaimer;
        private System.Windows.Forms.ComboBox optionalTeachers;
        private System.Windows.Forms.ComboBox optionalSubjects;
        private System.Windows.Forms.TextBox optionalSection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SwitchButton;
        private System.Windows.Forms.PictureBox LoadingAppIcon;
    }
}