using _03_Tree.Classes;
using MyLib;

namespace _03_Tree
{
    internal class Program
    {
        public static void BuildGraph()
        {
            WeightedGraph g = new WeightedGraph();
            g.AddNodes(6);
            g.AddEdge(1,2,3);
            g.AddEdge(1,5,6);
            g.AddEdge(1,6,5);
            g.AddEdge(2,3,1);
            g.AddEdge(2,6,4);
            g.AddEdge(3,4,6);
            g.AddEdge(3,6,4);
            g.AddEdge(4,5,8);
            g.AddEdge(4,6,5);
            g.AddEdge(5,6,2);

            g.PrintAdjMatrix();
        }
        static void Main(string[] args)
        {
            // BuildGraph();
            MyWeightedGraph g = new MyWeightedGraph("D:\\Code\\_CSharp_\\GT\\03_Tree\\Data\\WGraph_AdjMatrix.INP", SourceType.AdjMatrix);

            // g.Kruskal();
            g.Prim(6);
        }
    }
}
