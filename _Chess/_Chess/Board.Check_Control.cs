using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Chess
{
    partial class Board
    {


        private IFigure[,] figuresReserve = new IFigure[8, 8];

        public int whiteKingX;
        public int whiteKingY;
        public int blackKingX;
        public int blackKingY;

        private int TheCheckMakerX;
        private int TheCheckMakerY;


        private bool IsNotCheck(int x, int y, int x1, int y1)
        {
            CreateFiguresReserveArray(x, y, x1, y1);

            WhereIsTheKing(figuresReserve);


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    if (figuresReserve[i, j] != null && figuresReserve[i, j].Color == whoseTurn)
                    {

                        if (whoseTurn == "black")
                        {
                            if (!(figuresReserve[i, j] is Pawn))
                            {
                                if (CanFigureMove(i, j, whiteKingX, whiteKingY) &&
                                    CanMoveOnTheBoard(i, j, whiteKingX, whiteKingY, figuresReserve))
                                {
                                return false;
                                    }
                            }
                            else
                            {
                                if ((figuresReserve[i, j] as Pawn).IsEating(i, j, whiteKingX, whiteKingY, figuresReserve))
                                {
                                 return false;
                                }
                            }
                        }
                        else
                        {
                            if (!(figuresReserve[i, j] is Pawn))
                            {
                                if (CanFigureMove(i, j, blackKingX, blackKingY) &&
                                    CanMoveOnTheBoard(i, j, blackKingX, blackKingY, figuresReserve))
                                {
                                 return false;
                                }
                            }
                            else
                            {
                                if ((figuresReserve[i, j] as Pawn).IsEating(i, j, blackKingX, blackKingY, figuresReserve))
                                {
                             return false;
                                }
                            }
                        }
                    }
                }
            }
            WhereIsTheKing(figures);
            return true;
        }

        private void WhereIsTheKing(IFigure[,] figures)
        {
            for (int x1 = 0; x1 < 8; x1++)
            {
                for (int y1 = 0; y1 < 8; y1++)
                {
                    if (figures[x1, y1] is King)
                    {
                        if (figures[x1, y1].Color == "white")
                        {
                            whiteKingX = x1;
                            whiteKingY = y1;

                        }
                        else
                        {
                            blackKingX = x1;
                            blackKingY = y1;
                        }
                    }
                }
            }
        }

        private void CreateFiguresReserveArray(int x, int y, int x1, int y1)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    figuresReserve[i, j] = figures[i, j];
                }
            }
            if (x != x1 || y != y1)
            {
                figuresReserve[x1, y1] = figuresReserve[x, y];
                figuresReserve[x, y] = null;
            }
        }

     

    }
}