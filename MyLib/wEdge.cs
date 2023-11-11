using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class wEdge: Edge
    {
        private int _w;

        public int W 
        { 
            get { return _w; }
            set { _w = value; }
        }

        public wEdge(): base()
        {
            W = 0;
        }

        public wEdge(int u, int v, int w): base(u, v)
        {
            W = w;
        }

        public wEdge(wEdge other): base(other.U, other.V)
        {
            W = other.W;
        }

        public override string ToString()
        {
            return $"({U}, {V}, {W})";
        }
    }
}
