using Epam.BoardGamesForum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.BoardGamesForum.BLL.Interfaces
{
    public interface IUsersLogic
    {
        void AddUser(string login, string pass, string role);
        void DeleteUser(string login);
        User GetUser(string login);
        void EditUser(string login, User editUser);
        User GetUser(Guid loginId);
        IEnumerable<User> GetUsers();
        void EditUser(string Login, string newLogin, string newPass);
    }
}
