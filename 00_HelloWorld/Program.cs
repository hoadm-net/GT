using MyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WeightedDirectedGraph g = WeightedDirectedGraph.LoadFromEdgeListFile("E:\\Code\\GT\\00_HelloWorld\\Data\\G_01.INP");


            g.PrintAdjMatrix();
            Console.WriteLine();
            g.PrintAdjList();
            Console.WriteLine();
            g.PrintEdgeList();
        }
    }
}
