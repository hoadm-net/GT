using MyLib;

namespace _00_HelloWorld
{
    internal class Program
    {
        
        public static void BuildGraph()
        {
            /*      Graph
                
                4 - - 5 - - 6
                |     |     |
                2 - - 3     7
                 \   /
                   1
            */
            Graph graph = new Graph();
            graph.AddNodes(7);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 5); 
            graph.AddEdge(4, 5);
            graph.AddEdge(5, 6);
            graph.AddEdge(6, 7);

            graph.PrintAdjMatrix();
            graph.PrintAdjList();
            graph.PrintEdgeList();
        }

        public static void BuidDirectedGraph()
        {
            /* Directed Graph
              |--> 2 --> 3 --> 6
              |          |     ^
              1          v     |
              |--> 4 --> 5-----

             */
            DirectedGraph diGraph = new DirectedGraph();
            diGraph.AddNodes(6);
            diGraph.AddEdge(1, 2);
            diGraph.AddEdge(1, 4);
            diGraph.AddEdge(2, 3);
            diGraph.AddEdge(3, 5);
            diGraph.AddEdge(3, 6);
            diGraph.AddEdge(4, 5);
            diGraph.AddEdge(5, 6);

            diGraph.PrintAdjMatrix();
            diGraph.PrintAdjList();
            diGraph.PrintEdgeList();
        }
        

        static void Main(string[] args)
        {
            //BuildGraph();
            //BuidDirectedGraph();
          
        }
    }
}
