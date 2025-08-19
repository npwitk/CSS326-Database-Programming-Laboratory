using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    // Create properties from the fields (Inputs)  of form1 (access them from other classes as well)
    public class User
    {
        public string title { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string userGroup { get; set; }

        public User() { }
        public User(string title, string firstName, string lastName, string email, string userGroup)
        {
            this.title = title;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.userGroup = userGroup;
        }
    }
}
