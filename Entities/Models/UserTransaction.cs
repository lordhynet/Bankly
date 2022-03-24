using System;

namespace BANKLYFINANCIALAPP.Entities.Model
{
    public class UserTransaction
    {

        public long Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Reference { get; set; }
        public string TransactionType { get; set; }
        public string Description { get; set; }
        public string Narration { get; set; }
        public decimal Amount { get; set; }
        public string DebitAccountNo { get; set; }
        public string CreditAccountNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionBy { get; set; }
        public string DebitAccountUserId { get; set; }
        public string CreditAccountUserId { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }



    }
}
