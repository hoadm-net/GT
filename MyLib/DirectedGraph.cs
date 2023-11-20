using System;
using System.Collections.Generic;
using System.IO;


namespace MyLib
{
    public class DirectedGraph:Graph
    {
        public DirectedGraph()
            : base() { }
        public DirectedGraph(string path, SourceType source_type)
            : base(path, source_type) { }

        public override void AddEdge(int u, int v)
        {
            _adj[u].AddLast(v);
        }
    }
}
