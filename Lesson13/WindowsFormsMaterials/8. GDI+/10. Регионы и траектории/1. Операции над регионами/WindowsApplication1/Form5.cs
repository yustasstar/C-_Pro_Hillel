using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form5 : Form
    {
        
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            /*
            public void Intersect( - остается пересечение регионов.
                           Region region
                        );
            */
            Region rgn = new Region(new Rectangle(0, 0, 100, 100));
            Region rgn2 = new Region(new Rectangle(80, 80, 180, 180));
            rgn2.Intersect(rgn);
            this.Region = rgn2;
            this.BackColor = Color.Red;
        }
    }
}