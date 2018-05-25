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

namespace _19._1
{
    public partial class GraphForm : Form
    {
        public GraphForm()
        {
            InitializeComponent();
        }
        DrawGraph<int> Draw;
        private void GraphForm_Load(object sender, EventArgs e)
        {
            Draw = new DrawGraph<int>(Output.Size);
        }
    }
}
