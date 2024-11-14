using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer
{
     public class UserManager
    {
        public bool AddUser(string name, string phoneNumber, string email)
        {
            if (name.Length < 4) return false;
            if (!Regex.IsMatch(phoneNumber, "[0-9]")) return false;
            if (!email.Contains('@')) return false;

            return true;

        }
    }
}
