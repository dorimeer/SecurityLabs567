using System.Threading.Tasks;
using SecuritySobolDori.Labs567.BLL.DTO;

namespace SecuritySobolDori.Labs567.BLL.Interfaces
{
    public interface ISignInService
    {
        Task SignIn(AccountDTO accountDto);
    }
}