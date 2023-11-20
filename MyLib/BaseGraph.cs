using System.Collections.Generic;


namespace MyLib
{
    public enum SourceType
    {
        AdjMatrix,
        AdjList,
        EdgeList
    }

    public abstract class BaseGraph {
        protected string[] _args;
        protected LinkedList<int> _nodes;

        public LinkedList<int> Nodes
        {
            get { return _nodes; }
        }

        public int Count
        {
            get { return _nodes.Count; }
        }

        protected virtual bool Directed { get { return false; } }

        public abstract void PrintAdjMatrix();
        public abstract void PrintAdjList();
        public abstract void PrintEdgeList();
    }
}
