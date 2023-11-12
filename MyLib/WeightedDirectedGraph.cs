using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class WeightedDirectedGraph
    {
        private LinkedList<int> _nodes;
        private Dictionary<int, LinkedList<Tuple<int, int>>> _adj;

        public WeightedDirectedGraph()
        {
            _nodes = new LinkedList<int>();
            _adj = new Dictionary<int, LinkedList<Tuple<int, int>>>();
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
                _adj[i] = new LinkedList<Tuple<int, int>>();
            }
        }

        public void AddEdge(int u, int v, int w)
        {
            _adj[u].AddLast(new Tuple<int, int>(v, w));
        }

        public int[,] GetAdjMatrix()
        {
            int[,] matrix = new int[Count, Count];

            for (int i = 1; i <= Count; i++)
            {
                foreach (Tuple<int, int> node in _adj[i])
                {
                    matrix[i - 1, node.Item1 - 1] = node.Item2;
                }
            }

            return matrix;
        }

        public LinkedList<Tuple<int, int>>[] GetAdjList()
        {
            LinkedList<Tuple<int, int>>[] ajdList = new LinkedList<Tuple<int, int>>[Count];
            for (int i = 1; i <= Count; i++)
            {
                ajdList[i - 1] = new LinkedList<Tuple<int, int>>();
                ajdList[i - 1] = _adj[i];
            }

            return ajdList;
        }

        public LinkedList<WeightedEdge> GetEdgeList()
        {
            LinkedList<WeightedEdge> edges = new LinkedList<WeightedEdge>();

            for (int i = 1; i <= Count; i++)
            {
                foreach (Tuple<int, int> node in _adj[i])
                {
                    if (node.Item1 > i)
                    {
                        edges.AddLast(new WeightedEdge(i, node.Item1, node.Item2));
                    }
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
            LinkedList<Tuple<int, int>>[] list = GetAdjList();

            for (int i = 0; i < Count; i++)
            {
                Console.Write($"{i + 1}: ");
                foreach (Tuple<int, int> node in list[i])
                {
                    Console.Write($"({node.Item1}, {node.Item2}) ");
                }
                Console.WriteLine();
            }
        }

        public void PrintEdgeList()
        {
            LinkedList<WeightedEdge> edges = GetEdgeList();
            foreach (Edge edge in edges)
            {
                Console.WriteLine(edge);
            }
        }

        public static WeightedDirectedGraph LoadFromAdjacencyMatrixFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
            string[] lines = File.ReadAllLines(path);

            WeightedDirectedGraph graph = new WeightedDirectedGraph();
            int nodes = int.Parse(lines[0]);
            graph.AddNodes(nodes);

            for (int i = 1; i <= nodes; i++)
            {
                string[] values = lines[i].Split();
                for (int j = i; j < nodes; j++)
                {
                    int w = int.Parse(values[j]);
                    if (w != 0)
                    {
                        graph.AddEdge(i, j + 1, w);
                    }
                }
            }

            return graph;
        }

        public static WeightedDirectedGraph LoadFromEdgeListFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            string[] lines = File.ReadAllLines(path);
            WeightedDirectedGraph graph = new WeightedDirectedGraph();

            string[] args = lines[0].Split();
            int nodes = int.Parse(args[0]);
            int edges = int.Parse(args[1]);

            graph.AddNodes(nodes);

            for (int i = 1; i <= edges; i++)
            {
                string[] values = lines[i].Split();
                int u = int.Parse(values[0]);
                int v = int.Parse(values[1]);
                int w = int.Parse(values[2]);
                graph.AddEdge(u, v, w);
            }

            return graph;
        }
    }
}
