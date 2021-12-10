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

        public async Task SignIn(AccountDTO accountDto)
        {
            var entity = AccountMapper.Map(accountDto);
            entity.Password = Hasher.HashPassword(entity.Password);
            await _unitOfWork.AccountRepository.InsertAsync(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}