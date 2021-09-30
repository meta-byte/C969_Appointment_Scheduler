
namespace AndrewHowardSchedulerApp
{
    partial class Reports
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
            this.rptTextBox = new System.Windows.Forms.TextBox();
            this.rptAppointmentTypesRadio = new System.Windows.Forms.RadioButton();
            this.rptConsultantScheduleRadio = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.exitButton = new System.Windows.Forms.Button();
            this.appointmentsButton = new System.Windows.Forms.Button();
            this.customersButton = new System.Windows.Forms.Button();
            this.rptUserComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // rptTextBox
            // 
            this.rptTextBox.Location = new System.Drawing.Point(216, 124);
            this.rptTextBox.Multiline = true;
            this.rptTextBox.Name = "rptTextBox";
            this.rptTextBox.Size = new System.Drawing.Size(740, 706);
            this.rptTextBox.TabIndex = 0;
            // 
            // rptAppointmentTypesRadio
            // 
            this.rptAppointmentTypesRadio.AutoSize = true;
            this.rptAppointmentTypesRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rptAppointmentTypesRadio.Location = new System.Drawing.Point(216, 98);
            this.rptAppointmentTypesRadio.Name = "rptAppointmentTypesRadio";
            this.rptAppointmentTypesRadio.Size = new System.Drawing.Size(189, 20);
            this.rptAppointmentTypesRadio.TabIndex = 1;
            this.rptAppointmentTypesRadio.TabStop = true;
            this.rptAppointmentTypesRadio.Text = "Appointment Types / Month";
            this.rptAppointmentTypesRadio.UseVisualStyleBackColor = true;
            this.rptAppointmentTypesRadio.CheckedChanged += new System.EventHandler(this.rptAppointmentTypesRadio_CheckedChanged);
            // 
            // rptConsultantScheduleRadio
            // 
            this.rptConsultantScheduleRadio.AutoSize = true;
            this.rptConsultantScheduleRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rptConsultantScheduleRadio.Location = new System.Drawing.Point(216, 72);
            this.rptConsultantScheduleRadio.Name = "rptConsultantScheduleRadio";
            this.rptConsultantScheduleRadio.Size = new System.Drawing.Size(166, 20);
            this.rptConsultantScheduleRadio.TabIndex = 2;
            this.rptConsultantScheduleRadio.TabStop = true;
            this.rptConsultantScheduleRadio.Text = "Schedule by Consultant";
            this.rptConsultantScheduleRadio.UseVisualStyleBackColor = true;
            this.rptConsultantScheduleRadio.CheckedChanged += new System.EventHandler(this.rptConsultantScheduleRadio_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.radioButton3.Location = new System.Drawing.Point(216, 46);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(101, 20);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.exitButton.Location = new System.Drawing.Point(12, 792);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(175, 38);
            this.exitButton.TabIndex = 60;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // appointmentsButton
            // 
            this.appointmentsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.appointmentsButton.Location = new System.Drawing.Point(12, 124);
            this.appointmentsButton.Name = "appointmentsButton";
            this.appointmentsButton.Size = new System.Drawing.Size(175, 38);
            this.appointmentsButton.TabIndex = 59;
            this.appointmentsButton.Text = "Appointments";
            this.appointmentsButton.UseVisualStyleBackColor = true;
            this.appointmentsButton.Click += new System.EventHandler(this.appointmentsButton_Click);
            // 
            // customersButton
            // 
            this.customersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.customersButton.Location = new System.Drawing.Point(12, 168);
            this.customersButton.Name = "customersButton";
            this.customersButton.Size = new System.Drawing.Size(175, 38);
            this.customersButton.TabIndex = 58;
            this.customersButton.Text = "Customers";
            this.customersButton.UseVisualStyleBackColor = true;
            this.customersButton.Click += new System.EventHandler(this.customersButton_Click);
            // 
            // rptUserComboBox
            // 
            this.rptUserComboBox.FormattingEnabled = true;
            this.rptUserComboBox.Location = new System.Drawing.Point(407, 71);
            this.rptUserComboBox.Name = "rptUserComboBox";
            this.rptUserComboBox.Size = new System.Drawing.Size(113, 21);
            this.rptUserComboBox.TabIndex = 61;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 861);
            this.Controls.Add(this.rptUserComboBox);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.appointmentsButton);
            this.Controls.Add(this.customersButton);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.rptConsultantScheduleRadio);
            this.Controls.Add(this.rptAppointmentTypesRadio);
            this.Controls.Add(this.rptTextBox);
            this.Name = "Reports";
            this.Text = "Reports";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rptAppointmentTypesRadio;
        private System.Windows.Forms.RadioButton rptConsultantScheduleRadio;
        private System.Windows.Forms.RadioButton radioButton3;
        public System.Windows.Forms.Button exitButton;
        public System.Windows.Forms.Button appointmentsButton;
        public System.Windows.Forms.Button customersButton;
        public System.Windows.Forms.TextBox rptTextBox;
        public System.Windows.Forms.ComboBox rptUserComboBox;
    }
}