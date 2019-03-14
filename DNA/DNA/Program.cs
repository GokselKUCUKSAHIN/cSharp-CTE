using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNA
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "....... 0 .......";
            string s2 = "...... o-0 ......";
            string s3 = "..... o---0 .....";
            string s4 = ".... o-----0 ....";
            string s5 = ".... 0-----0 ....";
            string s6 = ".... 0-----o ....";
            string s7 = "..... 0---o .....";
            string s8 = "...... 0-o ......";
            List<string> Anim = new List<string>() { s1,s2,s3,s4,s5,s6,s7,s8};
            int i = 0;
            while (true != false)
            {
                if (i > 7)
                    i = 0;
                Console.WriteLine(Anim[i]);
                i++;
                System.Threading.Thread.Sleep(96);
            }
        }
    }
}
