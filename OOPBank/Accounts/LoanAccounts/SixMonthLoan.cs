using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2Bank.Accounts.LoanAccounts
{
    public class SixMonthLoan : LoanAccount
    {
        public SixMonthLoan(Customer holder, decimal balance, decimal interestRate, LoanType loanType, AccountType accountType)
            : base(holder, balance, interestRate, loanType, accountType)
        {
        }
    }
}
