using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContextMenu
{
    public partial class Form1 : Form
    {
        ContextMenuStrip m;
        public Form1()
        {
            InitializeComponent();
            m = new ContextMenuStrip();
            m.Items.Add("Menu Item 1");
            m.Items.Add("Menu Item 2");
            m.Items.Add("Menu Item 3");
            ContextMenuStrip = m;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void pastleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }
    }
}
