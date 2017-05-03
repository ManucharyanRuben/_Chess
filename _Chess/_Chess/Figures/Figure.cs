using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Chess
{
    public interface IFigure
    {
        string Name { get; set; }
        string Color { get; set; }

        bool CanMove(int x, int y, int x1, int y1);
    }

    public abstract class Figure : IFigure
    {
        protected Figure(string color)
        {
           this.Color = color;
        }

        public string Name { get; set; }
        public string Color { get; set; }
        public abstract bool CanMove(int x, int y, int x1, int y1);
    }
}
