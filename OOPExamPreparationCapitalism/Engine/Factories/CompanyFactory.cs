using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation_Capitalism.Engine.Factories
{
    public class CompanyFactory
    {
        public Company CreateCompany(string companyName, CEO ceo)
        {
            return new Company(companyName, ceo);
        }
    }
}
