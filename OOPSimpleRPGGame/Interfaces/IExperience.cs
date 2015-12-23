using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPGGame.Interfaces
{
    public interface IExperience
    {
        int Experience { get; }
        void LevelUp();
    }
}
