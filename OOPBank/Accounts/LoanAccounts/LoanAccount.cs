using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P2Bank.Customers;
using P2Bank.Accounts;

namespace P2Bank.Accounts.LoanAccounts
{
    public abstract class LoanAccount : Account
    {
        private const decimal InterestFreePeriodForIndividuals = 3m;
        private const decimal InterestFreePeriodForCompanies = 2m;
        public LoanAccount(Customer holder, decimal balance, decimal interestRate, LoanType loanType, AccountType accountType)
            : base(holder, balance, interestRate, accountType)
        {
            this.LoanType = loanType;
        }
        public LoanType LoanType { get; set; }
        public DateTime EndDate
        {
            get
            {
                return this.StartDate.AddMonths((int)(LoanType));
            }
        }
        public override decimal CalculateInterest(int months)
        {
            if (months < 0)
            {
                throw new ArgumentException("Interest number of months", "Number of months value cannot be negative");
            }
            decimal interest = 0m;
            if (this.AccountType == AccountType.Personal)
            {
                if (months - InterestFreePeriodForIndividuals > 0)
                {
                    interest = this.Balance * (1m + (this.InterestRate * ((decimal)months - InterestFreePeriodForIndividuals)));
                }
            }
            if (this.AccountType == AccountType.Company)
            {
                if (months - InterestFreePeriodForCompanies > 0)
                {
                    interest = this.Balance * (1m + (this.InterestRate * ((decimal)months - InterestFreePeriodForCompanies)));
                }
            }
            return interest;
        }
    }
}
