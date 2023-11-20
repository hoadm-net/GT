using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class WeightedDirectedGraph: WeightedGraph
    {
        public WeightedDirectedGraph()
            :base() { }

        public WeightedDirectedGraph(string path, SourceType source_type)
            :base(path, source_type) { }

        protected override bool Directed { get { return true; } }
    }
}
