using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyGraph;
using MyGraphDraw;
using FileWork;

namespace _19._1
{
    public partial class GraphForm : Form
    {
        public GraphForm()
        {
            InitializeComponent();
        }
        DrawGraph<int> DrawA, DrawB;

        Node<NP<int>> SelectedNode = null;
        Edge<NP<int>> SelectedEdge = null;
        bool menuwork = false;

        private void UpdatePicter(Object sender)
        {
            ((PictureBox)sender).Image = sender == OutputA ? DrawA.Draw() : DrawB.Draw();
        }
        private void Output_MouseDown(object sender, MouseEventArgs e)
        {
            menuwork = false;
            DrawGraph<int> draw = sender == OutputA ? DrawA : DrawB;
            if (e.Button == MouseButtons.Right)
            {
                SelectedNode = draw.GetNode(e.Location);
                SelectedEdge = draw.GetEdge(e.Location);
                if (SelectedNode != null || SelectedEdge != null)
                    contextMenuStrip.Show((Control)sender, e.Location);
                menuwork = true;
                return;
            }
            if (AddBtn.Checked)
            {
                if (draw.PlaceFree(e.Location))
                {
                    GetValue get = new GetValue();
                    if (get.ShowDialog() == DialogResult.OK)
                    {
                        draw.Add(get.Value, e.Location);
                        UpdatePicter(sender);
                    }
                }
            }
            if (AddEdge.Checked)
            {
                if (SelectedNode == null)
                SelectedNode = draw.GetNode(e.Location);
                else
                {
                    if(SelectedNode.Head == draw.graph)
                    {
                        Node<NP<int>> T = draw.GetNode(e.Location);
                        if (T != SelectedNode&& T!= null && T.GetEdge(SelectedNode)== null)
                        {
                            GetValue get = new GetValue();
                            if (get.ShowDialog() == DialogResult.OK)
                            {
                                SelectedNode.AddDualLinkedEdgeTo(T,get.Value);
                            }
                            UpdatePicter(sender);
                        }
                        SelectedNode = null;
                    }
                    else
                        SelectedNode = draw.GetNode(e.Location);
                }
            }
            if(ChangeBtn.Checked)
            {
                SelectedNode = draw.GetNode(e.Location);
            }
        }
        private void ChangeEnd(object sender)
        {
            if(ChangeBtn.Checked&&!menuwork)
            {
                SelectedEdge = null;
                SelectedNode = null;
            }
            UpdatePicter(sender);
        }

        private void Btn_CheckedChanged(object sender, EventArgs e)
        {
            SelectedEdge = null;
            SelectedNode = null;
        }

        private void Output_MouseUp(object sender, MouseEventArgs e) => ChangeEnd(sender);

        private void Output_MouseLeave(object sender, EventArgs e)
        {
            ChangeEnd(sender);
        }

        private void Output_MouseMove(object sender, MouseEventArgs e)
        {
            if (SelectedNode != null)
            {
                DrawGraph<int> draw = sender == OutputA ? DrawA : DrawB;
                if (ChangeBtn.Checked)
                {
                    if (draw.PlaceChangeFree(e.Location, SelectedNode))
                        SelectedNode.Value.P = e.Location;
                    UpdatePicter(sender);
                }
                if (AddEdge.Checked)
                {
                    ((PictureBox)sender).Image = draw.Draw(SelectedNode, e.Location);
                }
            }
        }

        private void Remove(object sender, EventArgs e)
        {
            if (SelectedNode!= null)
            {
                DrawGraph<int> draw = SelectedNode.Head == DrawA.graph ? DrawA : DrawB;
                draw.graph.RemoveNode(SelectedNode);
                UpdatePicter(draw == DrawA ? OutputA : OutputB);
            }
            else if(SelectedEdge!=null)
            {
                DrawGraph<int> draw = SelectedEdge.First.Head == DrawA.graph ? DrawA : DrawB;
                SelectedEdge.First.RemoveEdge(SelectedEdge);
                UpdatePicter(draw == DrawA ? OutputA : OutputB);
            }
            menuwork = false;
        }

        private void ChangeContextBtn_Click(object sender, EventArgs e)
        {
            if (SelectedNode != null)
            {
                DrawGraph<int> draw = SelectedNode.Head == DrawA.graph ? DrawA : DrawB;
                GetValue get = new GetValue();
                get.Value = SelectedNode.Value.V;
                if (get.ShowDialog() == DialogResult.OK)
                {
                    SelectedNode.Value.V = get.Value;
                }
                UpdatePicter(draw == DrawA?OutputA:OutputB);
            }
            else if (SelectedEdge != null)
            {
                DrawGraph<int> draw = SelectedEdge.First.Head == DrawA.graph ? DrawA : DrawB;
                GetValue get = new GetValue();
                get.Value = SelectedEdge.Value;
                if (get.ShowDialog() == DialogResult.OK)
                {
                    SelectedEdge.Value = get.Value;
                }
                UpdatePicter(draw == DrawA ? OutputA : OutputB);
            }
            menuwork = false;
        }

        private void Open_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if(sender == OpenA)
                    {
                        DrawA = FileGraph.OpenGraph(openFileDialog.FileName);
                        UpdatePicter(OutputA);
                    }
                    else
                    {
                        DrawB = FileGraph.OpenGraph(openFileDialog.FileName);
                        UpdatePicter(OutputB);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("error");
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (sender == SaveA)
                    {
                        FileGraph.SaveGraph(DrawA, saveFileDialog.FileName);
                    }
                    else
                    {
                        FileGraph.SaveGraph(DrawB, saveFileDialog.FileName);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("error");
                }
            }
        }

        private void CPP_Btn_Click(object sender, EventArgs e)
        {
            Graph<NP<int>> graph = sender == CPP_A_Btn ? DrawA.graph : DrawB.graph;
            List<Node<NP<int>>> nodes = graph.ChinePostmanProblem();
            if(nodes== null)
            {
                MessageBox.Show("невозможно");
                return;
            }
            StringBuilder sb = new StringBuilder();
            foreach (Node<NP<int>> item in nodes)
            {
                sb.Append(item.Value.V);
                sb.Append(" ");
            }
            MessageBox.Show(sb.ToString());
        }

        private void GraphForm_Load(object sender, EventArgs e)
        {
            DrawA = new DrawGraph<int>(OutputA.Size);
            DrawB = new DrawGraph<int>(OutputB.Size);
        }
        
    }
}
