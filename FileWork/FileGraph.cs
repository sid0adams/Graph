using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGraphDraw;
using System.IO;
using MyGraph;

namespace FileWork
{
    public static class FileGraph
    {
        public static void SaveGraph(DrawGraph<int> graphD, string path)
        {
            Graph<NP<int>> graph = graphD.graph;
            FileStream file = new FileStream(path, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(file);
            writer.Write(graph.Count);
            writer.Write(graphD.Width);
            writer.Write(graphD.Height);
            for (int i = 0; i < graph.Count; i++)
            {
                writer.Write(graph[i].Value.V);
                writer.Write(graph[i].Value.X);
                writer.Write(graph[i].Value.Y);
            }
            for (int i = 0; i < graph.Count; i++)
                for (int j = i+1; j < graph.Count; j++)
                {
                    Edge<NP<int>> edge = graph[i].GetEdge(graph[j]);
                    if (edge == null)
                        writer.Write(-1);
                    else
                        writer.Write(edge.Value);
                }
            writer.Close();
            file.Close();
        }
        public static DrawGraph<int> OpenGraph(string path)
        {
            Graph<NP<int>> graph = new Graph<NP<int>>();
            FileStream file = new FileStream(path, FileMode.Open);
            BinaryReader reader = new BinaryReader(file);
            int Count = reader.ReadInt32();
            int Width = reader.ReadInt32();
            int Height = reader.ReadInt32();
            DrawGraph<int> graphD = new DrawGraph<int>(Width,Height);
            graphD.graph = graph;
            for (int i = 0; i < Count; i++)
            {
                int value = reader.ReadInt32();
                int X = reader.ReadInt32();
                int Y = reader.ReadInt32();
                graph.AddNode(new NP<int>(value, X, Y));
            }
            for (int i = 0; i < Count; i++)
                for (int j = i+1; j < Count; j++)
                {
                    int value = reader.ReadInt32();
                    if (value != -1)
                        graph[i].AddDualLinkedEdgeTo(graph[j],value);
                }
            reader.Close();
            file.Close();
            return graphD;
        }

    }
}
