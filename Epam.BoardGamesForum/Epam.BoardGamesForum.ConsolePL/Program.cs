using System;
using System.Security.Cryptography;
using System.Text;
using Epam.BoardGamesForum.BLL;

namespace Epam.BoardGamesForum.ConsolePL
{
    class Program
    {

        static void Main(string[] args)
        {
            UsersLogic usersLogic = new UsersLogic();
            Guid guid = new Guid("66BCF2F1-70B0-8AAC-33E7-3FAF63A87C37");
            usersLogic.DeleteUser(guid);
        }
    }
}
