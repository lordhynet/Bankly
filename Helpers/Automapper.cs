using AutoMapper;
using BANKLYFINANCIALAPP.Entities.Dto;
using BANKLYFINANCIALAPP.Entities.Model;

namespace BANKLYFINANCIALAPP.Helpers
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<UserTransaction, UserTransactionDto>();
            CreateMap<RegistrationDto, User>();
            CreateMap<UpdateUserDto, User>();
        }
    }
}
