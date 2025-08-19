using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class Form2 : Form
    {
        private User currentUser;
        public Form2(User user)
        {
            InitializeComponent();
            currentUser = user;
        }
       
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // When you click on the User Add-in button it should direct to Form 1
            // hide the form2 and create an object of form1, then show it 

            this.Hide(); // Hide current form (Form2)

            Form1 form1 = new Form1(); // Create a new instance of Form1
            form1.ShowDialog(); // Show Form1 as a modal dialog

            this.Close(); // Close Form2 after Form1 is done
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Hi {currentUser.title} {currentUser.firstName} {currentUser.lastName}!!!!";

            descriptionText.Text = $"We are glad to welcome you as one of the {currentUser.userGroup}s";
        }
    }
    }
