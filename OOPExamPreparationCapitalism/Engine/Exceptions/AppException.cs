using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation_Capitalism.Engine.Exceptions
{
    public class AppException : ApplicationException
    {
        public AppException(string msg)
            : base(msg)
        {
        }
    }
}
