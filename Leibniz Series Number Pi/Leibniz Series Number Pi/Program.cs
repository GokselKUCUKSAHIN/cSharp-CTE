using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leibniz_Series_Number_Pi
{
    class Program
    {
        static void Main(string[] args)
        {
            double pi = 1;
            for (long i = 0; i < 100000000L; i++)
            {
                double x = i * 2 + 3;
                if (i % 2 == 0)
                {
                    pi -= (1 / (double)x);
                }
                else
                {
                    pi += (1 / (double)x);
                }
                Console.WriteLine(4*pi);
            }
        }
    }
}
