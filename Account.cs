using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Account
    {
        //fields

        protected double interestRate;
        protected string owner;
        protected double balance;
        private double accountNumber;
       
        Random rand = new Random();
        
        private List<BankTransaction> allTransactions = new List<BankTransaction>();
      
        //properties
              
        public string AccountNumber { get; }
        public string Owner{get;set;  }
        
        public double Balance
        {
            get
            {
                balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }
        public double AcctNumber
        {
            get
            { return this.accountNumber; }
        }
       
        
        public Account(string owner,double ibalance, double ir)
        {
            this.interestRate = ir;
            this.owner = owner;
            //this.balance = balance;
            this.accountNumber = rand.Next(100000000, 999000000);
            MakeDeposit(ibalance, DateTime.Now, "Initial balance");
        }
        //methods
        public void AddInterests(double interestRate, DateTime date, string note)
        {
            if (interestRate > 0 && interestRate <= 22)
            {
                balance += balance * interestRate;

                var item = new BankTransaction(balance, date, note);

                allTransactions.Add(item);
            }
            else
            { throw new ArgumentOutOfRangeException(nameof(interestRate), "The interestRate is out of range"); }
        }
        

        public void MakeDeposit(double amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new BankTransaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(double amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new BankTransaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }
        public string AccountHistory()
        {
            var report = new System.Text.StringBuilder();

            report.AppendLine("Date\tAmount\tNote");
            foreach (var item in allTransactions)
            {
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
            }

            return report.ToString();
        }
    }
}
