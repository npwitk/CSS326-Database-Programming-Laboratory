using System;
using System.Windows.Forms;

namespace Signup
{
    public partial class updatepage : Form
    {
        private info userToUpdate;
        private infoDAO infor;

        public updatepage(info user)
        {
            InitializeComponent();
            userToUpdate = user;
            infor = new infoDAO();
            LoadUserData();
        }

        private void LoadUserData()
        {
            fname.Text = userToUpdate.FName;
            lname.Text = userToUpdate.LName;
            sxCombo.Text = userToUpdate.Sex;
            birthDatePick.Value = DateTime.Parse(userToUpdate.Bdate);
            email.Text = userToUpdate.Email;
            occupation.Text = userToUpdate.Occup;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            // Validate all fields
            if (string.IsNullOrWhiteSpace(fname.Text) || string.IsNullOrWhiteSpace(lname.Text) ||
                string.IsNullOrWhiteSpace(sxCombo.Text) || string.IsNullOrWhiteSpace(email.Text) ||
                string.IsNullOrWhiteSpace(occupation.Text))
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }

            // Check if email is unique (excluding current user's email)
            if (email.Text != userToUpdate.Email && infor.IsEmailExists(email.Text))
            {
                MessageBox.Show("Email already exists. Please use a different email.");
                return;
            }

            try
            {
                string dateValue = birthDatePick.Value.ToString("yyyy-MM-dd");
                info updatedUser = new info()
                {
                    ID = userToUpdate.ID,
                    FName = fname.Text,
                    LName = lname.Text,
                    Sex = sxCombo.Text,
                    Bdate = dateValue,
                    Email = email.Text,
                    Occup = occupation.Text,
                };

                int result = infor.updateOneRecord(updatedUser);
                if (result > 0)
                {
                    MessageBox.Show("Profile updated successfully!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Update failed. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating profile: " + ex.Message);
            }
        }
    }
}