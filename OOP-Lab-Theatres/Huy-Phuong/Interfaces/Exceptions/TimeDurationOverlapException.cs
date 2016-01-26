using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huy_Phuong.Exceptions
{
    public class TimeDurationOverlapException : TheaterException
    {
        public TimeDurationOverlapException(string msg)
            : base(msg)
        {
        }
    }
}
