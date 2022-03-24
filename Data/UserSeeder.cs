using BANKLYFINANCIALAPP.Data;
using BANKLYFINANCIALAPP.Entities.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BANKLYFINANCIALAPP
{
    public class UserSeeder
    {
        private readonly BanklyContext _context;


        public UserSeeder(BanklyContext context)
        {
            _context = context;

        }

        public async Task SeedInData(string envName)
        {
            _context.Database.EnsureCreated();

            var path_UserSeeds = @"./Seeds.json";

            var userData = File.ReadAllText(path_UserSeeds);
            var users = JsonSerializer.Deserialize<List<User>>(userData);
            if (!_context.Users.Any())
            {
                _context.Users.AddRange(users);
                await _context.SaveChangesAsync();


            }

            _context.SaveChanges();



        }
    }
}
