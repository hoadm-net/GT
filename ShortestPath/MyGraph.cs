using MyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    internal class MyGraph: WeightedGraph
    {
        public MyGraph() : base() { }

        public MyGraph(string path, SourceType sourceType) :
            base(path, sourceType)
        { }


        public void DebugDijkstra(int[] dist, int[] pre)
        {
            for (int i = 1; i <= Count; i++)
            {
                Console.Write($"{i:00} ");
            }
            Console.WriteLine();

            foreach (int d in dist)
            {
                Console.Write($"{d:00} ");
            }
            Console.WriteLine();


            foreach (int p in pre)
            {
                Console.Write($"{p:00} ");
            }
        }
        public void Dijkstra(int s)
        {
            int INF = int.MaxValue;
            int[] dist = new int[Count];
            int[] pre = new int[Count];
            PriorityQueue<int, int> queue = new PriorityQueue<int, int>();

            for(int i = 0; i < Count; i++)
            {
                dist[i] = INF;
            }

            dist[s - 1] = 0;
            queue.Enqueue(s, 0);

            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                foreach(Tuple<int, int> v in GetNeighbors(u))
                {
                    int dv = dist[u - 1] + v.Item2;
                    if (dist[v.Item1 -1] > dv)
                    {
                        dist[v.Item1 - 1] = dv;
                        pre[v.Item1 - 1] = u;
                        queue.Enqueue(v.Item1, dv);
                    }
                }
            }

            DebugDijkstra(dist, pre);
        }
    }
}
