﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2Bank
{
    public abstract class Customer
    {
        public Customer(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }
}
