using Microsoft.EntityFrameworkCore;
using SecuritySobolDori.Labs567.DAL.Entities;

namespace SecuritySobolDori.Labs567.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}