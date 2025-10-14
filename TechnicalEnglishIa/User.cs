using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalEnglishIa
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Pass { get; set; }
        public string ConfirmPass { get; set; }

        // Constructor principal
        public User(string firstName, string lastName, string userName, string email, string gender, string pass, string confirmPass)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            Gender = gender;
            Pass = pass;
            ConfirmPass = confirmPass;
        }

        // Constructor vacío
        public User() { }
    }
}
