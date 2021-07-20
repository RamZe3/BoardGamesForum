using Epam.BoardGamesForum.Entities;
using Epam.BoardGamesForum.SqlDAL;
using System;
using System.Collections.Generic;
using System.Text;
using Epam.BoardGamesForum.BLL.Interfaces;
using Epam.BoardGamesForum.DAL.Interfaces;

namespace Epam.BoardGamesForum.BLL
{
    public class UsersLogic : IUsersLogic
    {
        //id = Hash of Login

        private IUsersDAL _UsersDAL;

        public UsersLogic(IUsersDAL usersDAL)
        {
            _UsersDAL = usersDAL;
        }

        public void AddUser(string login, string pass, string role)
        {
            string hashOfPass = HashGenerator.GenerateHash(pass).ToString();
            Guid id = HashGenerator.GenerateHash(login);
            User user = new User(id, login, hashOfPass, role);
            _UsersDAL.AddUser(user);
        }

        public void DeleteUser(string login)
        {
            Guid id = HashGenerator.GenerateHash(login);
            _UsersDAL.DeleteUser(id);
        }

        public User GetUser(string login)
        {
            Guid id = HashGenerator.GenerateHash(login);
            User user = _UsersDAL.GetUser(id);
            return user;
        }

        public void EditUser(string login, User editUser)
        {
            Guid id = HashGenerator.GenerateHash(login);
            _UsersDAL.DeleteUser(id);
            _UsersDAL.AddUser(editUser);
        }

        public User GetUser(Guid loginId)
        {
            try
            {
                User user = _UsersDAL.GetUser(loginId);
                return user;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<User> GetUsers()
        {
            return _UsersDAL.GetUsers();
        }

        public void EditUser(string Login, string newLogin, string newPass)
        {
            Guid id = HashGenerator.GenerateHash(Login);
            Guid newId = HashGenerator.GenerateHash(newLogin);
            string newHashOfPass = HashGenerator.GenerateHash(newPass).ToString();
            _UsersDAL.EditUser(id, newId, newLogin, newHashOfPass);
        }
    }
}
