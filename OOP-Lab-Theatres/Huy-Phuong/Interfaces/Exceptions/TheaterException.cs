using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huy_Phuong.Exceptions
{
    public class TheaterException : Exception
    {
        public TheaterException(string msg)
            : base(msg)
        {
        }
    }
}
