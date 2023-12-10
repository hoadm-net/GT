using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyLib
{
    public class Graph : BaseGraph
    {
        protected Dictionary<int, LinkedList<int>> _adj;

        public Graph()
        {
            _nodes = new LinkedList<int>();
            _adj = new Dictionary<int, LinkedList<int>>();
        }

        public Graph(string path, SourceType stype)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            string[] lines = File.ReadAllLines(path);
            _args = lines[0].Split();
            _nodes = new LinkedList<int>();
            _adj = new Dictionary<int, LinkedList<int>>();

            int nodes = int.Parse(_args[0]);
            AddNodes(nodes);

            if (stype == SourceType.AdjMatrix)
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
                        if (int.Parse(values[j]) == 1)
                        {
                            AddEdge(i, j + 1);
                        }
                    }
                }
            } else if (stype == SourceType.AdjList)
            {
                for (int i = 1; i <= nodes; i++)
                {
                    if (lines[i] == "")
                    {
                        continue;
                    }

                    string[] values = lines[i].Split();
                    foreach (string v in values)
                    {
                        int vv = int.Parse(v);
                        if (Directed)
                        {
                            AddEdge(i, vv);
                        } else
                        {
                            if (vv > i)
                            {
                                AddEdge(i, vv);
                            }
                        }

                    }
                }
            } else if (stype == SourceType.EdgeList)
            {
                int edges = int.Parse(_args[1]);

                for (int i = 1; i <= edges; i++)
                {
                    string[] values = lines[i].Split();
                    int u = int.Parse(values[0]);
                    int v = int.Parse(values[1]);
                    AddEdge(u, v);
                }
            } else
            {
                throw new ArgumentException("Source type is not valid!!!");
            }
        }

        public void AddNodes(int nodes)
        {
            for (int i = 1; i <= nodes; i++) {
                _nodes.AddLast(i);
                _adj[i] = new LinkedList<int>();
            }
        }

        public void AddEdge(int u, int v)
        {
            if (Directed)
            {
                _adj[u].AddLast(v);
            } else
            {
                _adj[u].AddLast(v);
                _adj[v].AddLast(u);
            }
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
                    if (Directed)
                    {
                        edges.AddLast(new Edge(i, node));
                    } else
                    {
                        if (node > i)
                        {
                            edges.AddLast(new Edge(i, node));
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

            Console.WriteLine();
        }

        public override void PrintEdgeList()
        {
            LinkedList<Edge> edges = GetEdgeList();
            foreach (Edge edge in edges)
            {
                Console.WriteLine(edge);
            }
            Console.WriteLine();
        }

        public LinkedList<int> GetNeighbors(int u)
        {
            if (u < 0 || u > Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _adj[u];
        }

        public static void PrintPath(int s, int t, int[] pre)
        {
            if (pre[t - 1] == 0)
            {
                Console.WriteLine($"There is no path from {s} to {t}");
                return;
            }
            Stack<int> stack = new Stack<int>();
            int u = t;

            while (u != 0)
            {
                stack.Push(u);
                u = pre[u - 1];
            }

            while (stack.Count > 0)
            {
                Console.Write($"{stack.Pop()} -> ");
            }

            Console.WriteLine("|");
        }
    }
}
