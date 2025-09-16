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
        public int rowClicked;
        public int id_row;
        BindingSource infobindingSource = new BindingSource();

        // Create a list of info object
        //private List<info> result;

        public userpage()
        {
            InitializeComponent();
        }
        public userpage(object v)
        {
            InitializeComponent();
            V = v;
        }
        public object V { get; set; }
        private void userpage_Load(object sender, EventArgs e)
        {
            infobindingSource.DataSource = V;
            userdataGridView.DataSource = infobindingSource;
        }

        private void userdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView dataGridView = (DataGridView)sender;
            rowClicked = dataGridView.CurrentRow.Index;
            id_row = Int32.Parse(dataGridView.Rows[rowClicked].Cells[0].Value.ToString());
        }

        private void update_Click(object sender, EventArgs e)
        {
            infoDAO infor = new infoDAO();
            this.Hide();
            updatepage newupdatepage = new updatepage(id_row);

            newupdatepage.ShowDialog();

        }

        private void delete_Click(object sender, EventArgs e)
        {
            infoDAO infor = new infoDAO();
            int result = infor.deleteOneRecord(id_row);
            this.Hide();
            userpage newuserpage = new userpage(infor.getAll());
            newuserpage.ShowDialog();
        }

        private void userdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
