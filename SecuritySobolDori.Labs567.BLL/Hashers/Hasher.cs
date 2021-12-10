using SecuritySobolDori.Labs567.BLL.Interfaces;

namespace SecuritySobolDori.Labs567.BLL.Hashers
{
    public static class Hasher
    {
        public static string HashPassword(string password)
        {
            password += 1;
            return password;
        }
    }
}