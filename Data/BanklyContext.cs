using BANKLYFINANCIALAPP.Entities.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BANKLYFINANCIALAPP.Data
{
    public class BanklyContext : IdentityDbContext<User>
    {
        public BanklyContext(DbContextOptions<BanklyContext> options) : base(options)
        {

        }
        public DbSet<UserTransaction> UserTransactions { get; set; }
    }
}
