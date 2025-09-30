# Lab Assignment 6 - Database Programming using C# & MySQL
## Assignment Overview

Complete the signup page with login functionality using two related database tables (signup and login) with proper validation and user authentication.
---

## Database Setup

### 1. Database Tables Structure

#### Table 1: signup
```sql
CREATE TABLE signup (
    ID int AUTO_INCREMENT PRIMARY KEY,
    First_Name VARCHAR(30),
    Last_Name VARCHAR(30),
    Sex VARCHAR(30),
    BirthDate DATE,
    Email VARCHAR(50) UNIQUE,
    Occupation VARCHAR(50)
);
```

#### Table 2: login
```sql
CREATE TABLE login (
    User_ID int AUTO_INCREMENT PRIMARY KEY,
    Signup_ID int NOT NULL,
    Username VARCHAR(50) UNIQUE NOT NULL,
    Password VARCHAR(20) NOT NULL,
    FOREIGN KEY (Signup_ID) REFERENCES signup(ID) ON DELETE CASCADE
);
```

### 2. Key Database Constraints

#### Add Foreign Key with Cascade Delete:
```sql
ALTER TABLE login 
ADD CONSTRAINT fk_signup_login 
FOREIGN KEY (Signup_ID) REFERENCES signup(ID) ON DELETE CASCADE;
```

#### Add Unique Constraints:
```sql
ALTER TABLE signup ADD CONSTRAINT unique_email UNIQUE (Email);
ALTER TABLE login ADD CONSTRAINT unique_username UNIQUE (Username);
```

---

## C# Implementation

### 1. info.cs (Data Model)
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signup
{
    internal class info
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Sex { get; set; }
        public string Bdate { get; set; }
        public string Email { get; set; }
        public string Occup { get; set; }
    }

    internal class login
    {
        public int UserID { get; set; }
        public int SignupID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
```

### 2. infoDAO.cs (Enhanced Data Access Object)
```csharp
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Signup
{
    internal class infoDAO
    {
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=test;";

        // Check if username already exists
        internal bool IsUsernameExists(string username)
        {
            using (MySqlConnection connect = new MySqlConnection(connectionString))
            {
                connect.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM login WHERE Username = @username", connect);
                cmd.Parameters.AddWithValue("@username", username);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        // Check if email already exists
        internal bool IsEmailExists(string email)
        {
            using (MySqlConnection connect = new MySqlConnection(connectionString))
            {
                connect.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM signup WHERE Email = @email", connect);
                cmd.Parameters.AddWithValue("@email", email);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        // Function to add new record and return the inserted ID
        internal int addOneRecord(info a1)
        {
            MySqlConnection connect = new MySqlConnection(connectionString);
            connect.Open();

            MySqlCommand cmd = new MySqlCommand("INSERT INTO `signup`(`First_Name`, `Last_Name`, `Sex`, `BirthDate`, `Email`, `Occupation`) VALUES(@fname, @lname, @sex, @birthdate, @email, @occupation)", connect);
            cmd.Parameters.AddWithValue("@fname", a1.FName);
            cmd.Parameters.AddWithValue("@lname", a1.LName);
            cmd.Parameters.AddWithValue("@sex", a1.Sex);
            cmd.Parameters.AddWithValue("@birthdate", a1.Bdate);
            cmd.Parameters.AddWithValue("@email", a1.Email);
            cmd.Parameters.AddWithValue("@occupation", a1.Occup);
            
            cmd.ExecuteNonQuery();
            int newId = (int)cmd.LastInsertedId;
            connect.Close();
            return newId;
        }

        // Add login record
        internal int addLoginRecord(login loginInfo)
        {
            MySqlConnection connect = new MySqlConnection(connectionString);
            connect.Open();

            MySqlCommand cmd = new MySqlCommand("INSERT INTO `login`(`Signup_ID`, `Username`, `Password`) VALUES(@signupid, @username, @password)", connect);
            cmd.Parameters.AddWithValue("@signupid", loginInfo.SignupID);
            cmd.Parameters.AddWithValue("@username", loginInfo.Username);
            cmd.Parameters.AddWithValue("@password", loginInfo.Password);
            
            int newRows = cmd.ExecuteNonQuery();
            connect.Close();
            return newRows;
        }

        // Verify login credentials and return signup ID
        internal int verifyLogin(string username, string password)
        {
            MySqlConnection connect = new MySqlConnection(connectionString);
            connect.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT Signup_ID FROM login WHERE Username = @username AND Password = @password", connect);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            object result = cmd.ExecuteScalar();
            connect.Close();
            return result != null ? Convert.ToInt32(result) : -1;
        }

        // Get specific user record by ID
        internal info getUserRecord(int signupID)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM signup WHERE ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", signupID);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    info r = new info
                    {
                        ID = reader.GetInt32(0),
                        FName = reader.GetString(1),
                        LName = reader.GetString(2),
                        Sex = reader.GetString(3),
                        Bdate = reader.GetDateTime(4).ToString("yyyy-MM-dd"),
                        Email = reader.GetString(5),
                        Occup = reader.GetString(6),
                    };
                    conn.Close();
                    return r;
                }
            }
            conn.Close();
            return null;
        }

        // Function to retrieve all information (keep for compatibility)
        public List<info> getAll()
        {
            List<info> returnAll = new List<info>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM signup", conn);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    info r = new info
                    {
                        ID = reader.GetInt32(0),
                        FName = reader.GetString(1),
                        LName = reader.GetString(2),
                        Sex = reader.GetString(3),
                        Bdate = reader.GetString(4),
                        Email = reader.GetString(5),
                        Occup = reader.GetString(6),
                    };
                    returnAll.Add(r);
                }
            }
            conn.Close();
            return returnAll;
        }

        // Function to update one record
        internal int updateOneRecord(info a1)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE signup SET First_Name = @fname, Last_Name = @lname, Sex = @sex, BirthDate = @birthdate, Email = @email, Occupation = @occupation WHERE ID = @ID", conn);
            cmd.Parameters.AddWithValue("@ID", a1.ID);
            cmd.Parameters.AddWithValue("@fname", a1.FName);
            cmd.Parameters.AddWithValue("@lname", a1.LName);
            cmd.Parameters.AddWithValue("@sex", a1.Sex);
            cmd.Parameters.AddWithValue("@birthdate", a1.Bdate);
            cmd.Parameters.AddWithValue("@email", a1.Email);
            cmd.Parameters.AddWithValue("@occupation", a1.Occup);
            int newRows = cmd.ExecuteNonQuery();
            conn.Close();
            return newRows;
        }

        // Function to delete one record (CASCADE will handle login table)
        internal int deleteOneRecord(int id_row)
        {
            MySqlConnection connect = new MySqlConnection(connectionString);
            connect.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `signup` WHERE `signup`.`ID` = @ID", connect);
            cmd.Parameters.AddWithValue("@ID", id_row);
            int newRows = cmd.ExecuteNonQuery();
            connect.Close();
            return newRows;
        }
    }
}
```

### 3. signup.cs (Main Form with Login/Signup)
```csharp
using System;
using System.Windows.Forms;

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
            infoDAO infor = new infoDAO();

            // Check if user is trying to login (priority to login section)
            if (!string.IsNullOrWhiteSpace(loginUsernameTextBox.Text) || !string.IsNullOrWhiteSpace(loginPasswordTextBox.Text))
            {
                HandleLogin(infor);
            }
            // Check if user is trying to signup
            else if (!string.IsNullOrWhiteSpace(signupUsernameTextBox.Text) || !string.IsNullOrWhiteSpace(signupPasswordTextBox.Text))
            {
                HandleSignup(infor);
            }
            else
            {
                MessageBox.Show("Please fill all the fields in either login or signup section");
            }
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
            // Validate personal information fields (REQUIREMENT A)
            if (string.IsNullOrWhiteSpace(fname.Text) || string.IsNullOrWhiteSpace(lname.Text) ||
                string.IsNullOrWhiteSpace(sxCombo.Text) || string.IsNullOrWhiteSpace(email.Text) ||
                string.IsNullOrWhiteSpace(occupation.Text))
            {
                MessageBox.Show("Please fill all the fields in personal information");
                return;
            }

            // Validate signup fields (REQUIREMENT A)
            if (string.IsNullOrWhiteSpace(signupUsernameTextBox.Text) || string.IsNullOrWhiteSpace(signupPasswordTextBox.Text) ||
                string.IsNullOrWhiteSpace(confirmPasswordTextBox.Text))
            {
                MessageBox.Show("Please fill all the fields in signup");
                return;
            }

            // Check password match (REQUIREMENT B) - MUST RETURN IF NOT MATCHING
            if (signupPasswordTextBox.Text != confirmPasswordTextBox.Text)
            {
                MessageBox.Show("Your passwords do not match");
                return; // This STOPS the signup process
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }
    }
}
```

### 4. userpage.cs (Updated for Single User View)
```csharp
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
```

### 5. updatepage.cs (Updated for Single User)
```csharp
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
```

---

## Form Design Requirements

### Main Signup Form Controls:
- **Personal Information Section:**
  - `fname` (TextBox) - First Name
  - `lname` (TextBox) - Last Name  
  - `sxCombo` (ComboBox) - Sex
  - `birthDatePick` (DateTimePicker) - Birth Date
  - `email` (TextBox) - Email
  - `occupation` (TextBox) - Occupation

- **Login Section:**
  - `loginUsernameTextBox` (TextBox) - Username
  - `loginPasswordTextBox` (TextBox) - Password

- **Signup Section:**
  - `signupUsernameTextBox` (TextBox) - Username
  - `signupPasswordTextBox` (TextBox) - Password
  - `confirmPasswordTextBox` (TextBox) - Confirm Password

- **Submit Button** - Handles both login and signup