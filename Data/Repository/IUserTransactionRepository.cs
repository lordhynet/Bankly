using BANKLYFINANCIALAPP.Entities.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BANKLYFINANCIALAPP.Data.Repository
{
    public interface IUserTransactionRepository
    {
        Task<List<UserTransaction>> GetTransactionsByUserId(string userId);


    }
}
