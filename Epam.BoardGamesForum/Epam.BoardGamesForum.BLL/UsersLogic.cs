using Epam.BoardGamesForum.Entities;
using Epam.BoardGamesForum.SqlDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.BoardGamesForum.BLL
{
    public class UsersLogic
    {
        UsersSqlDAL UsersSqlDAL = new UsersSqlDAL();
        public void AddUser(string login, string pass, string role)
        {
            string hashOfPass = HashGenerator.GenerateHash(pass).ToString();
            Guid id = HashGenerator.GenerateHash(login);
            User user = new User(id, login, hashOfPass, role);
            UsersSqlDAL.AddUser(user);
        }

        public void DeleteUser(Guid id)
        {
            UsersSqlDAL.DeleteUser(id);
        }

        public User GetUser(Guid id)
        {
            User user = UsersSqlDAL.GetUser(id);
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            return UsersSqlDAL.GetUsers();
        }
    }
}
