using AutoMapper;
using BANKLYFINANCIALAPP.Data.Repository;
using BANKLYFINANCIALAPP.Entities.Dto;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKLYFINANCIALAPP.Services
{
    public class UserTransactionService : IUserTransactionService
    {

        private readonly IUserTransactionRepository _transRepo;
        private readonly IMapper _mapper;

        public UserTransactionService(IUserTransactionRepository transRepo, IMapper mapper)
        {
            _transRepo = transRepo;
            _mapper = mapper;
        }

        public async Task<string> GetTransactionsAsPdf(string userId)
        {
            var builder = new StringBuilder();
            var header = $"Id,Reference,TransactionType,Description,Narration," +
                    $"Amount,DebitAccountNo,CreditAccountNo,TransactionDate,TransactionBy," +
                    $"DebitAccountUserId,CreditAccountUserId,SenderName,ReceiverName\n";
            builder.Append(header);
            var transactions = await _transRepo.GetTransactionsByUserId(userId);
            foreach (var transaction in transactions)
            {
                string trans = string.Empty;
                trans = $"{transaction.Id},{transaction.Reference},{transaction.TransactionType},{transaction.Description},{transaction.Narration}," +
                    $"{transaction.Amount},{transaction.DebitAccountNo},{transaction.CreditAccountNo},{transaction.TransactionDate},{transaction.TransactionBy}," +
                    $"{transaction.DebitAccountUserId},{transaction.CreditAccountUserId},{transaction.SenderName},{transaction.ReceiverName}\n";
                builder.Append(trans);
            }

            var directory = Directory.GetCurrentDirectory();
            var path = string.Join("/", directory, "transaction.txt");
            File.WriteAllText(path, builder.ToString());
            return path;
        }

        public async Task<List<UserTransactionDto>> GetTransactionsByUserID(string userId)
        {
            var transactions = await _transRepo.GetTransactionsByUserId(userId);
            return _mapper.Map<UserTransactionDto[]>(transactions).ToList();
        }
    }
}
