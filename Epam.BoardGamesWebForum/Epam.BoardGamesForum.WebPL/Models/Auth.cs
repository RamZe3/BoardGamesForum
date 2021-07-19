using Epam.BoardGamesForum.BLL;
using Epam.BoardGamesForum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.BoardGamesForum.WebPL.Models
{
    public class Auth
    {
        private static UsersLogic _usersLogic { get; } = new UsersLogic();
        public static bool CanLogin(string Login, string Password)
        {
            User user = _usersLogic.GetUser(Login);
            if (user.hashOfPass == HashGenerator.GenerateHash(Password).ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CanRegister(string Login)
        {
            try
            {
                User user = _usersLogic.GetUser(Login);
                return false;
            }
            catch 
            {
                return true;
            }
        }
    }
}