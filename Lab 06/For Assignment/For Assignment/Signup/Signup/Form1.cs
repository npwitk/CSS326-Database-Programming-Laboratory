using System;
using System.Windows.Forms;
using ZstdSharp.Unsafe;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Signup
{
    public partial class signup : Form
    {


        public signup()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, EventArgs e)
        {

            string dateValue = birthDatePick.Value.ToString("yyyy-MM-dd");
            info a1 = new info()
            {
                ID = 1,
                FName = fname.Text,
                LName = lname.Text,
                Sex = sxCombo.Text,
                Bdate = dateValue,
                Email = email.Text,
                Occup = occupation.Text,
            };
            infoDAO infor = new infoDAO();
            int result = infor.addOneRecord(a1); // Result will store returned value like 0 row affected.
            // infor.addOneRecord(a1);
            this.Hide();
            userpage newuserpage = new userpage(infor.getAll());
            newuserpage.ShowDialog();


        }

        private void HandleLogin(infoDAO infor)
        {
            // Validate login fields
            if (string.IsNullOrWhiteSpace(loginUsernameTextBox.Text) || string.IsNullOrWhiteSpace(loginPasswordTextBox.Text))
            {
                MessageBox.Show("Please fill all the fields in login section");
                return;
            }

            // Verify login credentials
            int signupID = infor.verifyLogin(loginUsernameTextBox.Text, loginPasswordTextBox.Text);
            if (signupID != -1)
            {
                // Login successful - show user's own record only
                info userInfo = infor.getUserRecord(signupID);
                if (userInfo != null)
                {
                    this.Hide();
                    userpage newuserpage = new userpage(userInfo);
                    newuserpage.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        private void HandleSignup(infoDAO infor)
        {
            // Validate personal information fields
            if (string.IsNullOrWhiteSpace(fname.Text) || string.IsNullOrWhiteSpace(lname.Text) ||
                string.IsNullOrWhiteSpace(sxCombo.Text) || string.IsNullOrWhiteSpace(email.Text) ||
                string.IsNullOrWhiteSpace(occupation.Text))
            {
                MessageBox.Show("Please fill all the fields in personal information");
                return;
            }

            // Validate signup fields
            if (string.IsNullOrWhiteSpace(signupUsernameTextBox.Text) || string.IsNullOrWhiteSpace(signupPasswordTextBox.Text) ||
                string.IsNullOrWhiteSpace(confirmPasswordTextBox.Text))
            {
                MessageBox.Show("Please fill all the fields in signup");
                return;
            }

            // Check password match
            if (signupPasswordTextBox.Text != confirmPasswordTextBox.Text)
            {
                MessageBox.Show("Your passwords do not match");
                return;
            }

            // Check for unique username
            if (infor.IsUsernameExists(signupUsernameTextBox.Text))
            {
                MessageBox.Show("Username already exists. Please choose a different username.");
                return;
            }

            // Check for unique email
            if (infor.IsEmailExists(email.Text))
            {
                MessageBox.Show("Email already exists. Please use a different email.");
                return;
            }

            try
            {
                // Create signup record
                string dateValue = birthDatePick.Value.ToString("yyyy-MM-dd");
                info a1 = new info()
                {
                    FName = fname.Text,
                    LName = lname.Text,
                    Sex = sxCombo.Text,
                    Bdate = dateValue,
                    Email = email.Text,
                    Occup = occupation.Text,
                };

                int signupID = infor.addOneRecord(a1);

                // Create login record
                login newLogin = new login()
                {
                    SignupID = signupID,
                    Username = signupUsernameTextBox.Text,
                    Password = signupPasswordTextBox.Text
                };

                infor.addLoginRecord(newLogin);

                MessageBox.Show("Row added to information collector.");

                // Show user's own record
                a1.ID = signupID;
                this.Hide();
                userpage newuserpage = new userpage(a1);
                newuserpage.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating account: " + ex.Message);
            }
        }
    }
}