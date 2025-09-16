using MySql.Data.MySqlClient;
using Org.BouncyCastle.Ocsp;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Configuration;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Signup
{
    internal class infoDAO
    {
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=test;";
        // Create a connectionString specifying datasource, port, username, password and database
        List<info> info_try = new List<info>();
        // Function to add new record

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
            cmd.Parameters.AddWithValue("@Occupation", a1.Occup);
            int newRows = cmd.ExecuteNonQuery();
            connect.Close();
            return newRows;
        }

        // Function to retrieve information
        public List<info> getAll()
        {
            List<info> returnAll = new List<info>();
            // Create a list of object of class info
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            // Create MySqlConnection object and open connection
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM signup", conn);

            // Create MySqlCommand object which read all the records in database


            // Create MySqlDataReader object and read all the data gained from  MySqlCommand object. Pass the data to relevant info class parameter
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Create a info class object and pass info to relevant variable
                    //eg for string reader.GetString and for integer reader.GetInt32
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

                    //Add all information to info class object
                    returnAll.Add(r);
                }
            }
            // Close connection
            conn.Close ();
            // Return all records
            return returnAll;
           
        }

        // Function to update one record
        internal int updateOneRecord(info a1)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE signup SET First_Name = @fname, Last_Name = @lname, Sex = @sex, BirthDate = @birthdate, Email = @email, Occupation = @Occupation WHERE ID = @ID", conn);
            cmd.Parameters.AddWithValue("@ID", a1.ID);
            cmd.Parameters.AddWithValue("@fname", a1.FName);
            cmd.Parameters.AddWithValue("@lname", a1.LName);
            cmd.Parameters.AddWithValue("@sex", a1.Sex);
            cmd.Parameters.AddWithValue("@birthdate", a1.Bdate);
            cmd.Parameters.AddWithValue("@email", a1.Email);
            cmd.Parameters.AddWithValue("@Occupation", a1.Occup);
            int newRows = cmd.ExecuteNonQuery();
            conn.Close();
            return newRows;
        }

        // Function to delete one record
        internal int deleteOneRecord(int id_row)
        {
            MySqlConnection connect = new MySqlConnection(connectionString);
            connect.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `signup` WHERE `signup`.`ID` =@ID",
            connect);
            cmd.Parameters.AddWithValue("@ID", id_row);
            int newRows = cmd.ExecuteNonQuery();
            connect.Close();
            return newRows;
        }
       
    }
}
