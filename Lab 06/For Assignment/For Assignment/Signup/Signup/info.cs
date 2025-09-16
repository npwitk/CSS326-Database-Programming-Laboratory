using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signup
{
    public class info
    {
        public int ID { set; get; }
        public string? FName { set; get; }
        public string? LName { set; get; }
        public string? Sex { set; get; }
        public string? Bdate { set; get; }
        public string? Email { set; get; }
        public string? Occup { set; get; }

    }

    public class login
    {
        public int UserID { get; set; }
        public int SignupID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
