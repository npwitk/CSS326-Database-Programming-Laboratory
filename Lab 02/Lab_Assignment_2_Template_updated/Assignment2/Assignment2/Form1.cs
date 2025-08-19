using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Assignment2
{
    public partial class Form1 : Form
    {
        //static List<User> us = new List<User>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = comboBox1.SelectedItem?.ToString();
            //string title = comboBox1.Text;
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string email = emailTextBox.Text;

            string userGroup = "";

            if (instructorRadioButton.Checked)
                userGroup = "Instructor";
            else if (taRadioButton.Checked)
                userGroup = "TA";
            else if (studentRadioButton.Checked)
                userGroup = "Student";

            // Validation
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(title) || userGroup == "")
            {
                MessageBox.Show("Please fill all the fields.");
                return;
            }

            User user = new User(title, firstName, lastName, email, userGroup);

            // Hide current form
            this.Hide();

            // Pass user object to Form2
            Form2 form2 = new Form2(user);
            form2.ShowDialog();

            // Close Form1 after Form2 is closed
            this.Close();
        }

    }
}
