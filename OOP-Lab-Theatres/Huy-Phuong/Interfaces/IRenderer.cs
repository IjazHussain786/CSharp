using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huy_Phuong.Interfaces
{
    public interface IRenderer
    {
        void WriteLine(string message, params string[] parameters);
    }
}
