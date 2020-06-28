using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Text;
using Bank;
using Bank.Models;

namespace Bank.Models
{
    public static class BankExtention
    {
        static public List<Account> FilterExtention (this List<Account> acc,Func<Account,bool> f) // расширение листа типа Account делегатом Funс, который принимает Account и выдает true или false
        {
            var result = new List<Account>(); // result - новый лист типа Account в который будут добавляться аккаунты соответствующие условию
            foreach (var a in acc)
            {
                if (f(a)) //bool, поскольку Func возвращает bool. сюда делегируется условие из program.cs
                {
                    result.Add(a);
                }
            }
            return result;
        }
        static public List<Account> PredicateFilterExtention(this List<Account> acc, Predicate<Account> f) // Predicate по умолчанию выдает true или false
        {
            var result = new List<Account>();
            foreach (var a in acc)
            {
                if (f(a))
                {
                    result.Add(a);
                }
            }
            return result;
        }

        /*
        static public decimal SummExtention(this List<Account> acc, Func<Account, decimal> f) // Этот метод не нужен, можно через Linq
        {          
            decimal summ = 0;
            foreach (var a in acc)
            {
                summ += f(a);
                
            }
            return summ;
        }
        */
    }


    
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
