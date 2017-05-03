using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _Chess
{
    public class Queen : Figure
    {
   

        public override bool CanMove(int x, int y, int x1, int y1)
        {
            return (x == x1 || y == y1) || Math.Abs(x - x1) == Math.Abs(y - y1);
        }

        public Queen(string color) : base(color)
        {
            Name = "Queen";
        }
    }
}