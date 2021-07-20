using Epam.BoardGamesForum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.BoardGamesForum.DAL.Interfaces
{
    public interface IUsersDAL
    {
        User AddUser(User user);
        void DeleteUser(Guid id);
        IEnumerable<User> GetUsers();
        User GetUser(Guid id);
        void EditUser(Guid id, Guid newId, string newLogin, string newHashOfPass);

    }
}
