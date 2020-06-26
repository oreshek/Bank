using Bank.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;

namespace Bank
{
    public class Program
    {
        static void Main(string[] args)
        {

            var accounts = new List<Account>()
            {new Account() {FirstName="Oleg", Id = Guid.NewGuid()},
             new Account() {FirstName = "Gena", Id = Guid.NewGuid() },
             new Account() {FirstName = "Alex", Id = Guid.NewGuid() } };
             var where = accounts.Where(a => a.FirstName == "Oleg"); 
            List<string> names = new List<string>() {"Artem","Egor","Anastasia","Friend","Daria","Elena","Fridrih","Artem" }; // Лист имён

            for (int i = 0; i<8; i++) //Добавляем больше имён
            {
                accounts.Add(new Account() {FirstName = names.ElementAt(i), Id = Guid.NewGuid() }); // Создаётся новый аккаунт с именем из листа names
            }

            Random rnd = new Random();
            foreach (var a in accounts )
            {   
                  a.Deposit(rnd.Next(100));
            }

            foreach (var a in accounts) // рандомно делаем отрицательные счета
            {
                int minus = rnd.Next(0, 5);
                int minus2 = rnd.Next(3, 5);
                for (int i = minus; i < minus2; i++)
                {
                    a.Balance *= -1; // Для изменения баланса пришлось убрать private set у Balance( Вызвать метод снятия счёта)
                }
            }

            var myBank = new Bank.Models.Bank("Sberbank");

            foreach (var a in accounts)
            {
                myBank.AddAccount(a);

            }

            var negativeaccounts = myBank.GetNegativeBalanceAccounts();
            var filteredAccounts =  myBank.FilterByBalance(50);
            var filter = myBank.Filter((a) => { return  a.Balance > 50; }); // лямбда (упрощенное создание делегата с методом)
            var filter1 = myBank.Filter((a) => { return a.Balance < 0; });

            
            //  var filter1 = myBank.Filter(Condition);
            //   var filter2 = myBank.Filter(delegate (Account a) { return a.Balance > 50; });


            var filter3 = myBank.SummFilter(ConditionSumm);
            var filter4 = myBank.SummFilter((a) => { return a.Balance > 80; });
            var filter5 = myBank.SummFilter(delegate(Account a)  { return a.Balance > 80; });
            var filter6 = myBank.Filter((a) => { return (a.Balance > 40) && (a.Balance < 80); });

            var summ = from a in myBank.accounts select a.Balance;
           // myBank.accounts.Sum(summ);
                        

            foreach (var a in accounts)
            {
                Console.WriteLine($"Баланс {a.FirstName} составляет {a.Balance}");
            }
/*
            accounts.Sort(delegate (Account x, Account y))
            {
                return x.FirstName.CompareTo(y.FirstName);
            }

*/





        }
        public static Boolean Condition(Account a)
        {
            return a.Balance > 50;
        }

        public static Boolean ConditionSumm(Account a)
        {
            return a.Balance > 80; 
            
        }
        /*
        Console.WriteLine("Choose \n 1 Create Account \n 2 Delete Account \n 3 Open database \n 4 Get money summ \n 5 Exit" );
         int a = Convert.ToInt32(Console.ReadLine()); ;
            switch (a)
            {
                case 1:
                    Acc.CreateAccount();
                    break;
                case 2:
                    Acc.DeleteAccount();
                    break;
                case 3:
                    Acc.ShowData();
                    break;
                case 4:
                    Acc.GetMoneySumm();
                    break;
                case 5:
               //     On = false;
                    break;
            }
            */



    }
}
 
    


    

