using MyLib;

namespace ShortestPath
{
    internal class Program
    {
        public static void BuildGraph()
        {
            MyGraph g = new MyGraph();
            g.AddNodes(6);
            g.AddEdge(1, 2, 4);
            g.AddEdge(1, 3, 2);
            g.AddEdge(2, 3, 1);
            g.AddEdge(2, 4, 5);
            g.AddEdge(3, 4, 8);
            g.AddEdge(3, 5, 10);
            g.AddEdge(4, 5, 2);
            g.AddEdge(4, 6, 6);
            g.AddEdge(5, 6, 5);

            g.PrintEdgeList();
            g.PrintAdjMatrix();
        }
        static void Main(string[] args)
        {
            //BuildGraph();
            MyGraph g = new MyGraph("E:\\Code\\GT\\ShortestPath\\Data\\AdjMatrix.INP", SourceType.AdjMatrix);
            g.Dijkstra(1);

        }
    }
}