using SecuritySobolDori.Labs567.BLL.DTO;
using SecuritySobolDori.Labs567.DAL.Entities;

namespace SecuritySobolDori.Labs567.BLL.Mappers
{
    public class AccountMapper : GenericMapper<Account, AccountDTO>
    {
        public override Account Map(AccountDTO dtoEntity)
        {
            return new Account()
            {
                Id = dtoEntity.Id,
                Name = dtoEntity.Name,
                Surname = dtoEntity.Surname,
                Email = dtoEntity.Email,
                PhoneNumber = dtoEntity.PhoneNumber,
                Password = dtoEntity.Password,
                Login = dtoEntity.Login
            };
        }

        public override AccountDTO Map(Account dataEntity)
        {
            return new AccountDTO()
            {
                Id = dataEntity.Id,
                Name = dataEntity.Name,
                Surname = dataEntity.Surname,
                Email = dataEntity.Email,
                PhoneNumber = dataEntity.PhoneNumber,
                Password = dataEntity.Password,
                Login = dataEntity.Login
            };
        }
    }
}