using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraph
{
    public class Graph<T>
    {
        internal List<Node<T>> Nodes { get; set; } = new List<Node<T>>();
        public int Count => Nodes.Count;
        public Node<T> this[int index]=>Nodes[index];
        public Node<T> AddNode(T value)
        {
            Node<T> added = new Node<T>(this, value);
            Nodes.Add(added);
            return added;
        }
        public bool RemoveNode(Node<T> node)
        {
            if(Nodes.Contains(node))
            {
                node.RemoveAllEdges();
                Nodes.Remove(node);
                return true;
            }
            return false;
        }
        public void ClearNodes()
        {
            for (int i = 0; i < Nodes.Count; i++)
                Nodes[i].Was = false;
        }
        public void ClearEdges()
        {
            for (int i = 0; i < Nodes.Count; i++)
                for (int j = 0; j < Nodes[i].edges.Count; j++)
                    Nodes[i].edges[j].Was = false;
        }
        public List<Node<T>> GetUnAvailable(Node<T> node)
        {
            if (!Nodes.Contains(node))
                throw new ArgumentException();
            ClearNodes();
            node.Was = true;
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(node);
            while (queue.Count != 0)
            {
                Node<T> T = queue.Dequeue();
                for (int i = 0; i < T.edges.Count; i++)
                    if(!T.edges[i].Second.Was)
                    {
                        T.edges[i].Second.Was = true;
                        queue.Enqueue(T.edges[i].Second);
                    }
            }
            List<Node<T>> UnAvailable = new List<Node<T>>();
            for (int i = 0; i < Nodes.Count; i++)
                if (!Nodes[i].Was)
                    UnAvailable.Add(Nodes[i]);
            return UnAvailable;
        }
        public int GetIndex(Node<T> node) => Nodes.IndexOf(node);
    }
}
