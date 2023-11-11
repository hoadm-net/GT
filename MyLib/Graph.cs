using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Graph
    {
        private LinkedList<int> _nodes;
        private Dictionary<int, LinkedList<int>> _adj;
        
        public Graph() {
            _nodes = new LinkedList<int>();
            _adj = new Dictionary<int, LinkedList<int>>();
        }

        public LinkedList<int> Nodes
        {
            get { return _nodes; }
        }

        public int Count
        {
            get
            {
                if (_nodes.Count == 0)
                {
                    return 0;
                }

                return _nodes.Max();
            }
        }

        public void AddNode(int node)
        {
            if (!_nodes.Contains(node))
            {
                _nodes.AddLast(node);
            }
        }

        public void AddNodes(int[] nodes)
        {
            foreach (int node in nodes)
            {
                AddNode(node);
            }
        }

        private void AddAdj(int u, int v)
        {
            if (!_nodes.Contains(u))
            {
                throw new Exception($"Node {u} is invalid!!!");
            }

            if (!_adj.ContainsKey(u)) {
                _adj[u] = new LinkedList<int>();
                _adj[u].AddLast(v);
            } else
            {
                _adj[u].AddLast(v);
            }
        }

        public void AddEdge(Edge e)
        {
            AddAdj(e.U, e.V);
            AddAdj(e.V, e.U);
        }

        public void AddEdges(Edge[] edges)
        {
            foreach (Edge edge in edges)
            {
                AddEdge(edge);
            }
        }

        public int[,] GetAdjMatrix()
        {
            int n = this.Count + 1;
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                if (!_adj.ContainsKey(i))
                {
                    continue;
                }

                for (int j = 0; j < n; j++)
                {
                    if (_adj[i].Contains(j))
                    {
                        matrix[i, j] = 1;
                    }
                }
            }

            return matrix;
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


        public LinkedList<int>[] GetAdjList()
        {
            int max = _adj.Keys.Max();
            LinkedList<int>[] list = new LinkedList<int>[max+1];
            for (int i = 0; i <= max; i++)
            {
                if (_adj.ContainsKey(i))
                {
                    list[i] = _adj[i];
                } else
                {
                    list[i] = new LinkedList<int>();
                }
            }

            return list;
        }

        public void PrintAdjList()
        {
            int max = _adj.Keys.Max();
            LinkedList<int>[] list = GetAdjList();

            for (int i = 0; i <= max; i++)
            {
                Console.Write($"{i}: ");
                for(LinkedListNode<int> node = list[i].First; node != null; node = node.Next)
                {
                    Console.Write($"{node.Value} ");
                }
                Console.WriteLine();
            }
        }

        public LinkedList<Edge> GetEdgeList()
        {
            LinkedList<Edge> edges = new LinkedList<Edge>();

            foreach(KeyValuePair<int, LinkedList<int>> item in _adj)
            {
                foreach(int neighbor in item.Value)
                {
                    if (neighbor > item.Key)
                    {
                        edges.AddLast(new Edge(item.Key, neighbor));
                    }
                }
            }

            return edges;
        }

        public void PrintEdgeList()
        {
            LinkedList<Edge> edges = GetEdgeList();
            foreach (Edge edge in edges)
            {
                Console.WriteLine(edge);
            }
        }
        
    }
}
