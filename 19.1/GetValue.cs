using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19._1
{
    public partial class GetValue : Form
    {
        public GetValue()
        {
            InitializeComponent();
        }
        public int Value { get; set; } = 1;

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) => Value = (int)numericUpDown1.Value;

        private void GetValue_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = Value;
        }
    }
}
