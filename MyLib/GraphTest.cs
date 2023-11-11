using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MyLib
{
    [TestFixture]
    internal class GraphTest
    {
        [Test]
        public void Empty_Constructor_Test()
        {
            Graph g = new Graph();
            Assert.AreEqual(g.Nodes.Count, 0);
        }

        [Test]
        public void Property_Nodes_Test()
        {
            Graph g = new Graph();
            g.AddNode(1);
            g.AddNodes(new[] { 2, 3, 5});

            Assert.AreEqual(g.Nodes.Count, 4);
        }

        [Test]
        public void Property_Count_Test()
        {
            Graph g = new Graph();
            g.AddNode(1);
            g.AddNodes(new[] { 2, 3, 5 });

            Assert.AreEqual(g.Count, 5);
        }
    }
}
