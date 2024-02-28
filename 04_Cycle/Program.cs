using _04_Cycle.Classes;
using MyLib;

namespace _04_Cycle
{
    internal class Program
    {
        public static void BuildGraph()
        {
            MyGraph g = new MyGraph();
            g.AddNodes(6);

            g.AddEdge(1, 2);
            g.AddEdge(1, 4);
            g.AddEdge(2, 3);
            g.AddEdge(2, 5);
            g.AddEdge(2, 6);
            g.AddEdge(3, 5);
            g.AddEdge(4, 5);
            g.AddEdge(5, 6);

            g.PrintAdjMatrix();

            //MyGraph g = new MyGraph();
            //g.AddNodes(8);
            //g.AddEdge(1, 2);
            //g.AddEdge(1, 3);
            //g.AddEdge(1, 6);
            //g.AddEdge(2, 3);
            //g.AddEdge(2, 5);
            //g.AddEdge(3, 4);
            //g.AddEdge(3, 7);
            //g.AddEdge(4, 8);
            //g.AddEdge(5, 6);
            //g.AddEdge(6, 7);
            //g.AddEdge(7, 8);

            //g.PrintAdjMatrix();
        }
        static void Main(string[] args)
        {
            // BuildGraph();

            MyGraph g = new MyGraph(
                Helpers.GetDataPath("AdjMatrix.INP"),
                SourceType.AdjMatrix
                );

            g.Euler(1);

            //HamiltonGraph g = new HamiltonGraph(
            //    Helpers.GetDataPath("HamiltonG_AdjMatrix.INP"),
            //    SourceType.AdjMatrix
            //    );
            //g.Solve(1);

        }
    }
}
