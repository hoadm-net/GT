using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class DirectedGraph
    {
        private LinkedList<int> _nodes;
        private Dictionary<int, LinkedList<int>> _adj;

        public DirectedGraph()
        {
            _nodes = new LinkedList<int>();
            _adj = new Dictionary<int, LinkedList<int>>();
        }

        public LinkedList<int> Nodes
        {
            get { return _nodes; }
        }

        public int Count
        {
            get { return _nodes.Count; }
        }

        public void AddNodes(int nodes)
        {
            for (int i = 1; i <= nodes; i++)
            {
                _nodes.AddLast(i);
                _adj[i] = new LinkedList<int>();
            }
        }

        public void AddEdge(int u, int v)
        {
            _adj[u].AddLast(v);
        }

        public int[,] GetAdjMatrix()
        {
            int[,] matrix = new int[Count, Count];

            for (int i = 1; i <= Count; i++)
            {
                foreach (int node in _adj[i])
                {
                    matrix[i - 1, node - 1] = 1;
                }
            }

            return matrix;
        }

        public LinkedList<int>[] GetAdjList()
        {
            LinkedList<int>[] ajdList = new LinkedList<int>[Count];
            for (int i = 1; i <= Count; i++)
            {
                ajdList[i - 1] = new LinkedList<int>();
                ajdList[i - 1] = _adj[i];
            }

            return ajdList;
        }

        public LinkedList<Edge> GetEdgeList()
        {
            LinkedList<Edge> edges = new LinkedList<Edge>();

            for (int i = 1; i <= Count; i++)
            {
                foreach (int node in _adj[i])
                {
                    edges.AddLast(new Edge(i, node));
                }
            }

            return edges;
        }

        public void PrintAdjMatrix()
        {
            int[,] matrix = GetAdjMatrix();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public void PrintAdjList()
        {
            LinkedList<int>[] list = GetAdjList();

            for (int i = 0; i < Count; i++)
            {
                Console.Write($"{i + 1}: ");
                foreach (int node in list[i])
                {
                    Console.Write($"{node} ");
                }
                Console.WriteLine();
            }
        }

        public void PrintEdgeList()
        {
            LinkedList<Edge> edges = GetEdgeList();
            foreach (Edge edge in edges)
            {
                Console.WriteLine(edge);
            }
        }

        public static DirectedGraph LoadFromAdjacencyMatrixFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
            string[] lines = File.ReadAllLines(path);

            DirectedGraph graph = new DirectedGraph();
            int nodes = int.Parse(lines[0]);
            graph.AddNodes(nodes);

            for (int i = 1; i <= nodes; i++)
            {
                string[] values = lines[i].Split();
                for (int j = 0; j < nodes; j++)
                {
                    if (int.Parse(values[j]) == 1)
                    {
                        graph.AddEdge(i, j + 1);
                    }
                }
            }

            return graph;
        }

        public static DirectedGraph LoadFromAdjacencyListFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            string[] lines = File.ReadAllLines(path);
            DirectedGraph graph = new DirectedGraph();

            int nodes = int.Parse(lines[0]);
            graph.AddNodes(nodes);

            for (int i = 1; i <= nodes; i++)
            {
                if (lines[i] == "")
                {
                    continue;
                }

                string[] values = lines[i].Split();
                foreach (string v in values)
                {
                    graph.AddEdge(i, int.Parse(v));
                }
            }
            return graph;
        }

        public static DirectedGraph LoadFromEdgeListFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            string[] lines = File.ReadAllLines(path);
            DirectedGraph graph = new DirectedGraph();

            string[] args = lines[0].Split();
            int nodes = int.Parse(args[0]);
            int edges = int.Parse(args[1]);

            graph.AddNodes(nodes);

            for (int i = 1; i <= edges; i++)
            {
                string[] values = lines[i].Split();
                int u = int.Parse(values[0]);
                int v = int.Parse(values[1]);
                graph.AddEdge(u, v);
            }

            return graph;
        }
    }
}
