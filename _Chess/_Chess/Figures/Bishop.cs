﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _Chess
{
    public class Bishop : Figure
    {
 

        public override bool CanMove(int x, int y, int x1, int y1)
        {
            return Math.Abs(x - x1) == Math.Abs(y - y1);
        }

        public Bishop(string color) : base(color)
        {
            Name = "Bishop";
        }
    }
}