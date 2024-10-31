using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Controls
{
    public partial class Form1 : Form
    {
        Brush brushinside;
        Pen pen;
        string[] ListData;
        Color[] ListColor;
        Font newfont;

        public Form1()
        {
            InitializeComponent();
      
            pen = new Pen(Color.Blue, 10);
            brushinside = new SolidBrush(Color.Red);
            comboBox1.SelectedIndex = 0;
            newfont = new Font("Comic Sans MS", 14);
            ListData = new string[4] { "Зима", "Весна", "Лето", "Осень" };
            ListColor = new Color[4] { Color.Blue, Color.Green, Color.Red, Color.Yellow };
            listBox1.DataSource = ListData;
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            Graphics gr = e.Graphics;
            gr.FillEllipse(brushinside, 0, 0, button.ClientSize.Width, button.ClientSize.Height);
            gr.DrawEllipse(pen, 0, 0, button.ClientSize.Width, button.ClientSize.Height);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, button.ClientSize.Width, button.ClientSize.Height);
            button.Region = new Region(path);
            String text = "Round";
            Font font = new Font("Arial", 14);
            SolidBrush exbrush = new SolidBrush(Color.Black);
            RectangleF rect = new RectangleF(button.ClientSize.Width / 2 - 30, 
                button.ClientSize.Height / 2 - 15, button.ClientSize.Width, button.ClientSize.Height);
            gr.DrawString(text, font, exbrush, rect);
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground(); 
            using (Pen p = new Pen(e.ForeColor, 2))
            {
                p.DashStyle = (DashStyle)e.Index;
                int y = (e.Bounds.Top + e.Bounds.Bottom) / 2;
                e.Graphics.DrawLine(p, e.Bounds.Left, y, e.Bounds.Right, y);
            }
            e.DrawFocusRectangle(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Round Button Clicked", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            pen = new Pen(Color.Red, 10);
            brushinside = new SolidBrush(Color.Yellow);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            pen = new Pen(Color.Blue, 10);
            brushinside = new SolidBrush(Color.Red);
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            using (SolidBrush solidbrush = new SolidBrush(ListColor[e.Index]))
            {
                e.Graphics.DrawString(ListData[e.Index], newfont, solidbrush, e.Bounds);
            }
            e.DrawFocusRectangle();	
        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 25;		
        }
    }
}
