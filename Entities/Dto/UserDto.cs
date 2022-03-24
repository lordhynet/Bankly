using System.Collections.Generic;

namespace BANKLYFINANCIALAPP.Entities.Dto
{
    public class UserDto
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string AccountNo { get; set; }
        public List<UserTransactionDto> userTransactionDtos { get; set; }
        public UserDto()
        {
            userTransactionDtos = new List<UserTransactionDto>();
        }
    }
}
