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

        private int whiteKingX;
        private int whiteKingY;
        private int blackKingX;
        private int blackKingY;

 
        private bool IsNotCheck(int x, int y, int x1, int y1)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    figuresReserve[i, j] = figures[i, j];
                }
            }

            figuresReserve[x1, y1] = figuresReserve[x, y];
            figuresReserve[x, y] = null;

            if (figuresReserve[x1, y1] is King)
            {
                if (figuresReserve[x1, y1].Color == "white")
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

            return true;
        }
       


    }
}
