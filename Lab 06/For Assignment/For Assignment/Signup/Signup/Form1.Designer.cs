namespace Signup
{
    partial class signup
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
            panel1 = new Panel();
            label1 = new Label();
            groupBox1 = new GroupBox();
            occupation = new TextBox();
            email = new TextBox();
            birthDatePick = new DateTimePicker();
            sxCombo = new ComboBox();
            lname = new TextBox();
            fname = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            submit = new Button();
            groupBox2 = new GroupBox();
            loginPasswordTextBox = new TextBox();
            loginUsernameTextBox = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            groupBox3 = new GroupBox();
            confirmPasswordTextBox = new TextBox();
            label20 = new Label();
            signupPasswordTextBox = new TextBox();
            signupUsernameTextBox = new TextBox();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(11, 9);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(954, 46);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(6, 8);
            label1.Name = "label1";
            label1.Size = new Size(309, 36);
            label1.TabIndex = 0;
            label1.Text = "lnformation Collector";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Window;
            groupBox1.Controls.Add(occupation);
            groupBox1.Controls.Add(email);
            groupBox1.Controls.Add(birthDatePick);
            groupBox1.Controls.Add(sxCombo);
            groupBox1.Controls.Add(lname);
            groupBox1.Controls.Add(fname);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(17, 70);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(424, 239);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Personal Information";
            // 
            // occupation
            // 
            occupation.Location = new Point(143, 196);
            occupation.Margin = new Padding(3, 2, 3, 2);
            occupation.Name = "occupation";
            occupation.Size = new Size(258, 28);
            occupation.TabIndex = 11;
            // 
            // email
            // 
            email.Location = new Point(143, 161);
            email.Margin = new Padding(3, 2, 3, 2);
            email.Name = "email";
            email.Size = new Size(258, 28);
            email.TabIndex = 10;
            // 
            // birthDatePick
            // 
            birthDatePick.CalendarFont = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            birthDatePick.Location = new Point(143, 127);
            birthDatePick.Margin = new Padding(3, 2, 3, 2);
            birthDatePick.Name = "birthDatePick";
            birthDatePick.Size = new Size(258, 28);
            birthDatePick.TabIndex = 9;
            // 
            // sxCombo
            // 
            sxCombo.FormattingEnabled = true;
            sxCombo.Items.AddRange(new object[] { "Male", "Female" });
            sxCombo.Location = new Point(143, 93);
            sxCombo.Margin = new Padding(3, 2, 3, 2);
            sxCombo.Name = "sxCombo";
            sxCombo.Size = new Size(258, 30);
            sxCombo.TabIndex = 8;
            // 
            // lname
            // 
            lname.Location = new Point(143, 59);
            lname.Margin = new Padding(3, 2, 3, 2);
            lname.Name = "lname";
            lname.Size = new Size(258, 28);
            lname.TabIndex = 7;
            // 
            // fname
            // 
            fname.Location = new Point(143, 27);
            fname.Margin = new Padding(3, 2, 3, 2);
            fname.Name = "fname";
            fname.Size = new Size(258, 28);
            fname.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(11, 200);
            label7.Name = "label7";
            label7.Size = new Size(129, 24);
            label7.TabIndex = 5;
            label7.Text = "Occupation: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(67, 168);
            label6.Name = "label6";
            label6.Size = new Size(74, 24);
            label6.TabIndex = 4;
            label6.Text = "Email: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(22, 135);
            label5.Name = "label5";
            label5.Size = new Size(112, 24);
            label5.TabIndex = 3;
            label5.Text = "Birth Date: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(86, 100);
            label4.Name = "label4";
            label4.Size = new Size(52, 24);
            label4.TabIndex = 2;
            label4.Text = "Sex:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(22, 65);
            label3.Name = "label3";
            label3.Size = new Size(117, 24);
            label3.TabIndex = 1;
            label3.Text = "Last name: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(19, 29);
            label2.Name = "label2";
            label2.Size = new Size(120, 24);
            label2.TabIndex = 0;
            label2.Text = "First name: ";
            // 
            // submit
            // 
            submit.BackColor = SystemColors.ButtonFace;
            submit.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            submit.Location = new Point(431, 329);
            submit.Margin = new Padding(3, 2, 3, 2);
            submit.Name = "submit";
            submit.Size = new Size(95, 33);
            submit.TabIndex = 2;
            submit.Text = "Submit";
            submit.UseVisualStyleBackColor = false;
            submit.Click += submit_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.Window;
            groupBox2.Controls.Add(loginPasswordTextBox);
            groupBox2.Controls.Add(loginUsernameTextBox);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label13);
            groupBox2.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(457, 70);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(508, 100);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Login";
            // 
            // loginPasswordTextBox
            // 
            loginPasswordTextBox.Location = new Point(223, 63);
            loginPasswordTextBox.Margin = new Padding(3, 2, 3, 2);
            loginPasswordTextBox.Name = "loginPasswordTextBox";
            loginPasswordTextBox.Size = new Size(258, 28);
            loginPasswordTextBox.TabIndex = 7;
            // 
            // loginUsernameTextBox
            // 
            loginUsernameTextBox.Location = new Point(223, 29);
            loginUsernameTextBox.Margin = new Padding(3, 2, 3, 2);
            loginUsernameTextBox.Name = "loginUsernameTextBox";
            loginUsernameTextBox.Size = new Size(258, 28);
            loginUsernameTextBox.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(12, 201);
            label8.Name = "label8";
            label8.Size = new Size(0, 24);
            label8.TabIndex = 5;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(68, 169);
            label9.Name = "label9";
            label9.Size = new Size(0, 24);
            label9.TabIndex = 4;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(23, 136);
            label10.Name = "label10";
            label10.Size = new Size(0, 24);
            label10.TabIndex = 3;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(87, 101);
            label11.Name = "label11";
            label11.Size = new Size(0, 24);
            label11.TabIndex = 2;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(102, 67);
            label12.Name = "label12";
            label12.Size = new Size(106, 24);
            label12.TabIndex = 1;
            label12.Text = "Password:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(99, 30);
            label13.Name = "label13";
            label13.Size = new Size(111, 24);
            label13.TabIndex = 0;
            label13.Text = "Username:";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = SystemColors.Window;
            groupBox3.Controls.Add(confirmPasswordTextBox);
            groupBox3.Controls.Add(label20);
            groupBox3.Controls.Add(signupPasswordTextBox);
            groupBox3.Controls.Add(signupUsernameTextBox);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(label17);
            groupBox3.Controls.Add(label18);
            groupBox3.Controls.Add(label19);
            groupBox3.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox3.Location = new Point(457, 181);
            groupBox3.Margin = new Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(508, 128);
            groupBox3.TabIndex = 13;
            groupBox3.TabStop = false;
            groupBox3.Text = "Sign Up";
            // 
            // confirmPasswordTextBox
            // 
            confirmPasswordTextBox.Location = new Point(223, 93);
            confirmPasswordTextBox.Margin = new Padding(3, 2, 3, 2);
            confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            confirmPasswordTextBox.Size = new Size(258, 28);
            confirmPasswordTextBox.TabIndex = 9;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            label20.Location = new Point(23, 96);
            label20.Name = "label20";
            label20.Size = new Size(184, 24);
            label20.TabIndex = 8;
            label20.Text = "Confirm Password:";
            // 
            // signupPasswordTextBox
            // 
            signupPasswordTextBox.Location = new Point(223, 63);
            signupPasswordTextBox.Margin = new Padding(3, 2, 3, 2);
            signupPasswordTextBox.Name = "signupPasswordTextBox";
            signupPasswordTextBox.Size = new Size(258, 28);
            signupPasswordTextBox.TabIndex = 7;
            // 
            // signupUsernameTextBox
            // 
            signupUsernameTextBox.Location = new Point(223, 28);
            signupUsernameTextBox.Margin = new Padding(3, 2, 3, 2);
            signupUsernameTextBox.Name = "signupUsernameTextBox";
            signupUsernameTextBox.Size = new Size(258, 28);
            signupUsernameTextBox.TabIndex = 6;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(13, 202);
            label14.Name = "label14";
            label14.Size = new Size(0, 24);
            label14.TabIndex = 5;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(69, 170);
            label15.Name = "label15";
            label15.Size = new Size(0, 24);
            label15.TabIndex = 4;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            label16.Location = new Point(24, 137);
            label16.Name = "label16";
            label16.Size = new Size(0, 24);
            label16.TabIndex = 3;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            label17.Location = new Point(88, 102);
            label17.Name = "label17";
            label17.Size = new Size(0, 24);
            label17.TabIndex = 2;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            label18.Location = new Point(102, 65);
            label18.Name = "label18";
            label18.Size = new Size(106, 24);
            label18.TabIndex = 1;
            label18.Text = "Password:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Microsoft Sans Serif", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            label19.Location = new Point(99, 31);
            label19.Name = "label19";
            label19.Size = new Size(111, 24);
            label19.TabIndex = 0;
            label19.Text = "Username:";
            // 
            // signup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 373);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(submit);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "signup";
            Text = "Sign-up form";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private GroupBox groupBox1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private DateTimePicker birthDatePick;
        private ComboBox sxCombo;
        private TextBox lname;
        private TextBox fname;
        private TextBox occupation;
        private TextBox email;
        private Button submit;
        private GroupBox groupBox2;
        private TextBox loginPasswordTextBox;
        private TextBox loginUsernameTextBox;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private GroupBox groupBox3;
        private TextBox signupPasswordTextBox;
        private TextBox signupUsernameTextBox;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private TextBox confirmPasswordTextBox;
    }
}