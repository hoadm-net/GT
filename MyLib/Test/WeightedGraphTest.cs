using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace MyLib.Test
{
    [TestFixture]
    internal class WeightedGraphTest
    {
        string dataDir = "D:\\Code\\GT\\MyLib\\Test\\Data\\";
        string adjMatrix = "";
        string edgeList = "";

        [SetUp]
        public void Init()
        {
            adjMatrix = dataDir + "WGraph_AdjMatrix.INP";
            edgeList = dataDir + "WGraph_EdgeList.INP";
        }

        private void Expect(WeightedGraph g)
        {
            int[,] adjMatrix = g.GetAdjMatrix();
            LinkedList<Tuple<int, int>>[] adjList = g.GetAdjList();
            LinkedList<WeightedEdge> edgeList = g.GetEdgeList();

            // Properties
            Assert.AreEqual(g.Count, 4);

            // Nodes
            Assert.AreEqual(g.Nodes.First.Value, 1);
            Assert.AreEqual(g.Nodes.Last.Value, 4);

            // Adjacency Matrix
            Assert.AreEqual(4, adjMatrix.GetLength(0));
            Assert.AreEqual(4, adjMatrix.GetLength(1));

            Assert.AreEqual(25, adjMatrix[0, 1]);
            Assert.AreEqual(25, adjMatrix[1, 0]);
            Assert.AreEqual(13, adjMatrix[1, 2]);
            Assert.AreEqual(13, adjMatrix[2, 1]);
            Assert.AreEqual(17, adjMatrix[2, 3]);
            Assert.AreEqual(17, adjMatrix[3, 2]);
            Assert.AreEqual(10, adjMatrix[0, 3]);
            Assert.AreEqual(10, adjMatrix[3, 0]);

            Assert.AreEqual(0, adjMatrix[0, 0]);
            Assert.AreEqual(0, adjMatrix[0, 2]);
            Assert.AreEqual(0, adjMatrix[1, 1]);
            Assert.AreEqual(0, adjMatrix[1, 3]);
            Assert.AreEqual(0, adjMatrix[2, 0]);
            Assert.AreEqual(0, adjMatrix[2, 2]);
            Assert.AreEqual(0, adjMatrix[3, 1]);
            Assert.AreEqual(0, adjMatrix[3, 3]);

            // Adjacency List
            Assert.AreEqual(4, adjList.Length);
            Assert.AreEqual(2, adjList[0].Count);
            Assert.AreEqual(2, adjList[1].Count);
            Assert.AreEqual(2, adjList[2].Count);
            Assert.AreEqual(2, adjList[3].Count);

            // Edge List
            Assert.AreEqual(1, edgeList.First.Value.U);
            Assert.AreEqual(2, edgeList.First.Value.V);
            Assert.AreEqual(25, edgeList.First.Value.W);
            Assert.AreEqual(3, edgeList.Last.Value.U);
            Assert.AreEqual(4, edgeList.Last.Value.V);
            Assert.AreEqual(17, edgeList.Last.Value.W);
        }

        [Test]
        public void EmptyConstructorTest()
        {
            WeightedGraph g = new WeightedGraph();
            g.AddNodes(4);
            g.AddEdge(1, 2, 25);
            g.AddEdge(1, 4, 10);
            g.AddEdge(2, 3, 13);
            g.AddEdge(3, 4, 17);

            Expect(g);
        }

        [Test]
        public void AdjMatrixTest()
        {
            WeightedGraph g = new WeightedGraph(adjMatrix, SourceType.AdjMatrix);
            Expect(g);
        }

        [Test]
        public void EdgeListTest()
        {
            WeightedGraph g = new WeightedGraph(edgeList, SourceType.EdgeList);
            Expect(g);
        }
    }
}
