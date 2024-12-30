using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            /*
             public void Exclude( - вычитает из одного региона другой.
                  Region region
                );
             */
            Region rgn = new Region(new Rectangle(30, 30, 100, 100));
            Region rgn2 = new Region(new Rectangle(0, 0, 180, 180));
            rgn2.Exclude(rgn);
            this.Region = rgn2;
            this.BackColor = Color.Red;
        }
    }
}