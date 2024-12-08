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
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // ������� ������� �����, ��������������� �������� ������
            Bitmap screenPicture = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                 Screen.PrimaryScreen.Bounds.Height);
            using (Graphics g = Graphics.FromImage(screenPicture))
            {
                /*
                 // ������� �������� ������
                 public void CopyFromScreen(
	                int sourceX, // ���������� X ����� � ������� ����� ���� ��������� ��������������.
	                int sourceY, // ���������� Y ����� � ������� ����� ���� ��������� ��������������.
	                int destinationX, // ���������� X ����� � ������� ����� ���� ��������� ��������������.
	                int destinationY, // ���������� Y ����� � ������� ����� ���� ��������� ��������������.
	                Size blockRegionSize // ������ ������������ �������.
                )
                 */
                // �������� ����������� ����� ������
                g.CopyFromScreen(0, 0, 0, 0, screenPicture.Size);
            }
            /*
             public Color GetPixel( //�������� ���� ��������� ����� � ������ ����������� Bitmap.
	            int x, // ���������� ����� �� ��� X. 
	            int y // ���������� ����� �� ��� Y. 
            )
            */
            // ������� ���� ����� ��� �������� ����.
            Color myColor = screenPicture.GetPixel(MousePosition.X, MousePosition.Y);
            label1.BackColor = myColor; // �������� ������ � ���������� ����.
            // ����������� ��������� Color � ������.
            label2.Text = ColorTranslator.ToHtml(myColor);
            screenPicture.Dispose();
        }

    }
}