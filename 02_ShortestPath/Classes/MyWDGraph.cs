using MyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    internal class MyWDGraph : WeightedDirectedGraph
    {
        public MyWDGraph() : base() { }

        public MyWDGraph(string path, SourceType sourceType) :
            base(path, sourceType)
        { }


        public void Bellman_Ford(int s)
        {
            int INF = int.MaxValue;
            int[] dist = new int[Count];
            int[] pre = new int[Count];

            for (int i = 0; i < Count; i++)
            {
                dist[i] = INF;
            }

            dist[s - 1] = 0;
            Helpers.PrintArray(dist);
            Helpers.PrintArray(pre);
            Console.WriteLine("------------------------------");

            for (int i = 0; i < Count - 1; i++)
            {
                bool modified = false;
                for (int u = 1; u <= Count; u++)
                {
                    if (dist[u - 1] == INF)
                    {
                        continue;
                    }

                    foreach (Tuple<int, int> v in GetNeighbors(u))
                    {
                        int dv = dist[u - 1] + v.Item2;
                        if (dist[v.Item1 - 1] > dv)
                        {
                            dist[v.Item1 - 1] = dv;
                            pre[v.Item1 - 1] = u;
                            modified = true;
                        }
                    }
                }
                Helpers.PrintArray(dist);
                Helpers.PrintArray(pre);
                Console.WriteLine("------------------------------");


                if (!modified)
                {
                    break;
                }
            }

            bool hasNegativeCycle = false;
            for (int u = 1; u <= Count; u++)
            {
                if (dist[u - 1] == INF)
                {
                    continue;
                }

                foreach (Tuple<int, int> v in GetNeighbors(u))
                {
                    if (dist[v.Item1 - 1] > dist[u - 1] + v.Item2)
                    {
                        hasNegativeCycle = true;
                    }
                }
            }

            Console.WriteLine("Negative Cycle Exist?");
            if (hasNegativeCycle)
            {
                Console.WriteLine("Yes!");
            }
            else
            {
                Console.WriteLine("No!");
                Console.WriteLine();

                for (int u = 1; u <= Count; u++)
                {
                    Console.WriteLine($"{s} -> {u} = {Helpers.GetDist(dist[u - 1])}");
                }
            }
        }
    }
}
