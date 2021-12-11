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

        public async Task SignUp(AccountDTO accountDto)
        {
            var entity = AccountMapper.Map(accountDto);
            entity.Password = Hasher.HashPassword(entity.Password);
            entity.Email = Hasher.EncryptSensitiveData(entity.Email);
            entity.PhoneNumber = Hasher.EncryptSensitiveData(entity.PhoneNumber);
            entity.Name = Hasher.EncryptSensitiveData(entity.Name);
            entity.Surname = Hasher.EncryptSensitiveData(entity.Surname);
            await _unitOfWork.AccountRepository.InsertAsync(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}