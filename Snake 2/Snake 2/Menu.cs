using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2
{
    class Menu
    {

        public void MainMenu()
        {
            Console.CursorVisible = false;
            bool exit = true;
            Window();
            Contex();
            int selection = 0;
            while (exit)
            {
                if (selection == 0)
                {
                    Select();
                    Console.SetCursorPosition(12, 8);
                    Console.WriteLine("*PLAY ");
                    Unselect();
                    Console.SetCursorPosition(12, 10);
                    Console.WriteLine(" SETTINGS ");
                    Console.SetCursorPosition(12, 12);
                    Console.WriteLine(" QUIT ");
                }
                else if(selection == 1)
                {
                    Unselect();
                    Console.SetCursorPosition(12, 8);
                    Console.WriteLine(" PLAY ");
                    Select();
                    Console.SetCursorPosition(12, 10);
                    Console.WriteLine("*SETTINGS ");
                    Unselect();
                    Console.SetCursorPosition(12, 12);
                    Console.WriteLine(" QUIT ");
                }
                else if(selection == 2)
                {
                    Unselect();
                    Console.SetCursorPosition(12, 8);
                    Console.WriteLine(" PLAY ");
                    Console.SetCursorPosition(12, 10);
                    Console.WriteLine(" SETTINGS ");
                    Select();
                    Console.SetCursorPosition(12, 12);
                    Console.WriteLine("*QUIT ");
                    Unselect();
                }
                ConsoleKeyInfo Tus = Console.ReadKey();
                if(Tus.Key == ConsoleKey.UpArrow)
                {
                    selection--;
                    if (selection < 0)
                        selection = 2;
                    Console.Beep(500,80); //UpArrow SoundFx
                }
                else if(Tus.Key == ConsoleKey.DownArrow)
                {
                    selection++;
                    if (selection > 2)
                        selection = 0;
                    Console.Beep(440,80); //DownArrow SoundFx
                }
                else if(Tus.Key == ConsoleKey.Enter)
                {
                    Console.Beep(220, 80); //enter SoundFx
                    if (selection == 0)
                    {
                        //Play
                        Window();
                        Contex();
                        Select();
                        Console.SetCursorPosition(12, 10);
                        Console.WriteLine(" Press Any Key ");
                        Default();
                        exit = false;
                    }
                    else if(selection ==1)
                    {
                        //Settings
                        Window();
                        Contex();
                        Unselect();
                        Console.SetCursorPosition(12, 8);
                        Console.WriteLine(" This Menu currently ");
                        Unselect();
                        Console.SetCursorPosition(12, 9);
                        Console.WriteLine(" in Development ");
                        Select();
                        Console.SetCursorPosition(12, 11);
                        Console.WriteLine("*Go Back ");
                        bool enter = true;
                        while (enter)
                        {
                            ConsoleKeyInfo ent = Console.ReadKey();
                            if (ent.Key == ConsoleKey.Enter)
                            {
                                Window();
                                Contex();
                                Console.Beep(220, 80); //enter SoundFx
                                enter = false;
                            }
                            else
                            {
                                Console.Beep(660, 80);
                                Window();
                                Contex();
                                Unselect();
                                Console.SetCursorPosition(12, 8);
                                Console.WriteLine(" This Menu currently ");
                                Unselect();
                                Console.SetCursorPosition(12, 9);
                                Console.WriteLine(" in Development ");
                                Select();
                                Console.SetCursorPosition(12, 11);
                                Console.WriteLine("*Go Back ");
                            }
                        }
                        Default();
                    }
                    else
                    {
                        //Quit
                        Environment.Exit(0);
                    }
                }
            }
            Default();
        }
        private void Select()
        {
            //
            //Arka Planı Kapalı Kırmızı Yap, Fontu Kapalı Gri
            //
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }
        private void Unselect()
        {
            //
            //Arka Planı Kapalı Gri Yap, Fontu Siyah
            //
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        private void Default()
        {
            //
            //Arka Planı Siyah Yap, Fontu Beyaz
            //
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        private void Contex()
        {
            //
            //Belirli bir alanı Kullanmak için Parametreler
            //
            Console.BackgroundColor = ConsoleColor.DarkGray;
            for (int i = 7; i <= 34; i++)
            {
                for (int j = 5; j <= 16; j++)
                {
                    Console.SetCursorPosition(i,j);
                    Console.WriteLine(" ");
                }
            }

            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 6; i <= 16; i++)
            {
                Console.SetCursorPosition(35, i);
                Console.Write(" ");
            }
            for (int i = 8; i <= 35; i++)
            {
                Console.SetCursorPosition(i, 17);
                Console.Write(" ");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
                
        private void Window()
        {
            //
            //Char
            //
            char Cubuk = '█';
            char UstKare = '▀';
            char AltKare = '▄';
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            //
            //Fillin Inside
            //
            for (int i = 1; i < 41; i++)
            {
                for (int j = 1; j < 21; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }

            //
            //Borders
            //
            for (int i = 0; i < 22; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(Cubuk);
                Console.SetCursorPosition(41, i);
                Console.Write(Cubuk);
            }
            for (int i = 1; i < 41; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write(UstKare);
            }
            for (int i = 1; i < 41; i++)
            {
                Console.SetCursorPosition(i, 21);
                Console.Write(AltKare);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
