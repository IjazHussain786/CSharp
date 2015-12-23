using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam20._12._2015.Interfaces
{
    public interface IAttack
    {
        int DamageEffect { get; set; } //To multiply.
        int HealthEffect { get; set; } //To divide.
    }
}
