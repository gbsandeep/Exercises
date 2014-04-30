using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Learning {
    [TestClass]
    public class UTDirectedGraph {
        [TestMethod]
        public void SingleNode() {
            var source = new Node<string>("a");
            Assert.AreEqual(true, DirectedGraph<string>.RouteExistsDFS(source, source));
        }

        [TestMethod]
        public void SinglePath() {
            var node1 = new Node<string>("a");
            var node2 = new Node<string>("b");
            var node3 = new Node<string>("c");
            node1.Neighbors.Add(node2);
            node2.Neighbors.Add(node3);
            Assert.AreEqual(true, DirectedGraph<string>.RouteExistsDFS(node1, node3));
        }

        [TestMethod]
        public void CyclicPath() {
            var node1 = new Node<string>("a");
            var node2 = new Node<string>("b");
            var node3 = new Node<string>("c");
            node1.Neighbors.Add(node2);
            node2.Neighbors.Add(node3);
            node3.Neighbors.Add(node1);
            Assert.AreEqual(true, DirectedGraph<string>.RouteExistsDFS(node1, node3));
        }
        [TestMethod]
        public void NoPath() {
            var node1 = new Node<string>("a");
            var node2 = new Node<string>("b");
            var node3 = new Node<string>("c");
            node1.Neighbors.Add(node2);
            node2.Neighbors.Add(node3);
            Assert.AreEqual(false, DirectedGraph<string>.RouteExistsDFS(node3, node1));
        }
    }

    class Node<T> where T: IComparable { 
        public List<Node<T>> Neighbors { get; set; }
        public T Value { get; set; }
        public bool Visited { get; set; }
        public Node(T value, List<Node<T>> neighbors) {
            this.Value = value;
            this.Neighbors = neighbors;
            this.Visited = false;
        }
        public Node(T value) : this(value, new List<Node<T>>()) {
        }
    }

    class DirectedGraph<T> where T: IComparable {
        public static bool RouteExistsDFS(Node<T> source, Node<T> destination) {
            var routeExists = false;
            source.Visited = true;
            Console.WriteLine(source.Value);
            if(source.Value.CompareTo(destination.Value) == 0) {
                routeExists = true;
            } else if(source.Neighbors != null) {
                foreach(var neighbor in source.Neighbors) {
                    if(neighbor.Visited == false) {
                        routeExists |= DirectedGraph<T>.RouteExistsDFS(neighbor, destination);
                        if(routeExists) break;
                    }
                }
            }
            return routeExists;
        }
    }
}
