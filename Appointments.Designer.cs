
namespace AndrewHowardSchedulerApp
{
    partial class Appointments
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
            this.apptDataGrid = new System.Windows.Forms.DataGridView();
            this.apptMonthViewRadio = new System.Windows.Forms.RadioButton();
            this.apptWeekViewRadio = new System.Windows.Forms.RadioButton();
            this.apptDayViewRadio = new System.Windows.Forms.RadioButton();
            this.apptViewOptionsLabel = new System.Windows.Forms.Label();
            this.apptTypeComboBox = new System.Windows.Forms.ComboBox();
            this.apptEndLabel = new System.Windows.Forms.Label();
            this.apptStartLabel = new System.Windows.Forms.Label();
            this.apptCustomerLabel = new System.Windows.Forms.Label();
            this.apptCustomerComboBox = new System.Windows.Forms.ComboBox();
            this.apptEndPicker = new System.Windows.Forms.DateTimePicker();
            this.apptStartPicker = new System.Windows.Forms.DateTimePicker();
            this.apptTypeLabel = new System.Windows.Forms.Label();
            this.apptEditButton = new System.Windows.Forms.Button();
            this.apptAddButton = new System.Windows.Forms.Button();
            this.apptDeleteButton = new System.Windows.Forms.Button();
            this.reportsButton = new System.Windows.Forms.Button();
            this.customersButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.apptTitle = new System.Windows.Forms.Label();
            this.apptTitleField = new System.Windows.Forms.TextBox();
            this.apptTitleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.apptDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // apptDataGrid
            // 
            this.apptDataGrid.AllowUserToAddRows = false;
            this.apptDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.apptDataGrid.Location = new System.Drawing.Point(39, 67);
            this.apptDataGrid.Name = "apptDataGrid";
            this.apptDataGrid.ReadOnly = true;
            this.apptDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.apptDataGrid.Size = new System.Drawing.Size(910, 549);
            this.apptDataGrid.TabIndex = 4;
            this.apptDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.apptDataGrid_CellClick);
            // 
            // apptMonthViewRadio
            // 
            this.apptMonthViewRadio.AutoSize = true;
            this.apptMonthViewRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptMonthViewRadio.Location = new System.Drawing.Point(762, 41);
            this.apptMonthViewRadio.Name = "apptMonthViewRadio";
            this.apptMonthViewRadio.Size = new System.Drawing.Size(62, 20);
            this.apptMonthViewRadio.TabIndex = 7;
            this.apptMonthViewRadio.TabStop = true;
            this.apptMonthViewRadio.Text = "Month";
            this.apptMonthViewRadio.UseVisualStyleBackColor = true;
            this.apptMonthViewRadio.CheckedChanged += new System.EventHandler(this.apptMonthViewRadio_CheckedChanged);
            // 
            // apptWeekViewRadio
            // 
            this.apptWeekViewRadio.AutoSize = true;
            this.apptWeekViewRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptWeekViewRadio.Location = new System.Drawing.Point(830, 41);
            this.apptWeekViewRadio.Name = "apptWeekViewRadio";
            this.apptWeekViewRadio.Size = new System.Drawing.Size(62, 20);
            this.apptWeekViewRadio.TabIndex = 8;
            this.apptWeekViewRadio.TabStop = true;
            this.apptWeekViewRadio.Text = "Week";
            this.apptWeekViewRadio.UseVisualStyleBackColor = true;
            this.apptWeekViewRadio.CheckedChanged += new System.EventHandler(this.apptWeekViewRadio_CheckedChanged);
            // 
            // apptDayViewRadio
            // 
            this.apptDayViewRadio.AutoSize = true;
            this.apptDayViewRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptDayViewRadio.Location = new System.Drawing.Point(898, 41);
            this.apptDayViewRadio.Name = "apptDayViewRadio";
            this.apptDayViewRadio.Size = new System.Drawing.Size(51, 20);
            this.apptDayViewRadio.TabIndex = 9;
            this.apptDayViewRadio.TabStop = true;
            this.apptDayViewRadio.Text = "Day";
            this.apptDayViewRadio.UseVisualStyleBackColor = true;
            this.apptDayViewRadio.CheckedChanged += new System.EventHandler(this.apptDayViewRadio_CheckedChanged);
            // 
            // apptViewOptionsLabel
            // 
            this.apptViewOptionsLabel.AutoSize = true;
            this.apptViewOptionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptViewOptionsLabel.Location = new System.Drawing.Point(847, 18);
            this.apptViewOptionsLabel.Name = "apptViewOptionsLabel";
            this.apptViewOptionsLabel.Size = new System.Drawing.Size(102, 20);
            this.apptViewOptionsLabel.TabIndex = 10;
            this.apptViewOptionsLabel.Text = "View Options";
            // 
            // apptTypeComboBox
            // 
            this.apptTypeComboBox.FormattingEnabled = true;
            this.apptTypeComboBox.Location = new System.Drawing.Point(472, 754);
            this.apptTypeComboBox.Name = "apptTypeComboBox";
            this.apptTypeComboBox.Size = new System.Drawing.Size(229, 21);
            this.apptTypeComboBox.TabIndex = 50;
            // 
            // apptEndLabel
            // 
            this.apptEndLabel.AutoSize = true;
            this.apptEndLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptEndLabel.Location = new System.Drawing.Point(718, 735);
            this.apptEndLabel.Name = "apptEndLabel";
            this.apptEndLabel.Size = new System.Drawing.Size(32, 16);
            this.apptEndLabel.TabIndex = 47;
            this.apptEndLabel.Text = "End";
            // 
            // apptStartLabel
            // 
            this.apptStartLabel.AutoSize = true;
            this.apptStartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptStartLabel.Location = new System.Drawing.Point(718, 686);
            this.apptStartLabel.Name = "apptStartLabel";
            this.apptStartLabel.Size = new System.Drawing.Size(35, 16);
            this.apptStartLabel.TabIndex = 46;
            this.apptStartLabel.Text = "Start";
            // 
            // apptCustomerLabel
            // 
            this.apptCustomerLabel.AutoSize = true;
            this.apptCustomerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptCustomerLabel.Location = new System.Drawing.Point(469, 686);
            this.apptCustomerLabel.Name = "apptCustomerLabel";
            this.apptCustomerLabel.Size = new System.Drawing.Size(65, 16);
            this.apptCustomerLabel.TabIndex = 45;
            this.apptCustomerLabel.Text = "Customer";
            // 
            // apptCustomerComboBox
            // 
            this.apptCustomerComboBox.FormattingEnabled = true;
            this.apptCustomerComboBox.Location = new System.Drawing.Point(472, 705);
            this.apptCustomerComboBox.Name = "apptCustomerComboBox";
            this.apptCustomerComboBox.Size = new System.Drawing.Size(229, 21);
            this.apptCustomerComboBox.TabIndex = 44;
            // 
            // apptEndPicker
            // 
            this.apptEndPicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.apptEndPicker.Location = new System.Drawing.Point(721, 755);
            this.apptEndPicker.Margin = new System.Windows.Forms.Padding(2);
            this.apptEndPicker.Name = "apptEndPicker";
            this.apptEndPicker.Size = new System.Drawing.Size(229, 20);
            this.apptEndPicker.TabIndex = 43;
            this.apptEndPicker.Value = new System.DateTime(2021, 1, 3, 12, 0, 0, 0);
            // 
            // apptStartPicker
            // 
            this.apptStartPicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.apptStartPicker.Location = new System.Drawing.Point(721, 706);
            this.apptStartPicker.Margin = new System.Windows.Forms.Padding(2);
            this.apptStartPicker.Name = "apptStartPicker";
            this.apptStartPicker.Size = new System.Drawing.Size(229, 20);
            this.apptStartPicker.TabIndex = 42;
            this.apptStartPicker.Value = new System.DateTime(2021, 1, 3, 0, 0, 0, 0);
            // 
            // apptTypeLabel
            // 
            this.apptTypeLabel.AutoSize = true;
            this.apptTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptTypeLabel.Location = new System.Drawing.Point(469, 735);
            this.apptTypeLabel.Name = "apptTypeLabel";
            this.apptTypeLabel.Size = new System.Drawing.Size(40, 16);
            this.apptTypeLabel.TabIndex = 41;
            this.apptTypeLabel.Text = "Type";
            // 
            // apptEditButton
            // 
            this.apptEditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.apptEditButton.Location = new System.Drawing.Point(664, 796);
            this.apptEditButton.Name = "apptEditButton";
            this.apptEditButton.Size = new System.Drawing.Size(99, 38);
            this.apptEditButton.TabIndex = 51;
            this.apptEditButton.Text = "Edit";
            this.apptEditButton.UseVisualStyleBackColor = true;
            this.apptEditButton.Click += new System.EventHandler(this.apptEditButton_Click);
            // 
            // apptAddButton
            // 
            this.apptAddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.apptAddButton.Location = new System.Drawing.Point(472, 796);
            this.apptAddButton.Name = "apptAddButton";
            this.apptAddButton.Size = new System.Drawing.Size(99, 38);
            this.apptAddButton.TabIndex = 52;
            this.apptAddButton.Text = "Add";
            this.apptAddButton.UseVisualStyleBackColor = true;
            this.apptAddButton.Click += new System.EventHandler(this.apptAddButton_Click);
            // 
            // apptDeleteButton
            // 
            this.apptDeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.apptDeleteButton.Location = new System.Drawing.Point(850, 796);
            this.apptDeleteButton.Name = "apptDeleteButton";
            this.apptDeleteButton.Size = new System.Drawing.Size(99, 38);
            this.apptDeleteButton.TabIndex = 53;
            this.apptDeleteButton.Text = "Delete";
            this.apptDeleteButton.UseVisualStyleBackColor = true;
            this.apptDeleteButton.Click += new System.EventHandler(this.apptDeleteButton_Click);
            // 
            // reportsButton
            // 
            this.reportsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.reportsButton.Location = new System.Drawing.Point(39, 695);
            this.reportsButton.Name = "reportsButton";
            this.reportsButton.Size = new System.Drawing.Size(175, 38);
            this.reportsButton.TabIndex = 56;
            this.reportsButton.Text = "Reports";
            this.reportsButton.UseVisualStyleBackColor = true;
            this.reportsButton.Click += new System.EventHandler(this.reportsButton_Click);
            // 
            // customersButton
            // 
            this.customersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.customersButton.Location = new System.Drawing.Point(39, 642);
            this.customersButton.Name = "customersButton";
            this.customersButton.Size = new System.Drawing.Size(175, 38);
            this.customersButton.TabIndex = 55;
            this.customersButton.Text = "Customers";
            this.customersButton.UseVisualStyleBackColor = true;
            this.customersButton.Click += new System.EventHandler(this.customersButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.exitButton.Location = new System.Drawing.Point(39, 796);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(175, 38);
            this.exitButton.TabIndex = 57;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // apptTitle
            // 
            this.apptTitle.AutoSize = true;
            this.apptTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptTitle.Location = new System.Drawing.Point(34, 18);
            this.apptTitle.Name = "apptTitle";
            this.apptTitle.Size = new System.Drawing.Size(143, 25);
            this.apptTitle.TabIndex = 58;
            this.apptTitle.Text = "Appointments";
            // 
            // apptTitleField
            // 
            this.apptTitleField.Location = new System.Drawing.Point(595, 652);
            this.apptTitleField.Name = "apptTitleField";
            this.apptTitleField.Size = new System.Drawing.Size(229, 20);
            this.apptTitleField.TabIndex = 59;
            // 
            // apptTitleLabel
            // 
            this.apptTitleLabel.AutoSize = true;
            this.apptTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptTitleLabel.Location = new System.Drawing.Point(592, 633);
            this.apptTitleLabel.Name = "apptTitleLabel";
            this.apptTitleLabel.Size = new System.Drawing.Size(34, 16);
            this.apptTitleLabel.TabIndex = 60;
            this.apptTitleLabel.Text = "Title";
            // 
            // Appointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 861);
            this.Controls.Add(this.apptTitleLabel);
            this.Controls.Add(this.apptTitleField);
            this.Controls.Add(this.apptTitle);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.reportsButton);
            this.Controls.Add(this.customersButton);
            this.Controls.Add(this.apptDeleteButton);
            this.Controls.Add(this.apptAddButton);
            this.Controls.Add(this.apptEditButton);
            this.Controls.Add(this.apptTypeComboBox);
            this.Controls.Add(this.apptEndLabel);
            this.Controls.Add(this.apptStartLabel);
            this.Controls.Add(this.apptCustomerLabel);
            this.Controls.Add(this.apptCustomerComboBox);
            this.Controls.Add(this.apptEndPicker);
            this.Controls.Add(this.apptStartPicker);
            this.Controls.Add(this.apptTypeLabel);
            this.Controls.Add(this.apptViewOptionsLabel);
            this.Controls.Add(this.apptDayViewRadio);
            this.Controls.Add(this.apptWeekViewRadio);
            this.Controls.Add(this.apptMonthViewRadio);
            this.Controls.Add(this.apptDataGrid);
            this.Name = "Appointments";
            this.Text = "Appointments";
            ((System.ComponentModel.ISupportInitialize)(this.apptDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView apptDataGrid;
        private System.Windows.Forms.Label apptViewOptionsLabel;
        public System.Windows.Forms.Button reportsButton;
        public System.Windows.Forms.Button customersButton;
        public System.Windows.Forms.Button exitButton;
        public System.Windows.Forms.Button apptAddButton;
        public System.Windows.Forms.Button apptEditButton;
        public System.Windows.Forms.Button apptDeleteButton;
        public System.Windows.Forms.DateTimePicker apptEndPicker;
        public System.Windows.Forms.DateTimePicker apptStartPicker;
        public System.Windows.Forms.ComboBox apptTypeComboBox;
        public System.Windows.Forms.ComboBox apptCustomerComboBox;
        public System.Windows.Forms.RadioButton apptMonthViewRadio;
        public System.Windows.Forms.RadioButton apptWeekViewRadio;
        public System.Windows.Forms.RadioButton apptDayViewRadio;
        public System.Windows.Forms.Label apptTitle;
        public System.Windows.Forms.Label apptEndLabel;
        public System.Windows.Forms.Label apptStartLabel;
        public System.Windows.Forms.Label apptCustomerLabel;
        public System.Windows.Forms.Label apptTypeLabel;
        public System.Windows.Forms.TextBox apptTitleField;
        public System.Windows.Forms.Label apptTitleLabel;
    }
}