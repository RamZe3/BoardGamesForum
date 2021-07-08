using System;
using System.Security.Cryptography;
using System.Text;

namespace Epam.BoardGamesForum.BLL
{
    public static class HashGenerator
    {
        public static string GenerateHash(string str)
        {
            using (var md5Hasher = MD5.Create())
            {
                var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(str));
                return BitConverter.ToString(data).Replace("-", "").Substring(0, 16);
            }
        }

        public static string GenerateHash()
        {
            var bytes = new byte[8];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }

            string hash = BitConverter.ToString(bytes).Replace("-", "").ToLower();

            return hash;
        }
    }
}
