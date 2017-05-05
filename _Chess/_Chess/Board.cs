using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _Chess
{
    public class Board
    {
        public readonly IFigure[,] figures = new IFigure[8, 8];
        private static Board instance;

        private string whoseTurn = "white";
        public bool FirstStep { get; private set; } = true;
        public int FirstX { get; private set; }
        public int FirstY { get; private set; }
        public int ReserveFirstX { get; private set; }
        public int ReserveFirstY { get; private set; }

        public static Board Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }
                else
                {
                    instance = new Board();
                    return instance;
                }
            }
        }

        private Board()
        {
            #region Created figures
            figures[0, 0] = new Rook("black");
            figures[0, 1] = new Knight("black");
            figures[0, 2] = new Bishop("black");
            figures[0, 3] = new Queen("black");
            figures[0, 4] = new King("black");
            figures[0, 5] = new Bishop("black");
            figures[0, 6] = new Knight("black");
            figures[0, 7] = new Rook("black");

            figures[1, 0] = new Pawn("black");
            figures[1, 1] = new Pawn("black");
            figures[1, 2] = new Pawn("black");
            figures[1, 3] = new Pawn("black");
            figures[1, 4] = new Pawn("black");
            figures[1, 5] = new Pawn("black");
            figures[1, 6] = new Pawn("black");
            figures[1, 7] = new Pawn("black");

            figures[7, 0] = new Rook("white");
            figures[7, 1] = new Knight("white");
            figures[7, 2] = new Bishop("white");
            figures[7, 3] = new Queen("white");
            figures[7, 4] = new King("white");
            figures[7, 5] = new Bishop("white");
            figures[7, 6] = new Knight("white");
            figures[7, 7] = new Rook("white");

            figures[6, 0] = new Pawn("white");
            figures[6, 1] = new Pawn("white");
            figures[6, 2] = new Pawn("white");
            figures[6, 3] = new Pawn("white");
            figures[6, 4] = new Pawn("white");
            figures[6, 5] = new Pawn("white");
            figures[6, 6] = new Pawn("white");
            figures[6, 7] = new Pawn("white");
            #endregion
        }




        private bool IsMyTurn(int x, int y)
        {
            if (figures[x, y].Color == whoseTurn)
            {
                whoseTurn = whoseTurn == "white" ? "black" : "white";
                return true;
            }
            else
            {
                return false;
            }
        }


        private bool IsNull(int x, int y)
        {
            if (figures[x, y] != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsSimilarColors(int x, int y, int x2, int y2)
        {
            if (!IsNull(x2, y2) && !IsNull(x, y))
            {
                if (figures[x, y].Color == figures[x2, y2].Color)
                {
                    return true;
                }
            }

            return false;
        }



        public DrawType Event(int x, int y)
        {
            if (FirstStep)
            {
                if (!IsNull(x, y))
                {
                    if (IsMyTurn(x, y))
                    {
                        FirstStep = false;
                        FirstX = x;
                        FirstY = y;
                        return DrawType.EnableColor;
                    }
                    else
                    {
                        return DrawType.Null;
                    }
                }
            }
            else
            {

                if (!IsSimilarColors(FirstX, FirstY, x, y))
                {
                    if (FigureMove(FirstX, FirstY, x, y))
                    {
                        FirstStep = true;
                        return DrawType.MoveFigure;
                    }
                    else
                    {
                        return DrawType.Null;
                    }
                }
                else
                {
                    FirstStep = false;
                    ReserveFirstX = FirstX;
                    ReserveFirstY = FirstY;
                    FirstX = x;
                    FirstY = y;
                    return DrawType.SameColor;
                }

            }
            return DrawType.Null;
        }

        private bool CanFigureMove(int x, int y, int x1, int y1)
        {
            return figures[x, y].CanMove(x, y, x1, y1);
        }

        private bool FigureMove(int x, int y, int x1, int y1)
        {
            if (CanFigureMove(x, y, x1, y1) && CanMoveOnTheBoard(x, y, x1, y1))
            {
                figures[x1, y1] = figures[x, y];
                figures[x, y] = null;
                return true;
            }
            else
            {
                return false;

            }
        }

        private bool CanMoveOnTheBoard(int x, int y, int x1, int y1)
        {
            

            if (figures[x, y] is Knight)
            {
                return true;
            }

            int x2 = Math.Sign(x1 - x);
            int y2 = Math.Sign(y1 - y);

            x += x2;
            y += y2;

            while (x != x1 || y != y1)
            {
                if ((x != x1 || y != y1) && figures[x, y] != null)
                {
                    return false;
                }
                x += x2;
                y += y2;
            }

            return true;
        }

        //private bool IsChack(int x, int y)
        //{
        //    for (int i = 0; i < 8; i++)
        //    {
        //        for (int j = 0; j < 8; j++)
        //        {
        //            if (figures[i, j] != null && !(figures[i, j] is King) && figures[i, j].Color != whoseTurn)
        //            {
        //                if (CanMoveOnTheBoard(i, j, x, y))
        //                {
        //                    return false;
        //                }
        //            }
        //        }
        //    }
        //    return true;
        //}
    }
}