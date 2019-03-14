using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_e_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Number Limit ->");
            int limit = Int32.Parse(Console.ReadLine());
            double last;
            int max = (int)Math.Pow(2, 32) - 1;
            Console.WriteLine(max);
            last = Euler(max);
            Console.WriteLine(last);

            for (int i = 1; i <= max; i+=250)
            {
                Console.WriteLine("{0}-) {1}",i,Euler(i));
                
            }
        }
        private static double Euler(double n)
        {
            return Math.Pow(1 + 1 / n, n);
        }
    }
}
