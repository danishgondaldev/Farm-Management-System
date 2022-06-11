using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagementSystem.BL
{
    class CredentialsBL
    {
        private string userName;
        private string userPassword;
        private string userRole;

        public string UserName { get => userName; set => userName = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }
        public string UserRole { get => userRole; set => userRole = value; }

        public CredentialsBL(string userName, string userPassword, string userRole)
        {
            this.UserName = userName;
            this.UserPassword = userPassword;
            this.UserRole = userRole;
        }

        public CredentialsBL(string userName, string userPassword)
        {
            this.UserName = userName;
            this.UserPassword = userPassword;
            this.UserRole = "NA";
            this.UserRole = userRole;
        }
        public bool isAdmin()
        {
            if (UserRole == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
