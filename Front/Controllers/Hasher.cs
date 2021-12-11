using System.Security.Cryptography;
using System.Text;

namespace Front.Controllers
{
    public static class Hasher
    {
        private static SHA512 _sha512 = SHA512.Create();
        public static string HashPassword(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            var result = _sha512.ComputeHash(bytes);
            return Encoding.UTF8.GetString(result);
        }
    }
}