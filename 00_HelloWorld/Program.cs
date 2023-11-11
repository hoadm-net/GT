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
            Graph g = new Graph();
            g.AddNodes(new int[] { 0, 1, 2, 3});
            g.AddEdge(new Edge(0, 1));
            g.AddEdge(new Edge(0, 2));
            g.AddEdge(new Edge(0, 3));


            g.PrintAdjMatrix();

            Console.WriteLine();
            g.PrintAdjList();

            Console.WriteLine();
            g.PrintEdgeList();
        }
    }
}
