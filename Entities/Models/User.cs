using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BANKLYFINANCIALAPP.Entities.Model
{
    public class User : IdentityUser
    {
        public string UserId { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountNo { get; set; } = new Random().Next(1111111111, 222222222).ToString();
        public List<Account> Accounts { get; set; }
        public List<UserTransaction> UserTransactions { get; set; }
        public User()
        {
            Accounts = new List<Account>();
            UserTransactions = new List<UserTransaction>();
        }

    }
}
