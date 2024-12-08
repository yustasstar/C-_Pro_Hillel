using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(20, 40, 200, 200);
            Region rgn1 = new Region(path); 
            GraphicsPath path2 = new GraphicsPath();
            path2.AddEllipse(40, 60, 160, 160);
            Region rgn2 = new Region(path2);
            rgn1.Exclude(rgn2);
            Region rgn3 = new Region(new Rectangle(110, 120, 20, 40));
            Region rgn4 = new Region(new Rectangle(100, 130, 40, 20));
            rgn3.Xor(rgn4);
            rgn1.Union(rgn3);
            this.Region = rgn1;
            this.BackColor = Color.Red;
        }

    }
}