using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2
{
    class Program
    {
        private static void Main()
        {
            Menu UI = new Menu();
            UI.MainMenu();
            Game();
            Main();
        }
        private static void Game()
        {
            Snake Yilan = new Snake();
            Yem Elma = new Yem();
            Elma.Create(true);
            ConsoleKeyInfo Tus = Console.ReadKey();
            Console.Clear();
            Console.CursorVisible = false;
            bool isKeyPressed = false;
            bool game = true;
            int Score = 0;
            ScoreDraw(Score);
            while (game)
            {
                DrawFrame();
                if (Console.KeyAvailable)
                {
                    Tus = Console.ReadKey();
                    isKeyPressed = true;
                    if (Tus.Key == ConsoleKey.Escape)
                        game = false;
                }
                else
                    isKeyPressed = false;
                Yilan.Move(Tus, isKeyPressed);
                Elma.Draw();
                if (!Yilan.Die())
                {
                    Score = 0;
                    ScoreDraw(Score);
                    DrawFrame(true);
                    Console.Beep(880,80);
                }
                Yilan.Draw();
                if (Yilan.isEat(Elma.X, Elma.Y))
                {
                    Yilan.Grow();
                    Elma.Create(Yilan.X, Yilan.Y);
                    Elma.Draw();
                    Score += 5;
                    ScoreDraw(Score);
                }
                System.Threading.Thread.Sleep(80); //80 ideal
            }
        }
        private static void DrawFrame()
        {
            //
            //CHARS
            //
            char Cubuk = '█';
            char Kare = '▄';
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            for (int i = 0; i <= 41; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write(Kare);
            }
            for (int i = 1; i < 41; i++)
            {
                Console.SetCursorPosition(i, 21);
                Console.Write(Kare);
            }
                for (int i = 1; i <= 21; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(Cubuk);
                Console.SetCursorPosition(41, i);
                Console.Write(Cubuk);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void DrawFrame(bool Color)
        {
            if(Color)
            {
                //
                //CHARS
                //
                char Cubuk = '█';
                char Kare = '▄';
                Console.ForegroundColor = ConsoleColor.Red;
                for (int i = 0; i <= 41; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write(Kare);
                }
                for (int i = 1; i < 41; i++)
                {
                    Console.SetCursorPosition(i, 21);
                    Console.Write(Kare);
                }
                for (int i = 1; i <= 21; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write(Cubuk);
                    Console.SetCursorPosition(41, i);
                    Console.Write(Cubuk);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        private static void ScoreDraw(int Gain)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 22);
            Console.Write("              ");
            Console.SetCursorPosition(0, 22);
            Console.Write("Score = " + Gain);
        }
    }
}