using System;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingOnPictureBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Red, 5.0f);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.DrawRectangle(pen, 10, 10, 90, 90);
            pen.Dispose();
            g.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Red, 5.0f);
            Graphics g = Graphics.FromImage(pictureBox2.Image);
            g.DrawRectangle(pen, 10, 10, 90, 90);
            pictureBox2.Invalidate();
            pen.Dispose();
            g.Dispose();
        }
    }
}