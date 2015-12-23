using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2Bank.Accounts.MortgageAccounts
{
    public class ThirtyYearMortgage : MortgageAccount
    {
        public ThirtyYearMortgage(Customer holder, decimal balance, decimal interestRate, AccountType accountType, MortgageType mortgageType)
            : base (holder, balance, interestRate, accountType, mortgageType)
        {
        }
    }
}
