using System;
using System.Text;

namespace Rot13_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // Rotate 13
            while(true)
            {
                Console.Write("Enter a text->");
                String input = Console.ReadLine();
                Console.WriteLine(Rot13Algorithm.Rot13(input));
            }
        }
    }


    class Rot13Algorithm
	{
        public static string Rot13(string source)
        {
            StringBuilder sb = new StringBuilder();
            foreach(char item in source)
            {
                sb.Append(SwitchChar(item));
            }
            return sb.ToString();
        }

        private static char SwitchChar(char input)
        {
            byte value = (byte)input;
            if (value >= 65 && value <= 90) 
            {
                // upper case
                value -= 65;
                return (char)((value + 13) % 26 + 65);
            }
            else if (value >= 97 && value <= 122)
            {
                // lower case
                value -= 97;
                return (char)((value + 13) % 26 + 97);
            }
            else
            {
                // others
                return input;
            }
        }
	}
}