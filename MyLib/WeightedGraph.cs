using System;
using System.Collections.Generic;
using System.IO;


namespace MyLib
{
    public class WeightedGraph : BaseGraph
    {
        protected Dictionary<int, LinkedList<Tuple<int, int>>> _adj;

        public WeightedGraph()
        {
            _nodes = new LinkedList<int>();
            _adj = new Dictionary<int, LinkedList<Tuple<int, int>>>();
        }

        public WeightedGraph(string path, SourceType source_type)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
            string[] lines = File.ReadAllLines(path);
            _args = lines[0].Split();
            _nodes = new LinkedList<int>();
            _adj = new Dictionary<int, LinkedList<Tuple<int, int>>>();

            int nodes = int.Parse(_args[0]);
            AddNodes(nodes);

            if (source_type == SourceType.AdjMatrix)
            {
                for (int i = 1; i <= nodes; i++)
                {
                    string[] values = lines[i].Split();
                    int j = i;
                    if (Directed)
                    {
                        j = 0;
                    }
                    for (; j < nodes; j++)
                    {
                        int w = int.Parse(values[j]);
                        if (w != 0)
                        {
                            AddEdge(i, j + 1, w);
                        }
                    }
                }
            } else if (source_type == SourceType.EdgeList)
            {
                int edges = int.Parse(_args[1]);

                for (int i = 1; i <= edges; i++)
                {
                    string[] values = lines[i].Split();
                    int u = int.Parse(values[0]);
                    int v = int.Parse(values[1]);
                    int w = int.Parse(values[2]);
                    AddEdge(u, v, w);
                }
            } else
            {
                throw new ArgumentException("Source type is not valid!!!");
            }
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
            if (Directed)
            {
                _adj[u].AddLast(new Tuple<int, int>(v, w));
            }
            else
            {
                _adj[u].AddLast(new Tuple<int, int>(v, w));
                _adj[v].AddLast(new Tuple<int, int>(u, w));
            }
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
                    if (Directed)
                    {
                        edges.AddLast(new WeightedEdge(i, node.Item1, node.Item2));
                    } else
                    {
                        if (node.Item1 > i)
                        {
                            edges.AddLast(new WeightedEdge(i, node.Item1, node.Item2));
                        }
                    }
                    
                }
            }

            return edges;
        }

        public override void PrintAdjMatrix()
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
            Console.WriteLine();
        }

        public override void PrintAdjList()
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
            Console.WriteLine();
        }

        public override void PrintEdgeList()
        {
            LinkedList<WeightedEdge> edges = GetEdgeList();
            foreach (Edge edge in edges)
            {
                Console.WriteLine(edge);
            }
            Console.WriteLine();
        }
    }
}
