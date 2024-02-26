using MyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    internal class MyGraph : WeightedGraph
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

            for (int i = 0; i < Count; i++)
            {
                dist[i] = INF;
            }

            dist[s - 1] = 0;
            queue.Enqueue(s, 0);

            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                foreach (Tuple<int, int> v in GetNeighbors(u))
                {
                    int dv = dist[u - 1] + v.Item2;
                    if (dist[v.Item1 - 1] > dv)
                    {
                        dist[v.Item1 - 1] = dv;
                        pre[v.Item1 - 1] = u;
                        queue.Enqueue(v.Item1, dv);
                    }
                }
            }

            DebugDijkstra(dist, pre);
        }

        public void FloydWarshall()
        {
            int INF = int.MaxValue;
            int[,] dist = GetAdjMatrix();
            int[,] pre = new int[Count, Count];

            for (int i = 0; i < Count; i++)
            {
                for (int j = 0; j < Count; j++)
                {
                    if (dist[i, j] == 0)
                    {
                        dist[i, j] = INF;
                    }
                }
            }

            Helpers.Print2DArray(dist);
            Console.WriteLine("\n ------------------------ \n");

            // duyệt qua đừng đỉnh u
            for (int u = 0; u < Count; u++)
            {
                // với mỗi đỉnh u, duyệt qua từng đỉnh v
                for (int v = 0; v < Count; v++)
                {
                    // kiểm tra thử, u có kề với v không?
                    if (u != v && dist[u, v] != INF)
                    {
                        // duyệt qua từng đỉnh t,
                        // và kiểm tra thử có thể đi từ v -> t không? 
                        // nếu có, -> có đường đi từ u -> t 
                        //
                        // kiểm tra thêm 
                        // u != v
                        // và phép co có xảy ra?

                        for (int t = 0; t < Count; t++)
                        {
                            if (
                                dist[v, t] != INF && 
                                u != t &&
                                dist[u, v] + dist[v, t] < dist[u, t]
                                )
                            {
                                dist[u, t] = dist[u, v] + dist[v, t];
                                pre[u, t] = v;
                            }
                        }
                    }
                }
            }

            Helpers.Print2DArray(dist);
            Helpers.Print2DArray(pre);
        }
    }
}
