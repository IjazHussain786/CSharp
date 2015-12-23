using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2Bank.Accounts.DepositAccounts
{
    public class SixMonthDeposit : DepositAccount
    {
        public SixMonthDeposit(Customer holder, decimal balance, decimal interestRate, DepositType depositType, AccountType accountType)
            : base(holder, balance, interestRate, depositType, accountType)
        {
        }
    }
}
