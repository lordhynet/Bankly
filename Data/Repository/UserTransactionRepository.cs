using BANKLYFINANCIALAPP.Entities.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BANKLYFINANCIALAPP.Data.Repository
{
    public class UserTransactionRepository : IUserTransactionRepository
    {
        private readonly BanklyContext _context;

        public UserTransactionRepository(BanklyContext context)
        {
            _context = context;
        }

        public async Task<List<UserTransaction>> GetTransactionsByUserId(string userId)
            => await _context.UserTransactions.Where(x => x.UserId == userId).ToListAsync();
    }
}
