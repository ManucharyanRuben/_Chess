using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _Chess
{
    public class Rook : Figure
    {

        public override bool CanMove(int x, int y, int x1, int y1)
        {
            return x == x1 || y == y1;
        }

        public Rook(string color) : base(color)
        {
            Name = "Rook";
        }
    }
}