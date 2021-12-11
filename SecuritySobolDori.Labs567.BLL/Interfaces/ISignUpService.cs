using System.Threading.Tasks;
using SecuritySobolDori.Labs567.BLL.DTO;

namespace SecuritySobolDori.Labs567.BLL.Interfaces
{
    public interface ISignUpService
    {
        Task SignUp(AccountDTO accountDto);
    }
}