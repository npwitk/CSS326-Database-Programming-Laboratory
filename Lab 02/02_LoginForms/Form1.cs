using System.Windows.Forms;

namespace _02_LoginForms
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.DataGridView dataGridView1;
        private List<Student> students = new List<Student>();
        public Form1()
        {
            InitializeComponent();
        }


        private void submitButton_Click(object sender, EventArgs e)
        {
            var selectedTopics = new List<string>();
            if (databaseCheckBox.Checked) selectedTopics.Add("Database Management");
            if (industrialCheckBox.Checked) selectedTopics.Add("Industrial 4.0");
            if (aiCheckBox.Checked) selectedTopics.Add("Artificial Intelligence");

            Student newStudent = new Student
            {
                Name = studentNameTextField.Text,
                StudentId = studentIdTextField.Text,
                School = schoolComboBox.SelectedItem?.ToString(),
                Location = locationComboBox.SelectedItem?.ToString(),
                Level = radioButton1.Checked ? "BSc" : (radioButton2.Checked ? "MSc" : "Unknown"),
                ConferenceTopics = string.Join(", ", selectedTopics),
                SubmissionDate = dateTimePicker1.Value
            };

            students.Add(newStudent);

            Form2 studentListForm = new Form2(students);
            studentListForm.Show();
        }
    }
}