using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam20._12._2015.Interfaces
{
    public interface IBehavioural
    {
        int DamageBonus { get; set; } //To multiply.
        int HealthBonus { get; set; } //To add.
        int DamageMinus { get; set; } //To substract.
        int HealthMinus { get; set; } //To substract.
        bool IsTriggered { get; }
        int CyclesCount { get; set; }
    }
}
