using System.Threading.Tasks;
using SecuritySobolDori.Labs567.DAL.Entities;

namespace SecuritySobolDori.Labs567.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Account> AccountRepository { get; set; }
        
        Task CommitAsync();
        Task RollbackAsync();
    }
}