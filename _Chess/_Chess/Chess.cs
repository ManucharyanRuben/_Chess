using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _Chess.Properties;

namespace _Chess
{
    public partial class Chess : Form
    {

        private bool firstStep;

        public Chess()
        {
            InitializeComponent();
        }

        private void Chess_Load(object sender, EventArgs e)
        {
            DrawBoard();
            FirstDraw();
        }

        private void FirstDraw()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Board.Instance.figures[i, j] != null)
                    {
                        picArrays[i, j].Image =
                            (Image)
                            Resources.ResourceManager.GetObject(Board.Instance.figures[i, j].Color +
                                                                Board.Instance.figures[i, j].Name);
                    }
                    else
                    {
                        picArrays[i, j].Image = null;
                    }
                }
            }
        }

        //private void ResetColors()
        //{
        //    for (int i = 0; i < 8; i++)
        //    {
        //        for (int j = 0; j < 8; j++)
        //        {
        //            picArrays[i, j].BackColor = (i + j) % 2 == 0 ? Color.Wheat : Color.SaddleBrown;
        //        }
        //    }
        //}

        private void BoardClick(int x, int y)
        {
            DrawType drawType = Board.Instance.Event(x, y);
            if (drawType == DrawType.MoveFigure)
            {
                picArrays[x, y].Image = picArrays[Board.Instance.FirstX, Board.Instance.FirstY].Image;
                picArrays[Board.Instance.FirstX, Board.Instance.FirstY].Image = null;
                ChangeCubeColor(Board.Instance.FirstX, Board.Instance.FirstY);
            }
            else
            {
                ChangeCubeColor(x, y, drawType);
            }


        }



        private void ChangeCubeColor(int i, int j, DrawType drawType = DrawType.Null)
        {
            label1.Text = Board.Instance.whiteKingX + " " + Board.Instance.whiteKingY;
            label2.Text = Board.Instance.blackKingX + " " + Board.Instance.blackKingY;
            //ResetColors();
            if (drawType == DrawType.EnableColor)
            {
                picArrays[i, j].BackColor = Color.Aquamarine;
            }
            else if (drawType == DrawType.SameColor)
            {
                picArrays[Board.Instance.FirstX, Board.Instance.FirstY].BackColor = Color.Aquamarine;
                ChangeCubeColor(Board.Instance.ReserveFirstX, Board.Instance.ReserveFirstY);
            }
            else
            {
                picArrays[i, j].BackColor = (i + j) % 2 == 0 ? Color.Wheat : Color.SaddleBrown;
            }
        }
    }
}
