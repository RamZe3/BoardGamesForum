using System;
using System.Security.Cryptography;
using System.Text;

namespace Epam.BoardGamesForum.BLL
{
    public static class HashGenerator
    {
        public static Guid GenerateHash(string str)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(str));
                Guid result = new Guid(hash);
                return result;
            }
        }

        public static Guid GenerateHash()
        {
            return Guid.NewGuid();
        }
    }
}
