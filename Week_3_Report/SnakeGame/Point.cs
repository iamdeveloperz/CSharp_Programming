using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_3_Report
{
    public class Point
    {
        #region Member Variables
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol {  get; set; }
        #endregion

        #region Main Methods
        public Point(int _x, int _y, char _symbol)
        {
            X = _x;
            Y = _y;
            Symbol = _symbol;
        }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
            Symbol = point.Symbol;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }

        public void Clear()
        {
            Symbol = ' ';
            Draw();
        }

        public bool IsHit(Point point)
        {
            return point.X == X && point.Y == Y;
        }
        #endregion
    }

    #region Enum
    public enum E_Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }
    #endregion
}