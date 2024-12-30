using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void butStringToColor_Click(object sender, EventArgs e)
        {
            string htmlColor = "Red";
            // ����������� ������ htmlColor � ��������� GDI+ Color
            Color myColor = ColorTranslator.FromHtml(htmlColor);
            // ��������� �� ������ ������� ���� ����
            butStringToColor.BackColor = myColor;

            // ������ ������
            // ����������� ������ htmlColor � ��������� GDI+ Color
            Color myColor2 = ColorTranslator.FromHtml("#FF0000");
            // ��������� �� ������ ������� ���� ����
            butStringToColor.BackColor = myColor2;
        }

        private void butColorToString_Click(object sender, EventArgs e)
        {
            // ����������� ��������� Color � ������
            Color myColor = Color.BlueViolet;
            string htmlColor = ColorTranslator.ToHtml(myColor);
            // ������� ���� ��������� � ���������� ���������
            MessageBox.Show(htmlColor);
            pictureBox1.Image = Properties.Resources.cat;
        }

        private void butColorToInt_Click(object sender, EventArgs e)
        {
            // ����������� ����� ����� � ���� (� ��������� Color) 
            Color myColor = Color.FromArgb(0x7900FF00);
            // ��������� �� ������ ���������� ���� ����
            butColorToInt.BackColor = myColor;
        }

        private void butSetPixel_Click(object sender, EventArgs e)
        {
           // �������������� ����� ��������� ������ Bitmap ��������� ������������ ������������.
            Bitmap bm = new Bitmap(Properties.Resources.cat01);
            // �������� ������� ����� �� PictureBox
            pictureBox1.Image = bm;
            for (int i = 0; i < 400; i++)
            {
                // ������ �� ����������� ����� �� 400 �������� �������� �����
                bm.SetPixel(i, i, Color.Red);
            }
            // ������� ����������� PictureBox
            //pictureBox1.Update();
        }

        /*
         SolidBrush ���������� ����� ������ �����. ����� ������������ ��� ������� ����������� �����, 
          ����� ��� ��������������, �������, �����, �������������� � �������.
         
           FillRectangle ��������� ���������� ����� ��������������, ������� ��������� ����� ���������, ������� � �������.
           public void FillRectangle(
               Brush brush, // ������ Brush, ������������ ��������� �������.  
               int x, // ���������� X �������� ������ ���� �������������� ��� �������. 
               int y, // ���������� Y �������� ������ ���� �������������� ��� �������. 
               int width, // ������ �������������� ��� �������. 
               int height // ������ �������������� ��� �������. 
           )
        */
        private void butDrawPoint_Click(object sender, EventArgs e)
        {
            /* ����� Graphics ������������� ����������� ��������� GDI+. 
            ����� Graphics ������������� ������ ��� ������ �������� � ���������� �����������. 
            ������ Graphics ������ � ���������� ���������� ����������.
            */
            Graphics g = CreateGraphics();
            // ������ ��� ������ �����
            for (int i = 0; i < 500; i += 5)
                g.FillRectangle(new SolidBrush(Color.Black), i, 10, 1, 1);
            g.Dispose();
        }
    }
}