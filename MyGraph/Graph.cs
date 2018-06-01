using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraph
{
    public class Graph<T>
    {
        #region base
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
        #endregion

        #region CPP
        //список нечётных ноды
        private List<Node<T>> GetOddNodes()
        {
            List<Node<T>> nodes = new List<Node<T>>();
            foreach (Node<T> item in Nodes)
            {
                if (item.edges.Count % 2 == 1)
                    nodes.Add(item);
            }
            return nodes;
        } 
        //выставляет кратчайшее расстояние каждой ноды от переданной, и ссылку на предыдущую ноду в пути 
        private void SetDist(Node<T> node)
        {
            foreach (Node<T> item in Nodes)
            {
                item.Dist = -1;
                item.Last = null;
                item.Was = false;
            }
            node.Dist = 0;
            for (int i = 0; i < Nodes.Count; i++)
            {
                Node<T> Min = null;
                foreach (Node<T> item in Nodes)
                {
                    if (!item.Was && item.Dist >= 0 && (Min == null || item.Dist < Min.Dist))
                        Min = item;
                }
                Min.Was = true;
                foreach (Edge<T> item in Min.edges)
                {
                    if(item.Second.Dist<0|| item.Second.Dist>Min.Dist+item.Value)
                    {
                        item.Second.Dist = Min.Dist + item.Value;
                        item.Second.Last = Min; 
                    }
                }
            }
        } 


        //состовляет матрицу расстояний
        private List<Node<T>> GetPairs(List<Node<T>> odd)
        {
            int[,] DistMatr = new int[odd.Count, odd.Count];
            for (int i = 0; i < odd.Count; i++)
            {
                SetDist(odd[i]);
                for (int j = 0; j < odd.Count; j++)
                {
                    DistMatr[i, j] = odd[j].Dist;
                }
            }
            SetOptimal(odd.Count, DistMatr);
            List<Node<T>> Pairs = new List<Node<T>>();
            foreach (int item in optimal)
            {
                Pairs.Add(odd[item]);
            }
            return Pairs;
        }
        
        //перебор всех возможных пар
        List<int> optimal;
        int min = 0;
        private void SetOptimal(int N, int[,] matr, List<int> selected = null)
        {
            if(selected == null)
            {
                optimal = null;
                selected = new List<int>();
            }
            if(selected.Count == N)
            {
                int Sum = 0;
                for (int i = 0; i < N/2; i++)
                {
                    Sum += matr[selected[2 * i],selected[ 2 * i + 1]];
                }
                if(optimal == null || min >Sum)
                {
                    min = Sum;
                    optimal = new List<int>(selected);
                }
                return;
            }
            int t = 0;
            while (selected.Contains(t))
            {
                t++;
            }
            selected.Add(t);
            for (int i = t+1; i < N; i++)
            {
                if(!selected.Contains(i))
                {
                    selected.Add(i);
                    SetOptimal(N, matr, selected);
                    selected.Remove(i);
                }
            }
            selected.Remove(t);
        }
        
        //добавление дублирующих нод
        private void AddEdges(List<Node<T>> Pairs)
        {
            foreach (Node<T> item in Nodes)
            {
                item.LastCount = item.edges.Count;
            }
            for (int i = 0; i < Pairs.Count/2; i++)
            {
                SetDist(Pairs[2 * i]);
                Node<T> Go = Pairs[2 * i + 1];
                while (Go!= Pairs[2*i])
                {
                    Go.AddDualLinkedEdgeTo(Go.Last);
                    Go = Go.Last;
                }
            }
        }
        //удаление дублирующих нод
        private void RemoveEdges()
        {
            foreach (Node<T> item in Nodes)
            {
                item.edges.RemoveRange(item.LastCount, item.edges.Count - item.LastCount);
            }
        }

        //поиск эйлерового цикла
        List<Node<T>> GetEilerCycle()
        {
            ClearEdges();
            List<Node<T>> Cycle = new List<Node<T>>();
            Stack<Node<T>> stack = new Stack<Node<T>>();
            stack.Push(Nodes[0]);
            while (stack.Count != 0)
            {
                Node<T> node = stack.Peek();
                bool t = true;
                for (int i = 0; i < node.edges.Count; i++)
                    if (!node.edges[i].Was)
                    {
                        t = false;
                        stack.Push(node.edges[i].Second);
                        node.edges[i].Was = true;
                        break;
                    }
                if (t)
                    Cycle.Add(stack.Pop());
            }
            return Cycle;
        }
        
        //основной метод
        public List<Node<T>> ChinePostmanProblem()
        {
            if (Nodes.Count == 0)
                return null;
            List<Node<T>> list = GetUnAvailable(Nodes[0]);
            if (list.Count != 0)
                return null;
            list = GetOddNodes();
            if (list.Count != 0)
                AddEdges(GetPairs(list));
            List<Node<T>> Answer = GetEilerCycle();
            if (list.Count != 0)
                RemoveEdges();
            return Answer;
        }
        #endregion
    }
}
