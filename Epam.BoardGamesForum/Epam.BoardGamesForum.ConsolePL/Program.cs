using System;
using System.Security.Cryptography;
using System.Text;
using Epam.BoardGamesForum.BLL;
using Epam.BoardGamesForum.SqlDAL;

namespace Epam.BoardGamesForum.ConsolePL
{
    class Program
    {

        static void Main(string[] args)
        {
            ThemesLogic themesLogic = new ThemesLogic();
            themesLogic.AddTheme("TestTheme3");
            themesLogic.AddTheme("TestTheme2");
        }
    }
}
