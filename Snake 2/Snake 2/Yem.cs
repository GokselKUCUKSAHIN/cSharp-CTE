using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2
{
    class Yem
    {
        public int X;
        public int Y;
        private char Dot = '¤';
        Random r = new Random();
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(Dot);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Create(List<int> Sx, List<int> Sy)
        {
            int Tx = r.Next(1, 21);
            X = (2 * Tx) - 1;
            Y = r.Next(1, 21);
            for (int i = 0; i < Sx.Count; i++)
            {
                if ((Sx[i] == X) && (Sy[i] == Y))
                {
                    try
                    {
                        Create(Sx, Sy);
                    }
                    catch
                    {
                        Console.SetCursorPosition(0, 23);
                        Console.Write("Catch!!!");
                    }
                }
            }
        }

        public void Create(bool Hello)
        {
            X = 17;
            Y = 7;
        }
    }
}