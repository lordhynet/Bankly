using BANKLYFINANCIALAPP.Entities.Dto;
using BANKLYFINANCIALAPP.Entities.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BANKLYFINANCIALAPP.Services
{
    public interface IUserService
    {
        Task<User> GetUser(string UserId);
        Task<List<User>> GetUsers();
        Task<string> AddUser(RegistrationDto model);

        Task<string> DeleteUser(string UserId);

        Task<User> UpdateUser(string UserId, UpdateUserDto model);
    }



}
