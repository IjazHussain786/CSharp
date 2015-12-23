using P2Bank.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2Bank.Accounts
{
    public abstract class Account : IDepositMoney, ICalculateInterest
    {
        private decimal interestRate;
        private decimal balance;
        private DateTime startDate;
        public Account(Customer holder, decimal balance, decimal interestRate, AccountType accountType)
        {
            this.Holder = holder;
            this.Balance = balance;
            this.InterestRate = interestRate;
            this.startDate = DateTime.Now;
            this.AccountType = accountType;
        }
        public AccountType AccountType { get; set; }
        public Customer Holder { get; private set; }
        public DateTime StartDate { get { return this.StartDate; } }
        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Balance", "Balance cannot be negative.");
                }
                this.balance = value;
            }
        }
        public decimal InterestRate
        {
            get
            {
                return this.interestRate/100m;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Interest rate cannot be negative.");
                }
                this.interestRate = value;
            }
        }
        public void DepositMoney(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Deposit amount", "Amount cannot be negative.");
            }
            this.Balance = this.Balance + amount;
        }
        public abstract decimal CalculateInterest(int months);
    }
}
