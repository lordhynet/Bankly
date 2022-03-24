using BANKLYFINANCIALAPP.Entities.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BANKLYFINANCIALAPP.Data.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUser(string UserId);
        Task<List<User>> GetUsers();
        Task<bool> AddUser(User user);
        Task<bool> DeleteUser(User user);
        Task<bool> UpdateUser(User user);
    }
}
