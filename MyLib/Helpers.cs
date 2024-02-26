using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public static class Helpers
    {
        public static void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{GetDist(item), 4}");
            }
            Console.WriteLine();
        }

        public static void Print2DArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{GetDist(arr[i, j]), 4}");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static string GetDist(int dist) 
        {
            return dist == int.MaxValue ? "INF" : dist.ToString();
        }
    }
}
