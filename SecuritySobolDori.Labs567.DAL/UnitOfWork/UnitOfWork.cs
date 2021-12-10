using System;
using System.Threading.Tasks;
using SecuritySobolDori.Labs567.DAL.Context;
using SecuritySobolDori.Labs567.DAL.Entities;
using SecuritySobolDori.Labs567.DAL.Interfaces;
using SecuritySobolDori.Labs567.DAL.Repositories;

namespace SecuritySobolDori.Labs567.DAL.UnitOfWork
{
    public class UnitOfWork
    {
        private ApplicationDbContext _context;

        private IRepository<Account> _accountRepository;
        public IRepository<Account> AccountRepository => _accountRepository ??= new GenericRepository<Account>(_context);

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

        }


        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task RollbackAsync()
        {
            await _context.DisposeAsync();
        }

        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
    }
}