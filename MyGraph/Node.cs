using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraph
{
    public class Node<T>
    {
        public Graph<T> Head { get; }
        internal List<Edge<T>> edges;
        internal int LastCount;
        public int GetEdgesCount => edges.Count;
        public Edge<T> GetEdge(int index) => edges[index];
        public Edge<T> GetEdge(Node<T> node)
        {
            for (int i = 0; i < edges.Count; i++)
                if (edges[i].Second == node)
                    return edges[i];
            return null;
        }
        public bool EdgesContainsTo(Node<T> node)
        {
            for (int i = 0; i < edges.Count; i++)
                if (edges[i].Second == node)
                    return true;
            return false;
        }
        public T Value { get; set; }
        public bool Was { get; set; }
        public void AddDualLinkedEdgeTo(Node<T> node, int value = 0)
        {
            if (Head != node.Head || this == node)
                throw new ArgumentException();
            Edge<T> first = new Edge<T>(this, node, null, value);
            edges.Add(first);
            Edge<T> second = new Edge<T>(node, this, first, value);
            node.edges.Add(second);
            first.Copy = second;
        }
        internal Node(Graph<T> head, T value)
        {
            Head = head;
            Value = value;
            edges = new List<Edge<T>>();
        }
        public bool RemoveEdge(Edge<T> edge)
        {
            if (edges.Contains(edge))
            {
                edge.Second.edges.Remove(edge.Copy);
                edges.Remove(edge);
                return true;
            }
            return false;
        }
        public bool RemoveEdgeTo(Node<T> node)
        {
            for (int i = 0; i < edges.Count; i++)
                if (edges[i].Second == node)
                    return RemoveEdge(edges[i]);
            return false;
        }
        internal void RemoveAllEdges()
        {
            for (int i = 0; i < Head.Nodes.Count; i++)
                Head.Nodes[i].RemoveEdgeTo(this);
            edges.Clear();
        }


        internal int Dist = -1;
        internal Node<T> Last = null;
    }
}
