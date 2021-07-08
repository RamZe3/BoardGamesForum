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
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(HashGenerator.GenerateHash("asd"));

            Console.WriteLine(HashGenerator.GenerateHash());
        }
    }
}
