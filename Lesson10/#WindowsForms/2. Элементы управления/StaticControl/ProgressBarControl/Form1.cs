using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBarControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            timer1.Start();
            button1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 10;
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                button1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar2.Minimum = 0;
            progressBar2.Maximum = 50;
            progressBar2.Value = 0;
            progressBar2.Step = 1;
            button2.Enabled = false;
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            progressBar2.PerformStep();
            if (progressBar2.Value == progressBar2.Maximum)
            {
                timer2.Stop();
                button2.Enabled = true;
            }
        }
    }
}
