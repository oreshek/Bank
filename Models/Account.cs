using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Models
{

    public enum AccountStatus
    {
        Active,
        Inactive
    }



   public class Account
    {

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public decimal Balance { get; set; }

        public AccountStatus Status { get; private set; } 

        public LinkedList<string> TransactionHistory { get; private set; } = new LinkedList<string>();


        public void Deposit (decimal value)
        {
            Balance += value;
            var a = $"Аккаунт {FirstName} был пополнен на: {value}, текущий баланс {Balance}";
            TransactionHistory.AddLast(a);
            Console.WriteLine(a);


        }

        public void Withdraw (decimal value)
        {
            Balance -= value;
            var a = $"Снятие со счёта суммы: {value}, текущий баланс {Balance}";
            TransactionHistory.AddLast(a);
            Console.WriteLine(a);
        }

        


    }
}
