using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MyLib.Test
{
    [TestFixture]
    internal class DiGraphTest
    {
        string dataDir = "D:\\Code\\GT\\MyLib\\Test\\Data\\";
        string adjMatrix = "";
        string adjList = "";
        string edgeList = "";

        [SetUp]
        public void Init()
        {
            adjMatrix = dataDir + "DGraph_AdjMatrix.INP";
            adjList = dataDir + "DGraph_AdjList.INP";
            edgeList = dataDir + "DGraph_EdgeList.INP";
        }

        private void Expect(DirectedGraph g)
        {
            int[,] adjMatrix = g.GetAdjMatrix();
            LinkedList<int>[] adjList = g.GetAdjList();
            LinkedList<Edge> edgeList = g.GetEdgeList();

            // Properties
            Assert.AreEqual(g.Count, 6);

            // Nodes
            Assert.AreEqual(g.Nodes.First.Value, 1);
            Assert.AreEqual(g.Nodes.Last.Value, 6);

            // Adjacency Matrix
            Assert.AreEqual(6, adjMatrix.GetLength(0));
            Assert.AreEqual(6, adjMatrix.GetLength(1));

            Assert.AreEqual(1, adjMatrix[0, 1]);
            Assert.AreEqual(1, adjMatrix[0, 3]);
            Assert.AreEqual(1, adjMatrix[1, 2]);
            Assert.AreEqual(1, adjMatrix[2, 4]);
            Assert.AreEqual(1, adjMatrix[2, 5]);
            Assert.AreEqual(1, adjMatrix[3, 4]);
            Assert.AreEqual(1, adjMatrix[4, 5]);
            Assert.AreEqual(1, adjMatrix[2, 4]);

            Assert.AreEqual(0, adjMatrix[3, 1]);
            Assert.AreEqual(0, adjMatrix[3, 5]);
            Assert.AreEqual(0, adjMatrix[4, 2]);
            Assert.AreEqual(0, adjMatrix[4, 3]);
            Assert.AreEqual(0, adjMatrix[4, 1]);
            Assert.AreEqual(0, adjMatrix[0, 4]);
            Assert.AreEqual(0, adjMatrix[1, 4]);
            Assert.AreEqual(0, adjMatrix[3, 2]);
            Assert.AreEqual(0, adjMatrix[0, 0]);
            Assert.AreEqual(0, adjMatrix[1, 1]);
            Assert.AreEqual(0, adjMatrix[2, 2]);
            Assert.AreEqual(0, adjMatrix[3, 3]);
            Assert.AreEqual(0, adjMatrix[4, 4]);
            Assert.AreEqual(0, adjMatrix[5, 5]);

            // Adjacency List
            Assert.AreEqual(6, adjList.Length);
            Assert.AreEqual(2, adjList[0].Count);
            Assert.AreEqual(1, adjList[1].Count);
            Assert.AreEqual(2, adjList[2].Count);
            Assert.AreEqual(1, adjList[3].Count);
            Assert.AreEqual(1, adjList[4].Count);
            Assert.AreEqual(0, adjList[5].Count);

            // Edge List
            Assert.AreEqual(1, edgeList.First.Value.U);
            Assert.AreEqual(2, edgeList.First.Value.V);
            Assert.AreEqual(5, edgeList.Last.Value.U);
            Assert.AreEqual(6, edgeList.Last.Value.V);
        }

        [Test]
        public void EmptyConstructorTest()
        {
            DirectedGraph g = new DirectedGraph();
            g.AddNodes(6);
            g.AddEdge(1, 2);
            g.AddEdge(1, 4);
            g.AddEdge(2, 3);
            g.AddEdge(3, 5);
            g.AddEdge(3, 6);
            g.AddEdge(4, 5);
            g.AddEdge(5, 6);

            Expect(g);
        }

        [Test]
        public void AdjMatrixTest()
        {
            DirectedGraph g = new DirectedGraph(adjMatrix, SourceType.AdjMatrix);
            Expect(g);
        }

        [Test]
        public void AdjListTest()
        {
            DirectedGraph g = new DirectedGraph(adjList, SourceType.AdjList);
            Expect(g);
        }

        [Test]
        public void EdgeListTest()
        {
            DirectedGraph g = new DirectedGraph(edgeList, SourceType.EdgeList);
            Expect(g);
        }
    }
}
