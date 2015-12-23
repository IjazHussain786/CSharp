using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2Bank.Accounts.MortgageAccounts
{
    public abstract class MortgageAccount : Account
    {
        private const int InterestFreePeriodForIndividuals = 6;
        private const int InterestBonusPeriodForCompanies = 12;
        public MortgageAccount(Customer holder, decimal balance, decimal interestRate, AccountType accountType, MortgageType mortgageType)
            : base (holder, balance, interestRate, accountType)
        {
            this.MortgageType = mortgageType;
        }
        public MortgageType MortgageType { get; set; }
        public DateTime EndDate
        {
            get
            {
                return this.StartDate.AddMonths((int)(MortgageType));
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
                if (months - InterestBonusPeriodForCompanies > 0)
                {
                    decimal bonusInterest = this.Balance * (this.InterestRate * InterestBonusPeriodForCompanies);
                    bonusInterest = bonusInterest / 2;
                    interest = bonusInterest + 
                        (this.Balance * (1m + (this.InterestRate * ((decimal)months - InterestBonusPeriodForCompanies))));
                }
                else
                {
                    interest = this.Balance * (1m + (this.InterestRate * (decimal)months));
                    interest = interest / 2m;
                }
            }
            return interest;
        }
    }
}
