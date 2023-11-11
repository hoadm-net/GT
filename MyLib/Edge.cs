using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Edge
    {
        protected int _u;
        protected int _v;

        public int U 
        { 
            get { return _u; } 
            set 
            { 
                if (value < 0) {
                    throw new ArgumentOutOfRangeException("value");
                }

                _u = value;
            } 
        }

        public int V
        {
            get { return _v; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }

                _v = value;
            }
        }

        public Edge()
        {
            _u = 0;
            _v = 1;
        }

        public Edge(int u, int v)
        {
            U = u;
            V = v;
        }

        public Edge(Edge other)
        {
            _u = other._u;
            _v = other._v;
        }

        public override string ToString()
        {
            return $"({U}, {V})";
        }
    }
}
