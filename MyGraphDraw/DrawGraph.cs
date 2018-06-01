using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGraph;
using System.Drawing;

namespace MyGraphDraw
{
    public class NP<T>
    {
        public T V { get; set; }
        public Point P { get; set; }
        public int X => P.X;
        public int Y => P.Y;
        public NP(T v, Point p)
        {
            V = v;
            P = p;
        }
        public NP(T v, int X, int Y)
        {
            V = v;
            P = new Point(X, Y);
        }
    }
    public class DrawGraph<T>
    {
        Bitmap Image;
        Graphics G;
        public Size size { get;private set; }
        public int Height => size.Height;
        public int Width => size.Width;
        public Graph<NP<T>> graph { get; set; }
        public bool DrawEdgeValue { get; set; } = true;
        int R = 30;
        public Bitmap Draw( Node<NP<T>> selected = null, Point point = default(Point))
        {
            Image = new Bitmap(size.Width, size.Height);
            G = Graphics.FromImage(Image);
            for (int i = 0; i < graph.Count; i++)
            {
                for (int j = 0; j < graph[i].GetEdgesCount; j++)
                {
                    Edge<NP<T>> edge = graph[i].GetEdge(j);
                    G.DrawLine(Pens.Black, graph[i].Value.P, edge.Second.Value.P);
                    edge.Was = true;
                    if (DrawEdgeValue)
                        G.DrawString(edge.Value.ToString(), new Font("Microsoft Sans Serif", 19), Brushes.Black,
                            (edge.First.Value.P.X + edge.Second.Value.P.X) / 2 + 10,
                            (edge.First.Value.P.Y + edge.Second.Value.P.Y) / 2 + 10);
                }
                if(graph[i] == selected)
                {
                    G.DrawLine(Pens.Black, graph[i].Value.P, point);
                }
            }
            for (int i = 0; i < graph.Count; i++)
            {
                G.FillEllipse(Brushes.Red, graph[i].Value.P.X - R, graph[i].Value.P.Y - R, 2 * R, 2 * R);
                float size = 0;
                string print = graph[i].Value.V.ToString();
                do
                {
                    size += (float)0.2;
                }
                while (G.MeasureString(print, new Font("Microsoft Sans Serif", size)).Width < R);
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                G.DrawString(print, new Font("Microsoft Sans Serif", size), Brushes.Black, new Rectangle(graph[i].Value.P.X - R, graph[i].Value.P.Y - R, 2 * R, 2 * R), sf);
            }
            return Image;
        }
        public Node<NP<T>> GetNode(Point p)
        {
            for (int i = 0; i < graph.Count; i++)
            {
                if (Dist(graph[i].Value.P, p, R))
                    return graph[i];
            }
            return null;
        }
        public Edge<NP<T>> GetEdge(Point p)
        {
            for (int i = 0; i < graph.Count; i++)
                for (int j = 0; j < graph[i].GetEdgesCount; j++)
                {
                    Edge<NP<T>> edge = graph[i].GetEdge(j);
                    double AB = Math.Sqrt(Math.Pow(edge.First.Value.P.X - edge.Second.Value.P.X, 2) + Math.Pow(edge.First.Value.P.Y - edge.Second.Value.P.Y, 2));
                    double AC = Math.Sqrt(Math.Pow(edge.First.Value.P.X - p.X, 2) + Math.Pow(edge.First.Value.P.Y - p.Y, 2));
                    double CB = Math.Sqrt(Math.Pow(p.X - edge.Second.Value.P.X, 2) + Math.Pow(p.Y - edge.Second.Value.P.Y, 2));
                    double Gr = AC + CB - AB;
                    if (Gr < 1)
                    {
                        return edge;
                    }
                }
            return null;
        }
        public bool PlaceFree(Point p)
        {
            if (p.X < R || p.Y < R || p.X > Width - R || p.Y > Height - R)
                return false;
            for (int i = 0; i < graph.Count; i++)
            {
                if (Dist(graph[i].Value.P, p, 4*R))
                    return false;
            }
            return true;
        }

        public bool PlaceChangeFree(Point p, Node<NP<T>> node)
        {
            if (p.X < R || p.Y < R || p.X > Width - R || p.Y > Height - R)
                return false;
            for (int i = 0; i < graph.Count; i++)
            {
                if (Dist(graph[i].Value.P, p, 4 * R) && graph[i]!= node)
                    return false;
            }
            return true;
        }
        bool Dist(Point a, Point b, int D) => Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2) <= D * D;
        public DrawGraph(Size size)
        {
            this.size = size;
            graph = new Graph<NP<T>>();
        }
        public DrawGraph(int width,int height)
        {
            size = new Size(width, height);
            graph = new Graph<NP<T>>();
        }
        public void Add(T value,Point p)
        {
            graph.AddNode(new NP<T>(value, p));
        }
        public void Add(T value, int x, int y) => Add(value, new Point(x, y));
    }
}
