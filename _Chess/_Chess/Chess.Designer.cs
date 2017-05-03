using System;
using System.Drawing;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;

namespace _Chess
{
    partial class Chess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private System.Windows.Forms.PictureBox[,] picArrays = new PictureBox[8, 8];

        private void DrawBoard()
        {
            int top = 0;
            int left = 0;
            for (int i = 0; i < 8; i++)
            {
                int i2 = i;
                for (int j = 0; j < 8; j++)
                {
                    picArrays[i, j] = new System.Windows.Forms.PictureBox();
                    ((System.ComponentModel.ISupportInitialize)(picArrays[i, j])).BeginInit();
                    picArrays[i, j].Location = new System.Drawing.Point(left, top);
                    picArrays[i, j].Size = new System.Drawing.Size(100, 100);
                    picArrays[i, j].Name = $"_{i}{j}";
                 
                    int j2 = j;
                    picArrays[i, j].Click += (sender, args) => BoardClick(i2,j2);
                    if ((i + j) % 2 == 0)
                    {
                        picArrays[i, j].BackColor = Color.Wheat;
                    }
                    else
                    {
                        picArrays[i, j].BackColor = Color.SaddleBrown;
                    }
                    this.Controls.Add(this.picArrays[i, j]);
                    left += 100;
                }
                top += 100;
                left = 0;
            }
        }



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 836);
            this.Name = "Chess";
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.Chess_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

