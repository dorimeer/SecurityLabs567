using System.Text;
using Konscious.Security.Cryptography;
using SecuritySobolDori.Labs567.BLL.Interfaces;

namespace SecuritySobolDori.Labs567.BLL.Hashers
{
    public static class Hasher
    {
        private static byte[] _salt = Encoding.UTF8.GetBytes("some_salt");
        public static string HashPassword(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = new Argon2id(bytes);
            hash.Salt = _salt;
            hash.Iterations = 40;
            hash.DegreeOfParallelism = 16;
            hash.MemorySize = 8192;
            return Encoding.UTF8.GetString(hash.GetBytes(40));
        }
    }
}