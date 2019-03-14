using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rand
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                int x = r.Next(0, 101);
                Console.WriteLine(x);
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
