﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTD_3layers.DTO
{
    public class CBBItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
}
