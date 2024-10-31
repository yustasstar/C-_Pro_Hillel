using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            Point[] pts = new Point[4] { new Point(0, this.Height / 2), new Point(this.Width / 2, 0), new Point(this.Width, this.Height/2), new Point(this.Width / 2, this.Height) };
            path.AddPolygon(pts);
            Region rgn1 = new Region(path);
            this.Region = rgn1;
            this.BackColor = Color.Coral;
        }
    }
}
