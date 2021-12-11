using System.Threading.Tasks;

namespace SecuritySobolDori.Labs567.BLL.Interfaces
{
    public interface ISignUpService
    {
        Task<string> SignUp(string login, string password);
    }
}