using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PiDay
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int picount = 0; //counter for char
            const ConsoleColor f = ConsoleColor.Green; //fill
            const ConsoleColor e = ConsoleColor.Gray; //empty
            List<string> rows = new List<string>(); //string rows for pi symbol
            string PiNum = String.Empty; //100000 digits of number pi.
            using (var rdr = new StreamReader("pi.txt")) //reader for pi symbol
            {
                while(rdr.EndOfStream == false)
                {
                    rows.Add(rdr.ReadLine());
                }
            }
            using (var rdr = new StreamReader("pi2.txt")) //reader for pi number 
            {
                PiNum= rdr.ReadToEnd();
            }
            Console.WriteLine("Happy Pi Day!"); //simple text
            Console.ReadLine(); //waiting user command
            Console.Clear(); //clearing the screen before show!
            for (int i = 0; i < rows.Count; i++) //for every row
            {
                foreach(char item in rows[i]) //for every digit of row
                {
                    Console.ForegroundColor = e; //set color to empty
                    if(item == ' ')
                    {
                        //if char is White Space then foregroundcolor must be fill
                        Console.ForegroundColor = f;
                    }
                    Console.Write(PiNum[picount++]); //put pi numbers 1 digit and increase counter 1 same time
                    System.Threading.Thread.Sleep(1 / 3); // wait 0.3333 milisec
                }
                Console.WriteLine(); //new line after 1 row
            }
            Console.ReadLine(); //wait right before closing the app
        }
    }
}
//jellybeanci 2019 3 14