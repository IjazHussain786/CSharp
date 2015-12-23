using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P2Bank.Customers;
using P2Bank.Accounts.DepositAccounts;
using P2Bank.Accounts.LoanAccounts;
using P2Bank.Accounts;
using P2Bank.Accounts.MortgageAccounts;

namespace P2Bank
{
    public class BankMain
    {
        static void Main()
        {
            IndividualCustomer pesho = new IndividualCustomer("Pesho");
            CompanyCustomer tsarvulInvestment = new CompanyCustomer("Tsarvul Investment");
            //SixMonthDeposit depositPesho = new SixMonthDeposit(pesho, 1500m, 3.2m, DepositType.SixMonth, Accounts.AccountType.Personal);
            //decimal interestDeposit = depositPesho.CalculateInterest(5);
            //Console.WriteLine(interestDeposit);
            //SixMonthLoan loanPesho = new SixMonthLoan(pesho, 1500m, 3.2m, LoanType.SixMonth, AccountType.Personal);
            //decimal interestLoan = loanPesho.CalculateInterest(4);
            //Console.WriteLine(interestLoan);
            ThirtyYearMortgage mortgage = new ThirtyYearMortgage
                (tsarvulInvestment, 10000m, 3.2m, AccountType.Company, MortgageType.ThirtyYear);
            decimal interest = mortgage.CalculateInterest(12);
            Console.WriteLine(interest);



        }
    }
}
