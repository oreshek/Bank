using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Text;
using Bank;
using Bank.Models;

namespace Bank.Models
{
    public class Bank
    {

        public delegate Boolean dFilter(Account a);
        public List<Account> accounts { get;} = new List<Account>(); 
        public Bank(string bankname)
        {

            BankName = bankname;

        } 
        
        public string BankName { get; }

       
        public void AddAccount (Account account)
        {
            accounts.Add(account);
             // foreach (var a in accounts )        
          //  var bank = new List<Account>();
        }

       public List<Account>GetNegativeBalanceAccounts()
        {
            var result = new List<Account>();
            foreach (var a in accounts)
            {
                if (a.Balance < 0)
                {
                    result.Add(a);
                }
            }
            return result;
        }

        public List<Account> FilterByBalance(decimal balance)
        {
            var result = new List<Account>();
            foreach (var a in accounts)
            {
                if (a.Balance > balance)
                {
                    result.Add(a);
                }
            }
            return result;
        }

        public List<Account>Filter (dFilter c)
        {
            var result = new List<Account>();
            foreach (var a in accounts)
            {
                if (c(a))                        
                {
                    result.Add(a);
                }
            }
            return result;
        }

        public decimal SummFilter(dFilter c) //Сумма балансов аккаунтов при соблюдении условия
        {
            var result = new List<Account>();
            decimal summ = 0;
            foreach (var a in accounts)
            {
                if (c(a))
                {
                    summ += a.Balance;
                }
            }
            return summ;
        }




    }
}
