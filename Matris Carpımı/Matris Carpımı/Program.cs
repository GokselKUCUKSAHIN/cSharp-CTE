using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matris_Carpımı
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("1. Matrisin Satır sayısı (R): ");
            int R1 = Int32.Parse(Console.ReadLine());
            Console.Write("1. Matrisin Kolon sayısı (C): ");
            int C1 = Int32.Parse(Console.ReadLine());
            Console.Write("2. Matrisin Satır sayısı (R): ");
            int R2 = Int32.Parse(Console.ReadLine());
            Console.Write("2. Matrisin Kolon sayısı (C): ");
            int C2 = Int32.Parse(Console.ReadLine());
            int[,] Matrix = new int[R1, C2];

            int[,] PriMatrix = new int[R1, C1];
            int[,] SecMatrix = new int[R2, C2];

            for (int r = 0; r < R1; r++)
            {
                for (int c = 0; c < C1; c++)
                {
                    Console.Write("1. Matrisin {0}. Satırının {1}. elemanını girin: ", r + 1, c + 1);
                    PriMatrix[r, c] = Int32.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("\n1. Matris Tamam!");
            for (int r = 0; r < R2; r++)
            {
                for (int c = 0; c < C2; c++)
                {
                    Console.Write("2. Matrisin {0}. Satırının {1}. elemanını girin: ", r + 1, c + 1);
                    SecMatrix[r, c] = Int32.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Oluşturuldu\n1.Matris");
            PrintMatrix(PriMatrix);
            Console.WriteLine("2.Matris");
            PrintMatrix(SecMatrix);
            Console.WriteLine();
            for (int i = 0; i < R1; i++)
            {
                for (int j = 0; j < C2; j++)
                {
                    Matrix[i, j] = 0;
                    for (int k = 0; k < C1; k++)
                    {
                        Matrix[i, j] += PriMatrix[i, k] * SecMatrix[k, j];
                    }
                }
            }
            Console.WriteLine("test");
            PrintMatrix(Matrix);
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
        }
        static void PrintMatrix(int[,] M)
        {
            int r = M.GetLength(0);
            int c = M.GetLength(1);
            for (int i = 0; i < r; i++)
            {
                Console.Write("[");
                for (int j = 0; j < c; j++)
                {
                    Console.Write("{0,4} ",M[i,j]);
                }
                Console.WriteLine("]");
            }
        }
    }
}