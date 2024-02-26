using MyLib;
using ShortestPath;

namespace _02_ShortestPath
{
    internal class Program
    {
        public static void BuildGraph()
        {
            // Graph 1 

            //MyGraph g = new MyGraph();
            //g.AddNodes(6);
            //g.AddEdge(1, 2, 4);
            //g.AddEdge(1, 3, 2);
            //g.AddEdge(2, 3, 1);
            //g.AddEdge(2, 4, 5);
            //g.AddEdge(3, 4, 8);
            //g.AddEdge(3, 5, 10);
            //g.AddEdge(4, 5, 2);
            //g.AddEdge(4, 6, 6);
            //g.AddEdge(5, 6, 5);

            // Graph 2
            MyWDGraph g = new MyWDGraph();
            g.AddNodes(6);
            g.AddEdge(1, 2, 5);
            g.AddEdge(2, 3, 1);
            g.AddEdge(3, 4, 7);
            g.AddEdge(4, 2, -9);
            g.AddEdge(5, 4, 6);
            g.AddEdge(5, 6, 8);

            g.PrintEdgeList();
            g.PrintAdjMatrix();
        }
        static void Main(string[] args)
        {
            // BuildGraph();

            // Diskstra
            //MyGraph g = new MyGraph("D:\\Code\\GT\\ShortestPath\\Data\\AdjMatrix.INP", SourceType.AdjMatrix);
            //g.Dijkstra(1);

            // Bellman_Ford
            //MyWDGraph g = new MyWDGraph("D:\\Code\\GT\\ShortestPath\\Data\\NegativeW_DAG.INP", SourceType.AdjMatrix);
            //MyWDGraph g = new MyWDGraph("D:\\Code\\GT\\ShortestPath\\Data\\NegativeW_G.INP", SourceType.AdjMatrix);
            //g.Bellman_Ford(1);


            // Floyd - Warshall
            // Warshall -> transitive closure

            //MyDGraph g = new MyDGraph("D:\\Code\\GT\\ShortestPath\\Data\\DG_AdjMatrix.INP", SourceType.AdjMatrix);
            //g.Warshall();

            MyGraph g = new MyGraph("D:\\Code\\_CSharp_\\GT\\02_ShortestPath\\Data\\AdjMatrix.INP", SourceType.AdjMatrix);
            g.FloydWarshall();

        }
    }
}
