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
            for (int i = 0; i < graph.Count; i++)
            {
                writer.Write(graph[i].Value.V);
                writer.Write(graph[i].Value.X);
                writer.Write(graph[i].Value.Y);
            }
            graph.ClearEdges();
            int[,] matr = new int[graph.Count, graph.Count];
            for (int i = 0; i < graph.Count; i++)
                for (int j = 0; j < graph.Count; j++)
                    matr[i, j] = -1;
            for (int i = 0; i < graph.Count; i++)
                for (int j = 0; j < graph[i].GetEdgesCount; j++)
                {
                    matr[i, graph.GetIndex(graph[i].GetEdge(j).Second)] = graph[i].GetEdge(j).Value;
                }

            for (int i = 0; i < graph.Count; i++)
                for (int j = 0; j < graph.Count; j++)
                    writer.Write(matr[i, j]);
            writer.Close();
            graph
        }

    }
}
