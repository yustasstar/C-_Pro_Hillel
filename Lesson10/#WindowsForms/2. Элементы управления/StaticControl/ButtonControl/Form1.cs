using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButtonControl
{
    public partial class Form1 : Form
    {
        int index = 1;
        public Form1()
        {
            InitializeComponent();
            Height = 220;
            Text = "Слайд-шоу";
            picture.Location = new Point(100, 10);
            //picture.Image = Image.FromFile("1.bmp");
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            start.Location = new Point(30, 120);
            start.Text = "Старт";
            start.Width = 100;
            start.Height = 40;
            stop.Location = new Point(160, 120);
            stop.Text = "Стоп";
            stop.Width = 100;
            stop.Height = 40;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ++index;
            if (index > 5)
                index = 1;
            picture.Image = Image.FromFile(index + ".bmp");
        }

        private void start_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
