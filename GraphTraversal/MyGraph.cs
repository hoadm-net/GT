using MyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTraversal
{
    internal class MyGraph: Graph
    {
        public MyGraph(): base() { }

        public MyGraph(string path, SourceType sourceType):
            base(path, sourceType) { }


        public void BFS(int s)
        {
            bool[] visited = new bool[Count];
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(s);
            visited[s - 1] = true;
            Console.Write($"{s} -> ");

            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                foreach(int v in GetNeighbors(u))
                {
                    if (visited[v - 1] == false)
                    {
                        Console.Write($"{v} -> ");
                        visited[v - 1] = true;
                        queue.Enqueue(v);
                    }
                }
            }

            Console.WriteLine("|");
        }

        public void BFS(int s, int t)
        {
            bool[] visited = new bool[Count];
            int[] pre = new int[Count];
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(s);
            visited[s - 1] = true;

            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                foreach (int v in GetNeighbors(u))
                {
                    if (visited[v - 1] == false)
                    {
                        visited[v - 1] = true;
                        pre[v - 1] = u;
                        queue.Enqueue(v);
                    }
                }
            }

            MyGraph.PrintPath(s, t, pre);
        }


        public void DFS(int s)
        {
            bool[] visited = new bool[Count];
            int[] pre = new int[Count];
            Stack<int> stack = new Stack<int>();

            stack.Push(s);

            while (stack.Count > 0)
            {
                int u = stack.Pop();
                if (!visited[u - 1])
                {
                    visited[u - 1] = true;
                    Console.Write($"{u} -> ");

                    foreach (int v in GetNeighbors(u))
                    {
                        if (!visited[v - 1])
                        {
                            stack.Push(v);
                            pre[v - 1] = u;
                        }
                        
                    }
                }
            }

            Console.WriteLine("|stop|");
        }


        public void Visit(bool[] visited, int u)
        {
            if (visited[u - 1])
            {
                return;
            }

            visited[u - 1] = true;
            Console.Write($"{u} -> ");

            foreach (int v in GetNeighbors(u))
            {
                Visit(visited, v);
            }
        }

        public void DFS_R(int s)
        {
            bool[] visited = new bool[Count];
            Visit(visited, s);
        }
    }
}
