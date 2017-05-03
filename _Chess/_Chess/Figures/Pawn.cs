using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _Chess
{
    public class Pawn : Figure
    {
        private int s;

        public override bool CanMove(int x, int y, int x1, int y1)
        {
            return isFirstMove(x, y, x1, y1);
        }


        private bool isFirstMove(int x, int y, int x1, int y1)
        {
            if (Board.Instance.figures[x1, y1] != null)
            {
                if (Board.Instance.figures[x1, y1].Color != this.Color && y1 != y && Math.Abs(y - y1) < 2 && Math.Abs(x - x1) < 2)
                {
                    if ((Color == "white" && x > x1) || (Color == "black" && x < x1))
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }

            if (Board.Instance.figures[x1,y]!=null)
            {
                return false;
            }

            if (Color == "white")
            {
                if (x == 6)
                {
                    s = 2;
                }

                if ((x < x1 || y > y1 || y < y1) || x - x1 > s)
                {
                    return false;
                }
            }
            else
            {
                if (x == 1)
                {
                    s = 2;
                }

                if ((x > x1 || y > y1 || y < y1) || x1 - x > s)
                {
                    return false;
                }
            }
            return true;
        }


        public Pawn(string color) : base(color)
        {
            Name = "Pawn";
        }
    }
}