using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeMidterm
{
    class Logins
    {
        private int id;
        private string username;
        private string password;
        private int superUser;
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }

        public string Username
        {
            get { return username; }
            set { this.username = value; }
        }

        public string Password
        {
            get { return password; }
            set { this.password = value; }
        }
        public int SuperUser
        {
            get { return superUser; }
            set { this.superUser = value; }
        }

        //parameterized constructor
        public Logins(int id, string username, string password, int superUser)
        {
            Id = id;
            Username = username;
            Password = password;
            SuperUser = superUser;
        }

        public Logins()
        {

        }

    }
    internal enum UserStatus
    {
        RegularUser,
        SuperUser
    }
}
