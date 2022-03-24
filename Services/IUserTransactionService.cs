using BANKLYFINANCIALAPP.Entities.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BANKLYFINANCIALAPP.Services
{
    public interface IUserTransactionService
    {

        Task<List<UserTransactionDto>> GetTransactionsByUserID(string userId);
        Task<string> GetTransactionsAsPdf(string userId);
    }
}
