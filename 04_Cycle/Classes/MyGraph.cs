using MyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Cycle.Classes
{
    internal class MyGraph : Graph
    {
        private int[,] _aMatrix = default!;
        public MyGraph() : base() { }

        public MyGraph(string path, SourceType sourceType) :
            base(path, sourceType)
        { }


        private int TryMove(int u)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_aMatrix[u - 1, i] != 0)
                {
                    return i + 1;
                }
            }


            return -1;
        }
        private void RemoveEdge(int u, int v)
        {
            _aMatrix[u - 1, v - 1] = 0;
            _aMatrix[v - 1, u - 1] = 0;
        }

        private void DDStack(Stack<int> s)
        {
            foreach(var e in s)
            {
                Console.Write($"{e} ");
            }
            Console.WriteLine("\n--------------");
        }
        public void Euler(int s)
        {
            _aMatrix = GetAdjMatrix();
            LinkedList<int> EulerTrail = new LinkedList<int>();
            Stack<int> stack = new Stack<int>();
            stack.Push(s);

            while (stack.Any())
            {
                DDStack(stack);
                int currentVertex = stack.Peek();
                int nextVertex = TryMove(currentVertex);
                if (nextVertex == -1)
                {
                    // cannot move
                    EulerTrail.AddLast(stack.Pop());
                }
                else
                {
                    stack.Push(nextVertex);
                    RemoveEdge(currentVertex, nextVertex);
                }
            }

            foreach(int node in  EulerTrail)
            {
                Console.Write($"{node} -> ");
            }
            Console.WriteLine(".");
        }


        // Hamilton
    }
}
