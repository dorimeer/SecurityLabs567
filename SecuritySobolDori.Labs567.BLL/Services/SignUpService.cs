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
    public class SignUpService : ISignUpService
    {
        private readonly IUnitOfWork _unitOfWork;
        private AccountMapper _accountMapper;

        public SignUpService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public AccountMapper AccountMapper => _accountMapper ??= new AccountMapper();

        public async Task<string> SignUp(string login, string password)
        {
            var entity = await _unitOfWork.AccountRepository.GetAllAsync();
            var account = entity.FirstOrDefault(_ => _.Login == login 
                                                     && _.Password == Hasher.HashPassword(password));
            if (account is null)
            {
                throw new NullReferenceException();
            }
            return $"{account.Login}, you've SignedIn!";
        }
    }
}