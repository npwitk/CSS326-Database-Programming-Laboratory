namespace _02_LoginForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            studentNameLabel = new Label();
            studentIdLabel = new Label();
            studentInfoLabel = new Label();
            studentNameTextField = new TextBox();
            studentIdTextField = new TextBox();
            schoolLabel = new Label();
            schoolComboBox = new ComboBox();
            locationLabel = new Label();
            locationComboBox = new ComboBox();
            submitButton = new Button();
            confInfoLabel = new Label();
            databaseCheckBox = new CheckBox();
            industrialCheckBox = new CheckBox();
            aiCheckBox = new CheckBox();
            levelLabel = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // studentNameLabel
            // 
            studentNameLabel.AutoSize = true;
            studentNameLabel.Location = new Point(66, 178);
            studentNameLabel.Name = "studentNameLabel";
            studentNameLabel.Size = new Size(168, 32);
            studentNameLabel.TabIndex = 0;
            studentNameLabel.Text = "Student Name";
            // 
            // studentIdLabel
            // 
            studentIdLabel.AutoSize = true;
            studentIdLabel.Location = new Point(66, 235);
            studentIdLabel.Name = "studentIdLabel";
            studentIdLabel.Size = new Size(127, 32);
            studentIdLabel.TabIndex = 1;
            studentIdLabel.Text = "Student ID";
            // 
            // studentInfoLabel
            // 
            studentInfoLabel.AutoSize = true;
            studentInfoLabel.Font = new Font("Segoe UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point);
            studentInfoLabel.Location = new Point(66, 73);
            studentInfoLabel.Name = "studentInfoLabel";
            studentInfoLabel.Size = new Size(438, 59);
            studentInfoLabel.TabIndex = 2;
            studentInfoLabel.Text = "Student Information";
            // 
            // studentNameTextField
            // 
            studentNameTextField.Location = new Point(263, 175);
            studentNameTextField.Name = "studentNameTextField";
            studentNameTextField.Size = new Size(557, 39);
            studentNameTextField.TabIndex = 3;
            // 
            // studentIdTextField
            // 
            studentIdTextField.Location = new Point(263, 235);
            studentIdTextField.Name = "studentIdTextField";
            studentIdTextField.Size = new Size(557, 39);
            studentIdTextField.TabIndex = 4;
            // 
            // schoolLabel
            // 
            schoolLabel.AutoSize = true;
            schoolLabel.Location = new Point(66, 300);
            schoolLabel.Name = "schoolLabel";
            schoolLabel.Size = new Size(86, 32);
            schoolLabel.TabIndex = 5;
            schoolLabel.Text = "School";
            // 
            // schoolComboBox
            // 
            schoolComboBox.FormattingEnabled = true;
            schoolComboBox.Items.AddRange(new object[] { "BCET", "CET", "ICT", "MSME", "MT" });
            schoolComboBox.Location = new Point(263, 297);
            schoolComboBox.Name = "schoolComboBox";
            schoolComboBox.Size = new Size(557, 40);
            schoolComboBox.TabIndex = 6;
            // 
            // locationLabel
            // 
            locationLabel.AutoSize = true;
            locationLabel.Location = new Point(66, 360);
            locationLabel.Name = "locationLabel";
            locationLabel.Size = new Size(104, 32);
            locationLabel.TabIndex = 7;
            locationLabel.Text = "Location";
            // 
            // locationComboBox
            // 
            locationComboBox.FormattingEnabled = true;
            locationComboBox.Items.AddRange(new object[] { "Rangsit", "Bangkadi", "Other" });
            locationComboBox.Location = new Point(263, 360);
            locationComboBox.Name = "locationComboBox";
            locationComboBox.Size = new Size(557, 40);
            locationComboBox.TabIndex = 8;
            // 
            // submitButton
            // 
            submitButton.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            submitButton.Location = new Point(287, 847);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(297, 81);
            submitButton.TabIndex = 9;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // confInfoLabel
            // 
            confInfoLabel.AutoSize = true;
            confInfoLabel.Font = new Font("Segoe UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point);
            confInfoLabel.Location = new Point(66, 508);
            confInfoLabel.Name = "confInfoLabel";
            confInfoLabel.Size = new Size(507, 59);
            confInfoLabel.TabIndex = 10;
            confInfoLabel.Text = "Conference Information";
            // 
            // databaseCheckBox
            // 
            databaseCheckBox.AutoSize = true;
            databaseCheckBox.Location = new Point(66, 592);
            databaseCheckBox.Name = "databaseCheckBox";
            databaseCheckBox.Size = new Size(294, 36);
            databaseCheckBox.TabIndex = 11;
            databaseCheckBox.Text = "Database Management";
            databaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // industrialCheckBox
            // 
            industrialCheckBox.AutoSize = true;
            industrialCheckBox.Location = new Point(66, 647);
            industrialCheckBox.Name = "industrialCheckBox";
            industrialCheckBox.Size = new Size(182, 36);
            industrialCheckBox.TabIndex = 12;
            industrialCheckBox.Text = "Industrial 4.0";
            industrialCheckBox.UseVisualStyleBackColor = true;
            // 
            // aiCheckBox
            // 
            aiCheckBox.AutoSize = true;
            aiCheckBox.Location = new Point(66, 702);
            aiCheckBox.Name = "aiCheckBox";
            aiCheckBox.Size = new Size(263, 36);
            aiCheckBox.TabIndex = 13;
            aiCheckBox.Text = "Artificial Intelligence";
            aiCheckBox.UseVisualStyleBackColor = true;
            // 
            // levelLabel
            // 
            levelLabel.AutoSize = true;
            levelLabel.Location = new Point(66, 420);
            levelLabel.Name = "levelLabel";
            levelLabel.Size = new Size(69, 32);
            levelLabel.TabIndex = 14;
            levelLabel.Text = "Level";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(263, 420);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(83, 36);
            radioButton1.TabIndex = 15;
            radioButton1.TabStop = true;
            radioButton1.Text = "BSc";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(413, 420);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(91, 36);
            radioButton2.TabIndex = 16;
            radioButton2.TabStop = true;
            radioButton2.Text = "MSc";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(66, 764);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(400, 39);
            dateTimePicker1.TabIndex = 17;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(881, 982);
            Controls.Add(dateTimePicker1);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(levelLabel);
            Controls.Add(aiCheckBox);
            Controls.Add(industrialCheckBox);
            Controls.Add(databaseCheckBox);
            Controls.Add(confInfoLabel);
            Controls.Add(submitButton);
            Controls.Add(locationComboBox);
            Controls.Add(locationLabel);
            Controls.Add(schoolComboBox);
            Controls.Add(schoolLabel);
            Controls.Add(studentIdTextField);
            Controls.Add(studentNameTextField);
            Controls.Add(studentInfoLabel);
            Controls.Add(studentIdLabel);
            Controls.Add(studentNameLabel);
            Name = "Form1";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label studentNameLabel;
        private Label studentIdLabel;
        private Label studentInfoLabel;
        private TextBox studentNameTextField;
        private TextBox studentIdTextField;
        private Label schoolLabel;
        private ComboBox schoolComboBox;
        private Label locationLabel;
        private ComboBox locationComboBox;
        private Button submitButton;
        private Label confInfoLabel;
        private CheckBox databaseCheckBox;
        private CheckBox industrialCheckBox;
        private CheckBox aiCheckBox;
        private Label levelLabel;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private DateTimePicker dateTimePicker1;
    }
}