using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_LoginForms
{
    public partial class Form2 : Form
    {
        public Form2(List<Student> students)
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = students;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
