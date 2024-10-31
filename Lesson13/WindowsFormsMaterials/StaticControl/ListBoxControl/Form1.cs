using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListBoxControl
{
    public partial class Form1 : Form
    {            
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                listBox2.Items.Add(rnd.Next(100));
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            object obj = listBox1.SelectedItem;
            if (obj != null)
                this.Text = obj.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index != -1)
            {
                listBox1.Items.RemoveAt(index);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                listBox2.Items.Add(rnd.Next(100));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Text = listBox2.SelectedIndices.Count.ToString();
            for (int i = listBox2.SelectedIndices.Count - 1; i >= 0; i--)
            {
                listBox2.Items.RemoveAt(listBox2.SelectedIndices[0]);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }
    }
}
