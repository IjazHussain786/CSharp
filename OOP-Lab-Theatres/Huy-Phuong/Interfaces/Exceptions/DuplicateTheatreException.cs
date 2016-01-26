using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huy_Phuong.Exceptions
{
    class DuplicateTheatreException : TheaterException
    {
        public DuplicateTheatreException(string msg)
            : base(msg)
        {
        }

    }
}
