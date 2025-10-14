using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalEnglishIa
{
    public class UserManager
    {
        private const string userFilePath = "../../users.db";
        private List<User> Users { get; set; }

        public UserManager()
        {
            this.ReadUsersFile();
        }

        public bool AddUser(User user)
        {
            if (this.Users.Any(u => u.Email == user.Email))
            {
                return false; // User already exists
            }

            this.Users.Add(user);

            this.UsersToFile();

            return true;
        }

        public User LoginUser (string Email,string Password)
        {
            User user = this.Users.Find(u => u.Email == Email && u.Pass == Password);
            return user;

        }

        private void ReadUsersFile() 
        {
            if (File.Exists(userFilePath))
            {
                string fileContents = File.ReadAllText(userFilePath);
                this.Users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(fileContents);

            }

            else
            {
                this.Users = new List<User>();

            }
        }

        private void UsersToFile()
        {
            string fileContents = Newtonsoft.Json.JsonConvert.SerializeObject(this.Users);
            File.WriteAllText(userFilePath, fileContents);
        }
    }
}
