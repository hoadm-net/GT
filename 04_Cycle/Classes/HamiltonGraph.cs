using MyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Cycle.Classes
{
    internal class HamiltonGraph : Graph
    {
        private int[] _trail;
        private int[,] _aMatrix;
        
        public HamiltonGraph() : base() { 
            _trail = new int[Count + 1];
            _aMatrix = GetAdjMatrix();
        }

        public HamiltonGraph(string path, SourceType sourceType) :
            base(path, sourceType)
        {
            _trail = new int[Count + 1];
            _aMatrix = GetAdjMatrix();
        }

        private bool IsSafe(int v, int step)
        {
            // if e = (uv)
            int u = _trail[step - 1];
            if (_aMatrix[u - 1, v - 1] == 0)
            {
                return false; 
            }

            for (int i = 0; i < Count; i++)
            {
                if (_trail[i] == v)
                {
                    return false; // v is already in trail
                }
            }

            return true;
        }

        public bool Try(int step)
        {
            if (step == Count)
            {
                int firstNode = _trail[0] - 1;
                int lastNode = _trail[step - 1] - 1;
                return _aMatrix[firstNode, lastNode] == 1;
            }

            for (int v = 1; v <= Count; v++)
            {
                if (IsSafe(v, step))
                {
                    _trail[step] = v;
                    if (Try(step + 1))
                    {
                        return true;
                    }
                    else
                    {
                        _trail[step] = 0;
                    }
                }
            }


            return false;
        }
        public void Solve(int s)
        {
            // step 0, init
            _trail[0] = s;

            // try step 1
            if (Try(1)) 
            {
                _trail[Count] = s;
                Helpers.PrintArray(_trail);
            } else
            {
                Console.WriteLine("Solution does not exist!!!");
            }
        }

    }
}
