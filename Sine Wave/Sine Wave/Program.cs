using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sine_Wave
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                for(float t = 0; t <= 40f; t+= 0.25f)
                {
                    int a = (int)(27 + 25 * Math.Sin(t));
                    for (int i = 0; i < a; i++)
                        Console.Write(" ");
                    Console.Write("JELLYBEANCI\n");
                    System.Threading.Thread.Sleep(100);
                }
                
            }
        }
    }
}
