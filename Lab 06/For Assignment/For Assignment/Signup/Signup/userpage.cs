using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace Signup
{
    public partial class userpage : Form
    {
        private info currentUser;
        private infoDAO infor;

        // Constructor for single user (from assignment requirements)
        public userpage(info user)
        {
            InitializeComponent();
            currentUser = user;
            infor = new infoDAO();
            LoadUserData();
        }

        // Keep old constructor for compatibility
        public userpage(List<info> userList)
        {
            InitializeComponent();
            infor = new infoDAO();
            if (userList != null && userList.Count > 0)
            {
                currentUser = userList[0];
                LoadUserData();
            }
        }

        private void LoadUserData()
        {
            // Create a list with only the current user's data
            List<info> userList = new List<info> { currentUser };

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = userList;
            userdataGridView.DataSource = bindingSource;
        }

        private void update_Click(object sender, EventArgs e)
        {
            this.Hide();
            updatepage newupdatepage = new updatepage(currentUser);
            newupdatepage.ShowDialog();

            // Refresh data after update
            currentUser = infor.getUserRecord(currentUser.ID);
            LoadUserData();
            this.Show();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete your account?",
                "Confirm Delete", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                infor.deleteOneRecord(currentUser.ID);
                MessageBox.Show("Your account has been deleted.");
                this.Close();
            }
        }

        private void userdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Only allow selection of the user's own record
            if (e.RowIndex >= 0)
            {
                DataGridView dataGridView = (DataGridView)sender;
                int selectedID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value);

                // Ensure user can only interact with their own record
                if (selectedID != currentUser.ID)
                {
                    MessageBox.Show("You can only modify your own record.");
                    return;
                }
            }
        }
    }
}