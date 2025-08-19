namespace _02_LoginForms
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            studentBindingSource = new BindingSource(components);
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            studentIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            schoolDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            locationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            levelDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            conferenceTopicsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            submissionDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)studentBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn, studentIdDataGridViewTextBoxColumn, schoolDataGridViewTextBoxColumn, locationDataGridViewTextBoxColumn, levelDataGridViewTextBoxColumn, conferenceTopicsDataGridViewTextBoxColumn, submissionDateDataGridViewTextBoxColumn });
            dataGridView1.DataSource = studentBindingSource;
            dataGridView1.Location = new Point(12, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.RowTemplate.Height = 41;
            dataGridView1.Size = new Size(1557, 976);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // studentBindingSource
            // 
            studentBindingSource.DataSource = typeof(Student);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.MinimumWidth = 10;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.Width = 200;
            // 
            // studentIdDataGridViewTextBoxColumn
            // 
            studentIdDataGridViewTextBoxColumn.DataPropertyName = "StudentId";
            studentIdDataGridViewTextBoxColumn.HeaderText = "StudentId";
            studentIdDataGridViewTextBoxColumn.MinimumWidth = 10;
            studentIdDataGridViewTextBoxColumn.Name = "studentIdDataGridViewTextBoxColumn";
            studentIdDataGridViewTextBoxColumn.Width = 200;
            // 
            // schoolDataGridViewTextBoxColumn
            // 
            schoolDataGridViewTextBoxColumn.DataPropertyName = "School";
            schoolDataGridViewTextBoxColumn.HeaderText = "School";
            schoolDataGridViewTextBoxColumn.MinimumWidth = 10;
            schoolDataGridViewTextBoxColumn.Name = "schoolDataGridViewTextBoxColumn";
            schoolDataGridViewTextBoxColumn.Width = 200;
            // 
            // locationDataGridViewTextBoxColumn
            // 
            locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            locationDataGridViewTextBoxColumn.HeaderText = "Location";
            locationDataGridViewTextBoxColumn.MinimumWidth = 10;
            locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            locationDataGridViewTextBoxColumn.Width = 200;
            // 
            // levelDataGridViewTextBoxColumn
            // 
            levelDataGridViewTextBoxColumn.DataPropertyName = "Level";
            levelDataGridViewTextBoxColumn.HeaderText = "Level";
            levelDataGridViewTextBoxColumn.MinimumWidth = 10;
            levelDataGridViewTextBoxColumn.Name = "levelDataGridViewTextBoxColumn";
            levelDataGridViewTextBoxColumn.Width = 200;
            // 
            // conferenceTopicsDataGridViewTextBoxColumn
            // 
            conferenceTopicsDataGridViewTextBoxColumn.DataPropertyName = "ConferenceTopics";
            conferenceTopicsDataGridViewTextBoxColumn.HeaderText = "ConferenceTopics";
            conferenceTopicsDataGridViewTextBoxColumn.MinimumWidth = 10;
            conferenceTopicsDataGridViewTextBoxColumn.Name = "conferenceTopicsDataGridViewTextBoxColumn";
            conferenceTopicsDataGridViewTextBoxColumn.Width = 200;
            // 
            // submissionDateDataGridViewTextBoxColumn
            // 
            submissionDateDataGridViewTextBoxColumn.DataPropertyName = "SubmissionDate";
            submissionDateDataGridViewTextBoxColumn.HeaderText = "SubmissionDate";
            submissionDateDataGridViewTextBoxColumn.MinimumWidth = 10;
            submissionDateDataGridViewTextBoxColumn.Name = "submissionDateDataGridViewTextBoxColumn";
            submissionDateDataGridViewTextBoxColumn.Width = 200;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1569, 991);
            Controls.Add(dataGridView1);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)studentBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn studentIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn schoolDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn levelDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn conferenceTopicsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn submissionDateDataGridViewTextBoxColumn;
        private BindingSource studentBindingSource;
    }
}