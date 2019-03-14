using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Undertale
{
    class Program
    {
        static void Main(string[] args)
        {
            char x = ' ';
            char y = '#';
            Thread.Sleep(200);
            Console.Write("{0}{1}{2}{3}",x,x,y,x);
            for (int i = 1; i <= 3; i += 1) 
            {
                Thread.Sleep(200);
                Console.Write("{0}{1}", x, x);
            }
            Thread.Sleep(200);
            Console.Write("{0}{1}\n", y, x);
            for (int i = 1; i <= 3; i += 1)
            {
                Thread.Sleep(200);
                Console.Write("{0}{1}", y, x);
            }
            Thread.Sleep(200);
            Console.Write("{0}{1}", x, x);
            for (int i = 1; i <= 3; i += 1)
            {
                Thread.Sleep(200);
                Console.Write("{0}{1}", y, x);
            }
            Thread.Sleep(200);
            Console.WriteLine();
            for (int i = 1; i <= 7; i += 1) 
            {
                Thread.Sleep(200);
                Console.Write("{0}{1}", y, x);
            }
            Thread.Sleep(200);
            Console.Write("\n{0}{1}", x, x);
            for (int i = 1; i <= 5; i += 1)
            {
                Thread.Sleep(200);
                Console.Write("{0}{1}", y, x);
            }
            Thread.Sleep(200);
            Console.WriteLine();
            for (int i = 1; i <= 4; i += 1)
            {
                Thread.Sleep(200);
                Console.Write("{0}", x);
            }
            for (int i = 1; i <= 3; i += 1)
            {
                Thread.Sleep(200);
                Console.Write("{0}{1}", y, x);
            }
            Thread.Sleep(200);
            Console.WriteLine();
            for (int i = 1; i <= 6; i += 1)
            {
                Thread.Sleep(200);
                Console.Write("{0}", x);
            }
            Thread.Sleep(200);
            Console.Write("{0}{1}", y, x);
            for (int i = 1; i <= 8; i += 1)
            {
                Thread.Sleep(200);
                Console.Write("{0}", x);
            }
            Thread.Sleep(200);
            Console.Write("{0}", y);
        }
    }
}
