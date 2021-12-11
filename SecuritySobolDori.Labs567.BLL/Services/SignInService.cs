using System;
using System.Linq;
using System.Threading.Tasks;
using SecuritySobolDori.Labs567.BLL.DTO;
using SecuritySobolDori.Labs567.BLL.Hashers;
using SecuritySobolDori.Labs567.BLL.Interfaces;
using SecuritySobolDori.Labs567.BLL.Mappers;
using SecuritySobolDori.Labs567.DAL.Interfaces;

namespace SecuritySobolDori.Labs567.BLL.Services
{
    public class SignInService : ISignInService
    {
        private readonly IUnitOfWork _unitOfWork;
        private AccountMapper _accountMapper;

        public SignInService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public AccountMapper AccountMapper => _accountMapper ??= new AccountMapper();

        public async Task<string> SignIn(string login, string password)
        {
            var entity = await _unitOfWork.AccountRepository.GetAllAsync();
            var account = entity.FirstOrDefault(_ => _.Login == login
                                                     && BCrypt.Net.BCrypt.Verify(password, _.Password));
            if (account is null)
            {
                throw new NullReferenceException();
            }
            return $"{Hasher.DecryptSensitiveData(account.Name)}, you've SignedIn!";
        }
    }
}