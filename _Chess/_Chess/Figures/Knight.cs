using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _Chess
{
    public class Knight : Figure
    {
       
        public override bool CanMove(int x, int y, int x1, int y1)
        {
            return (x1 == x - 2 && y1 == y - 1) || (x1 == x - 2 && y1 == y + 1) || (x1 == x - 1 && y1 == y + 2) ||
                    (x1 == x - 1 && y1 == y - 2) ||
                    (x1 == x + 2 && y1 == y - 1) || (x1 == x + 2 && y1 == y + 1) || (x1 == x + 1 && y1 == y + 2) ||
                    (x1 == x + 1 && y1 == y - 2);
        }

        public Knight(string color) : base(color)
        {
            Name = "Knight";
        }
    }
}