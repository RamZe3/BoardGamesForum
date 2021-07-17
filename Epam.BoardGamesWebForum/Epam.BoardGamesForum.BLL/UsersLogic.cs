using Epam.BoardGamesForum.Entities;
using Epam.BoardGamesForum.SqlDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.BoardGamesForum.BLL
{
    public class UsersLogic
    {
        //id = Hash of Login

        UsersSqlDAL UsersSqlDAL = new UsersSqlDAL();
        public void AddUser(string login, string pass, string role)
        {
            string hashOfPass = HashGenerator.GenerateHash(pass).ToString();
            Guid id = HashGenerator.GenerateHash(login);
            User user = new User(id, login, hashOfPass, role);
            UsersSqlDAL.AddUser(user);
        }

        public void DeleteUser(string login)
        {
            Guid id = HashGenerator.GenerateHash(login);
            UsersSqlDAL.DeleteUser(id);
        }

        public User GetUser(string login)
        {
            Guid id = HashGenerator.GenerateHash(login);
            User user = UsersSqlDAL.GetUser(id);
            return user;
        }

        public void EditUser(string login, User editUser)
        {
            Guid id = HashGenerator.GenerateHash(login);
            UsersSqlDAL.DeleteUser(id);
            UsersSqlDAL.AddUser(editUser);
        }

        public User GetUser(Guid loginId)
        {
            try
            {
                User user = UsersSqlDAL.GetUser(loginId);
                return user;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<User> GetUsers()
        {
            return UsersSqlDAL.GetUsers();
        }

        public void EditUser(string Login, string newLogin, string newPass)
        {
            Guid id = HashGenerator.GenerateHash(Login);
            Guid newId = HashGenerator.GenerateHash(newLogin);
            string newHashOfPass = HashGenerator.GenerateHash(newPass).ToString();
            UsersSqlDAL.EditUser(id, newId, newLogin, newHashOfPass);
        }
    }
}
