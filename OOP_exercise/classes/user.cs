using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_exercise
{

    public class Teacher
    {
        public Teacher(string _username, string _password)
        {
            username = _username;
            password = _password;
        }

        internal string username { get; set; }
        public string password { get; set; }
    }

}
