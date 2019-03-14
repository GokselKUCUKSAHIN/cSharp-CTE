using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2
{
    class Snake
    {
        char Kare = '■';
        public List<int> X = new List<int>() { 17, 19, 21, 23, 25 };
        public List<int> Y = new List<int>() { 10, 10, 10, 10, 10 };
        int Blockside = 2;
        byte Pos = 4;
        public void Grow()
        {
            int Tx = X[X.Count - 1];
            int Ty = Y[Y.Count - 1];
            X.Add(Tx);
            Y.Add(Ty);
        }
        public bool isEat(int Ax, int Ay)
        {
            if ((Ax == X[X.Count - 1]) && (Ay == Y[Y.Count - 1]))
            {
                return true;
            }
            else
                return false;
        }
        private void GoWhile(byte Pos)
        {
            if (Pos == 1)
            {
                Blockside = 3;
                int Nx = X[X.Count - 1];
                int Ny = Y[Y.Count - 1] - 1;
                if (Ny < 1)
                {
                    Ny = 20;
                }
                X.Add(Nx);
                Y.Add(Ny);
                Console.SetCursorPosition(X[0], Y[0]);
                Console.Write(" ");
                X.RemoveAt(0);
                Y.RemoveAt(0);
            }
            else if (Pos == 2)
            {
                Blockside = 4;
                int Nx = X[X.Count - 1] - 2;
                int Ny = Y[Y.Count - 1];
                if (Nx < 1)
                {
                    Nx = 39;
                }
                X.Add(Nx);
                Y.Add(Ny);
                Console.SetCursorPosition(X[0], Y[0]);
                Console.Write(" ");
                X.RemoveAt(0);
                Y.RemoveAt(0);
            }
            else if (Pos == 3)
            {
                Blockside = 1;
                int Nx = X[X.Count - 1];
                int Ny = Y[Y.Count - 1] + 1;
                if (Ny > 20)
                {
                    Ny = 1;
                }
                X.Add(Nx);
                Y.Add(Ny);
                Console.SetCursorPosition(X[0], Y[0]);
                Console.Write(" ");
                X.RemoveAt(0);
                Y.RemoveAt(0);
            }
            else if (Pos == 4)
            {
                Blockside = 2;
                int Nx = X[X.Count - 1] + 2;
                int Ny = Y[Y.Count - 1];
                if (Nx > 39)
                {
                    Nx = 1;
                }
                X.Add(Nx);
                Y.Add(Ny);
                Console.SetCursorPosition(X[0], Y[0]);
                Console.Write(" ");
                X.RemoveAt(0);
                Y.RemoveAt(0);
            }
        }
        public void Move(ConsoleKeyInfo Tus,bool OK)
        {
              
            if((Tus.Key == ConsoleKey.UpArrow) && (Blockside != 1))
            {
                Pos = 1;
                GoWhile(Pos);     
            }
            else if((Tus.Key == ConsoleKey.LeftArrow) && (Blockside != 2))
            {
                Pos = 2;
                GoWhile(Pos);
                
            }
            else if ((Tus.Key == ConsoleKey.DownArrow) && (Blockside != 3))
            {
                Pos = 3;
                GoWhile(Pos);
                
            }
            else if ((Tus.Key == ConsoleKey.RightArrow) && (Blockside != 4))
            {
                Pos = 4;
                GoWhile(Pos);
            }
            else
            {
                if (Blockside == 4)
                {
                    GoWhile(2);
                }
                else if (Blockside == 2)
                {
                    GoWhile(4);
                }
                else if (Blockside == 1)
                {
                    GoWhile(3);
                }
                else if (Blockside == 3)
                {
                    GoWhile(1);
                }
            }
        }
        public void Draw()
        {
            for (int i = 0; i < X.Count; i++) 
            {
                if (i == X.Count - 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.SetCursorPosition(X[i],Y[i]);
                Console.Write(Kare);
            }
        }
        public bool Die()
        {
            bool Live = true;
            int Leng = X.Count - 1;
            int Hx = X[X.Count - 1];
            int Hy = Y[Y.Count - 1];
            for (int i = 0; (i < Leng - 3) && (Live != false); i++)
            {
                if ((Hx == X[i]) && (Hy == Y[i]))
                {
                    Live = false;
                }
            }
            if(!Live)
            {
                int Len = X.Count - 5;
                for (int i = 0; i < Len; i++)
                {
                    Console.SetCursorPosition(X[i],Y[i]);
                    Console.Write(" ");
                }
                X.RemoveRange(0, Len);
                Y.RemoveRange(0, Len);
            }
            return Live;
        }
    }
}