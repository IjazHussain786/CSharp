using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultimediaShop.Engine.Exceptions
{
    public class InsufficientSuppliesException : ApplicationException
    {
        public InsufficientSuppliesException(string message)
            : base(message)
        {
        }
    }
}
