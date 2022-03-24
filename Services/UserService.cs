using AutoMapper;
using BANKLYFINANCIALAPP.Data.Repository;
using BANKLYFINANCIALAPP.Entities.Dto;
using BANKLYFINANCIALAPP.Entities.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BANKLYFINANCIALAPP.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepo = userRepository;
            _mapper = mapper;

        }

        public async Task<string> AddUser(RegistrationDto model)
        {
            var user = _mapper.Map<User>(model);
            var res = await _userRepo.AddUser(user);
            if (res)
            {
                return user.AccountNo;
            }
            else
            {
                return "unsuccesful";
            }


        }

        public async Task<string> DeleteUser(string UserId)
        {
            var user = await _userRepo.GetUser(UserId);
            if (user == null)
            {
                return "user does not exist";
            }
            var res = await _userRepo.DeleteUser(user);
            if (!res)
            {
                return "cannt delete user";
            }
            else
            {
                return "deleted successful";
            }


        }

        public async Task<User> GetUser(string UserId)
        {
            var user = await _userRepo.GetUser(UserId);
            return user;


        }

        public async Task<List<User>> GetUsers()
        {
            return await _userRepo.GetUsers();
        }

        public async Task<User> UpdateUser(string UserId, UpdateUserDto model)
        {
            var user = await _userRepo.GetUser(UserId);
            if (user == null)
            {
                return null;
            }
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.EmailAddress;
            var res = await _userRepo.UpdateUser(user);
            if (res)
            {
                return user;
            }
            return null;
        }
    }
}
