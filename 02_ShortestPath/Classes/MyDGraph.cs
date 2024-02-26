using MyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    internal class MyDGraph : DirectedGraph
    {
        public MyDGraph() : base() { }
        public MyDGraph(string path, SourceType sourceType) :
            base(path, sourceType)
        { }

        public void Warshall()
        {
            int[,] denseMatrix = GetAdjMatrix();
            Helpers.Print2DArray(denseMatrix);
            Console.WriteLine("\n ------------------------ \n");
            
            // duyệt qua đừng đỉnh u
            for (int u = 0; u < Count; u++)
            {
                // với mỗi đỉnh u, duyệt qua từng đỉnh v
                for (int v = 0; v < Count; v++)
                {
                    // kiểm tra thử, u có kề với v không?
                    if (denseMatrix[u, v] == 1)
                    {
                        // duyệt qua từng đỉnh t,
                        // và kiểm tra thử có thể đi từ v -> t không? 
                        // nếu có, -> có đường đi từ u -> t
                        for (int t = 0;  t < Count; t++)
                        {
                            if (denseMatrix[v, t] == 1 && u != t)
                            {
                                denseMatrix[u, t] = 1;
                            }
                        }
                    }
                }
            }

            Helpers.Print2DArray(denseMatrix);
        }
    }
}
