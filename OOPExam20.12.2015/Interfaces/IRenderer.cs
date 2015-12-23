using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam20._12._2015.Interfaces
{
    public interface IRenderer
    {
        void WriteLine(string message, params string[] parameters);
    }
}
