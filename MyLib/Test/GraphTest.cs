using NUnit.Framework;
using System.Collections.Generic;

namespace MyLib.Test
{
/*   Graph 01
                
    4 - - 5 - - 6
    |     |     |
    2 - - 3     7
     \   /
       1
*/

    [TestFixture]
    internal class GraphTest
    {
        string dataDir = "E:\\Code\\GT\\MyLib\\Test\\Data\\";
        string adjMatrix = "";
        string adjList = "";
        string edgeList = "";

        [SetUp]
        public void Init()
        {
            adjMatrix = dataDir + "Graph_AdjMatrix.INP";
            adjList = dataDir + "Graph_AdjList.INP";
            edgeList = dataDir + "Graph_EdgeList.INP";
        }

        private void Expect(Graph g)
        {
            int[,] adjMatrix = g.GetAdjMatrix();
            LinkedList<int>[] adjList = g.GetAdjList();
            LinkedList<Edge> edgeList = g.GetEdgeList();

            // Properties
            Assert.AreEqual(g.Count, 7);

            // Nodes
            Assert.AreEqual(g.Nodes.First.Value, 1);
            Assert.AreEqual(g.Nodes.Last.Value, 7);

            // Adjacency Matrix
            Assert.AreEqual(7, adjMatrix.GetLength(0));
            Assert.AreEqual(7, adjMatrix.GetLength(1));
            Assert.AreEqual(1, adjMatrix[0, 1]);
            Assert.AreEqual(1, adjMatrix[0, 2]);
            Assert.AreEqual(1, adjMatrix[1, 0]);
            Assert.AreEqual(1, adjMatrix[1, 2]);
            Assert.AreEqual(1, adjMatrix[1, 3]);
            Assert.AreEqual(1, adjMatrix[2, 0]);
            Assert.AreEqual(1, adjMatrix[2, 1]);
            Assert.AreEqual(1, adjMatrix[2, 4]);
            Assert.AreEqual(1, adjMatrix[3, 1]);
            Assert.AreEqual(1, adjMatrix[3, 4]);
            Assert.AreEqual(1, adjMatrix[4, 2]);
            Assert.AreEqual(1, adjMatrix[4, 3]);
            Assert.AreEqual(1, adjMatrix[4, 5]);
            Assert.AreEqual(1, adjMatrix[5, 4]);
            Assert.AreEqual(1, adjMatrix[5, 6]);
            Assert.AreEqual(1, adjMatrix[6, 5]);
            Assert.AreEqual(0, adjMatrix[0, 0]);
            Assert.AreEqual(0, adjMatrix[1, 1]);
            Assert.AreEqual(0, adjMatrix[2, 2]);
            Assert.AreEqual(0, adjMatrix[3, 3]);
            Assert.AreEqual(0, adjMatrix[4, 4]);
            Assert.AreEqual(0, adjMatrix[5, 5]);
            Assert.AreEqual(0, adjMatrix[6, 6]);

            // Adjacency List
            Assert.AreEqual(7, adjList.Length);
            Assert.AreEqual(2, adjList[0].Count);
            Assert.AreEqual(3, adjList[1].Count);
            Assert.AreEqual(3, adjList[2].Count);
            Assert.AreEqual(2, adjList[3].Count);
            Assert.AreEqual(3, adjList[4].Count);
            Assert.AreEqual(2, adjList[5].Count);
            Assert.AreEqual(1, adjList[6].Count);

            // Edge List
            Assert.AreEqual(1, edgeList.First.Value.U);
            Assert.AreEqual(2, edgeList.First.Value.V);
            Assert.AreEqual(6, edgeList.Last.Value.U);
            Assert.AreEqual(7, edgeList.Last.Value.V);
        }

        [Test]
        public void EmptyConstructorTest() 
        {
            Graph g = new Graph();
            g.AddNodes(7);
            g.AddEdge(1, 2);
            g.AddEdge(1, 3);
            g.AddEdge(2, 3);
            g.AddEdge(2, 4);
            g.AddEdge(3, 5);
            g.AddEdge(4, 5);
            g.AddEdge(5, 6);
            g.AddEdge(6, 7);

            Expect(g);
        }

        [Test]
        public void AdjMatrixTest ()
        {
            Graph g = new Graph(adjMatrix, SourceType.AdjMatrix);
            Expect(g);
        }

        [Test] public void AdjListTest ()
        {
            Graph g = new Graph(adjList, SourceType.AdjList);
            Expect(g);
        }

        [Test]
        public void EdgeListTest ()
        {
            Graph g = new Graph(edgeList, SourceType.EdgeList);
            Expect(g);
        }
    }
}
