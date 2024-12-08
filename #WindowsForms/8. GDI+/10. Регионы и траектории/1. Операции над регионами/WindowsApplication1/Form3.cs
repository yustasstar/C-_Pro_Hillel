using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            /*
            public void Union( - объединение регионов
               Region region
            );
            */
            Region rgn = new Region(new Rectangle(0, 0, 100, 100));
            Region rgn2 = new Region(new Rectangle(110, 110, 170, 170));
            rgn2.Union(rgn);
            this.Region = rgn2;
            this.BackColor = Color.Red;
        }
    }
}