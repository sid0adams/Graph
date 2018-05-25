using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraph
{
    public class Edge<T>
    {
        public Node<T> First { get; internal set; }
        public Node<T> Second { get; internal set; }
        internal Edge<T> Copy { get; set; }
        public bool Linked => Copy != null;
        int value;
        public int Value
        {
            get => value;
            set
            {
                this.value = value;
                if (Linked)
                    Copy.value = value;
            }
        }
        bool was = false;
        public bool Was
        {
            get => was;
            set
            {
                was = value;
                if (Linked)
                    Copy.Was = value;
            }
        }
        public Edge(Node<T> first, Node<T> second, Edge<T> copy = null, int value = 0)
        {
            First = first;
            Second = second;
            Copy = copy;
            Value = value;
        }
    }
}
