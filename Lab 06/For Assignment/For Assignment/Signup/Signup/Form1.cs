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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}