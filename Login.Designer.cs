
namespace AndrewHowardSchedulerApp
{
    partial class login
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
            this.loginHeaderLabel = new System.Windows.Forms.Label();
            this.loginWelcomeLabel = new System.Windows.Forms.Label();
            this.loginUserLabel = new System.Windows.Forms.Label();
            this.loginPasswordLabel = new System.Windows.Forms.Label();
            this.loginUserField = new System.Windows.Forms.TextBox();
            this.loginPasswordField = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginHeaderLabel
            // 
            this.loginHeaderLabel.AutoSize = true;
            this.loginHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginHeaderLabel.Location = new System.Drawing.Point(88, 49);
            this.loginHeaderLabel.Name = "loginHeaderLabel";
            this.loginHeaderLabel.Size = new System.Drawing.Size(366, 25);
            this.loginHeaderLabel.TabIndex = 0;
            this.loginHeaderLabel.Text = "Howard Corp Appointment Scheduler";
            // 
            // loginWelcomeLabel
            // 
            this.loginWelcomeLabel.AutoSize = true;
            this.loginWelcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginWelcomeLabel.Location = new System.Drawing.Point(216, 105);
            this.loginWelcomeLabel.Name = "loginWelcomeLabel";
            this.loginWelcomeLabel.Size = new System.Drawing.Size(111, 20);
            this.loginWelcomeLabel.TabIndex = 1;
            this.loginWelcomeLabel.Text = "Please Sign In";
            // 
            // loginUserLabel
            // 
            this.loginUserLabel.AutoSize = true;
            this.loginUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginUserLabel.Location = new System.Drawing.Point(96, 171);
            this.loginUserLabel.Name = "loginUserLabel";
            this.loginUserLabel.Size = new System.Drawing.Size(83, 20);
            this.loginUserLabel.TabIndex = 2;
            this.loginUserLabel.Text = "Username";
            // 
            // loginPasswordLabel
            // 
            this.loginPasswordLabel.AutoSize = true;
            this.loginPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginPasswordLabel.Location = new System.Drawing.Point(96, 259);
            this.loginPasswordLabel.Name = "loginPasswordLabel";
            this.loginPasswordLabel.Size = new System.Drawing.Size(78, 20);
            this.loginPasswordLabel.TabIndex = 3;
            this.loginPasswordLabel.Text = "Password";
            // 
            // loginUserField
            // 
            this.loginUserField.Location = new System.Drawing.Point(128, 203);
            this.loginUserField.Name = "loginUserField";
            this.loginUserField.Size = new System.Drawing.Size(280, 20);
            this.loginUserField.TabIndex = 4;
            // 
            // loginPasswordField
            // 
            this.loginPasswordField.Location = new System.Drawing.Point(128, 291);
            this.loginPasswordField.Name = "loginPasswordField";
            this.loginPasswordField.Size = new System.Drawing.Size(280, 20);
            this.loginPasswordField.TabIndex = 5;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(220, 379);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(99, 38);
            this.loginButton.TabIndex = 7;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 488);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.loginPasswordField);
            this.Controls.Add(this.loginUserField);
            this.Controls.Add(this.loginPasswordLabel);
            this.Controls.Add(this.loginUserLabel);
            this.Controls.Add(this.loginWelcomeLabel);
            this.Controls.Add(this.loginHeaderLabel);
            this.Name = "login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label loginHeaderLabel;
        public System.Windows.Forms.Label loginWelcomeLabel;
        public System.Windows.Forms.Label loginUserLabel;
        public System.Windows.Forms.Label loginPasswordLabel;
        public System.Windows.Forms.TextBox loginUserField;
        public System.Windows.Forms.TextBox loginPasswordField;
        public System.Windows.Forms.Button loginButton;
    }
}

