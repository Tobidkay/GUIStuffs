﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave1.Model
{
    [Serializable]
    public abstract class AProduct
    {
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
