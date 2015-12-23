using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPGGame.Interfaces
{
    public interface IDie
    {
        int Health { get; set; }
        void Die();
    }
}
