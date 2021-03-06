﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum.Items
{
    public class Shield : Item
    {
        private const int ShieldDefaultHealthEffect = 0;
        private const int ShieldDefaultDefenseEffect = 50;
        private const int ShieldDefaultAttackEffect = 0;
        public Shield(string id)
            : base(id, ShieldDefaultHealthEffect, ShieldDefaultDefenseEffect, ShieldDefaultAttackEffect)
        {
        }
    }
}
