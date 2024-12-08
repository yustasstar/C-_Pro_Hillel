using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        /*
         * Регион (Область окна) — это коллекция точек внутри окна, в которой операционной системой разрешается рисование. 
         * Операционная система не отображает части окна, лежащие вне области окна. Координаты области элемента 
         * управления вычисляются относительно левого верхнего угла самого элемента управления, а не его клиентской области. 
         */
        private void Form2_Load(object sender, EventArgs e)
        {
            /*
            public void Xor(- применяет XOR операцию по отношению к региону и прямоугольнику.
                       Rectangle rect
                    );
            */
            Region rgn = new Region(new Rectangle(0, 0, 100, 100));
            Region rgn2 = new Region(new Rectangle(70, 70, 170, 170));
            rgn.Xor(rgn2);
            this.Region = rgn;
            this.BackColor = Color.Red;
        }
    }
}