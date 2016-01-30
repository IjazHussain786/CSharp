using System.Security.Cryptography;
using System.Text;

namespace Buls.Utilities
{
    public static class HashUtilities
    {
        public static string HashPassword(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            var sha1 = SHA1.Create();
            byte[] hashedBytes = sha1.ComputeHash(bytes);
            
            return HexStringFromBytes(hashedBytes);
        }

        private static string HexStringFromBytes(byte[] bytes)
        {
            var result = new StringBuilder();
            foreach (byte b in bytes)
            {
                result.Append(b.ToString("x2"));
            }
            
            return result.ToString();
        }
    }
}