using MyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Tree.Classes
{
    internal class MyWeightedGraph : WeightedGraph
    {
        public MyWeightedGraph() { }
        public MyWeightedGraph(string path, SourceType sourceType) :
            base(path, sourceType)
        { }

        private int Find(int[] parent, int cv)
        {
            if (parent[cv - 1] == cv)
            {
                return cv;
            }

            return Find(parent, parent[cv - 1]);
        }

        private void Union(int[] parent, int x, int y)
        {
            parent[x - 1] = y;
        }


        public void Kruskal()
        {
            LinkedList<WeightedEdge> edgeList = GetEdgeList();
            IEnumerable<WeightedEdge> orderedEdgeList = edgeList.OrderBy(edge => edge.W);
            LinkedList<WeightedEdge> msTree = new LinkedList<WeightedEdge>();

            int[] parent = new int[Count];
            for (int i = 1; i <= Count; i++)
            {
                parent[i - 1] = i;
            }

            foreach (WeightedEdge edge in orderedEdgeList)
            {
                int x = Find(parent, edge.U);
                int y = Find(parent, edge.V);

                if (x != y)
                {
                    msTree.AddLast(edge);
                    Union(parent, x, y);
                }
            }


         
            int cost = 0;
            foreach (WeightedEdge e in msTree)
            {
                Console.WriteLine(e);
                cost += e.W;
            }

            Console.WriteLine("------------------------");
            Console.WriteLine($"Edges: {msTree.Count}");
            Console.WriteLine($"Total weight: {cost}");
        }

        public void Prim(int s)
        {
            LinkedList<int> msTreeNodes = new();
            LinkedList<WeightedEdge> msTree = new();
            PriorityQueue<WeightedEdge, int> queue = new();
            LinkedList<WeightedEdge> edgeList = GetEdgeList();

            // int s = 1; // random vertex?
            msTreeNodes.AddLast(s);

            while (msTreeNodes.Count < Count)
            {
                foreach (WeightedEdge e in edgeList)
                {
                    if (
                        msTree.Contains(e) || 
                        (msTreeNodes.Contains(e.U) && msTreeNodes.Contains(e.V))
                    )  continue;
                    
                    if (msTreeNodes.Contains(e.U) || msTreeNodes.Contains(e.V)) {
                        queue.Enqueue(e, e.W);
                    }
                }

                WeightedEdge be = queue.Dequeue();
                int newVertex = msTreeNodes.Contains(be.U) ? be.V : be.U;
                msTreeNodes.AddLast(newVertex);
                msTree.AddLast(be);
                queue.Clear();
            }


            int cost = 0;
            foreach (WeightedEdge e in msTree)
            {
                Console.WriteLine(e);
                cost += e.W;
            }

            Console.WriteLine("------------------------");
            Console.WriteLine($"Edges: {msTree.Count}");
            Console.WriteLine($"Total weight: {cost}");
        }
    }
}
