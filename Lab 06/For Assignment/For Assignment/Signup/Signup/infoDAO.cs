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