using P2Bank.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P2Bank.Interfaces;

namespace P2Bank.Accounts.DepositAccounts
{
    public abstract class DepositAccount : Account, IWithdrawMoney
    {
        public DepositAccount(Customer holder, decimal balance, decimal interestRate, DepositType depositType, AccountType accountType)
            : base(holder, balance, interestRate, accountType)
        {
            this.DepositType = depositType;
        }
        public DepositType DepositType { get; set; }
        public DateTime EndDate 
        {
            get
            { 
                return this.StartDate.AddMonths((int)(DepositType));
            }
        }

        public void WithdrawMoney(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Withdrawal amount", "Amount cannot be negative.");
            }
            if (amount > this.Balance)
            {
                throw new ArgumentException("Withdrawal amount", "Amount cannot be bigger than current balance.");
            }
            this.Balance = this.Balance - amount;
        }
        public override decimal CalculateInterest(int months)
        {
            if (months < 0)
            {
                throw new ArgumentException("Interest number of months", "Number of months value cannot be negative");
            }
            decimal interest = 0m;
            if (this.Balance < 1000)
            {
                return interest;
            }
            interest = this.Balance * (1m + (this.InterestRate * (decimal)months));
            return interest;
        }
    }
}
