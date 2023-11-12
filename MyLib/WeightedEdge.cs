using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class WeightedEdge: Edge
    {
        private int _w;

        public int W 
        { 
            get { return _w; }
            set { _w = value; }
        }

        public WeightedEdge(): base()
        {
            W = 0;
        }

        public WeightedEdge(int u, int v, int w): base(u, v)
        {
            W = w;
        }

        public WeightedEdge(WeightedEdge other): base(other.U, other.V)
        {
            W = other.W;
        }

        public override string ToString()
        {
            return $"({U}, {V}, {W})";
        }
    }
}
