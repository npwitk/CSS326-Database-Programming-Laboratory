using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LoginForms
{
    public class Student
    {
        public string Name { get; set; }
        public string StudentId { get; set; }
        public string School { get; set; }
        public string Location { get; set; }
        public string Level { get; set; } // BSc or MSc
        public string ConferenceTopics { get; set; }
        public DateTime SubmissionDate { get; set; }

        public Student() { }

        public Student(string name, string studentId, string school, string location, string level, string[] topics, DateTime submissionDate)
        {
            Name = name;
            StudentId = studentId;
            School = school;
            Location = location;
            Level = level;
            ConferenceTopics = string.Join(", ", topics);
            SubmissionDate = submissionDate;
        }
    }
}
