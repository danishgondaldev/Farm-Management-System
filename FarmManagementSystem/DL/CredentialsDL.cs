using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmManagementSystem.BL;
using System.IO;

namespace FarmManagementSystem.BL
{
    class CredentialsDL
    {
        private static string path = "credentials.txt";

        private static List<CredentialsBL> usersList = new List<CredentialsBL>();

        internal static List<CredentialsBL> UsersList { get => usersList; set => usersList = value; }

        public static void addUserIntoList(CredentialsBL user)
        {
            UsersList.Add(user);
        }

        public static CredentialsBL SignIn(CredentialsBL user)
        {
            foreach (CredentialsBL storedUser in UsersList)
            {
                if (storedUser.UserName == user.UserName && storedUser.UserPassword == user.UserPassword)
                {
                    return storedUser;
                }
            }
            return null;
        }

        public static bool chkName(CredentialsBL user)
        {
            foreach (var storedUser in usersList)
            {
                if (user.UserName == storedUser.UserName)
                {
                    return false;
                }
            }
            return true;
        }

        public static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        public static bool readDataFromFile()
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string userName = parseData(record, 1);
                    string userPassword = parseData(record, 2);
                    string userRole = parseData(record, 3);
                    CredentialsBL user = new CredentialsBL(userName, userPassword, userRole);
                    addUserIntoList(user);
                }
                fileVariable.Close();
                return true;
            }
            else
                return false;
        }

        public static void storeUserIntoFile(CredentialsBL user)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(user.UserName + "," + user.UserPassword + "," + user.UserRole);
            file.Flush();
            file.Close();

        }
    }
}
