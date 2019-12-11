using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account("David", 5000, 13);
            Console.WriteLine($"Account {account.AccountNumber} was created for {account.Owner} with {account.Balance} balance.");
           
            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
          
            account.MakeDeposit(100, DateTime.Now, "friend paid me back");
           
           
            account.AddInterests(0.10, DateTime.Now, "rate is increese 10");
           
            Console.WriteLine(account.AccountHistory());

            // Test exceptions
            try
            {
                var invalidAccount = new Account("invalid", -80, 12);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
            }

            // Test for a negative balance
            try
            {
                account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }

            try 
            {
                account.AddInterests(23, DateTime.Now, "Interest rate is out of range!");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught using high rate");
                Console.WriteLine(e.ToString());
            }

            Console.ReadLine();
        }
    }
}
