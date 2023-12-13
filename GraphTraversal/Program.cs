using MyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTraversal
{
    internal class Program
    {
        public static void BuildGraph()
        {
            Graph graph = new Graph();
            graph.AddNodes(9);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 6);
            graph.AddEdge(1, 8);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);
            graph.AddEdge(3, 8);
            graph.AddEdge(3, 9);
            graph.AddEdge(4, 5);
            graph.AddEdge(5, 7);
            graph.AddEdge(5, 9);
            graph.AddEdge(6, 7);
            graph.AddEdge(7, 9);

            graph.PrintAdjMatrix();
            graph.PrintAdjList();
            graph.PrintEdgeList();
        }

        static void Main(string[] args)
        {
            //BuildGraph();
            MyGraph g = new MyGraph("E:\\Code\\GT\\GraphTraversal\\Data\\AdjMatrix.INP", SourceType.AdjMatrix);

            g.DFS(1);
        }
    }
}
