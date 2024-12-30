using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;


namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                // ����� Print ������ PrintDocument ������ ��������� �� ������ ������, 
                // ����������� ������� PrintPage � ��������� Graphics, ���������� � ����� PrintPageEventArgs.

                // ��������� ����������� �� �����
                Image im1 = new Bitmap("../../1.jpg");
                Image im2 = new Bitmap("../../2.jpg");
                Graphics gr = e.Graphics;
                gr.DrawImage(im1, new Rectangle(0, 0, 640, 480), new Rectangle(0, 0, 640, 480), GraphicsUnit.Pixel);
                gr.DrawImage(im2, new Rectangle(0, 500, 640, 480), new Rectangle(0, 0, 640, 480), GraphicsUnit.Pixel);
            }
            catch (Exception ex)
            {
            }
       }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // ������� �������� � ����������� � ���� ���������� �������
                PrintDocument doc = new PrintDocument(); // ����� ������� ������

                // ������� PrintPage ����������, ����� ���������� ������� �� ������ ������� ��������.
                doc.PrintPage += this.Doc_PrintPage;

                // PrintDialog �������� ����������� ���������� ���� ������ Microsoft Windows, 
                //����������� ������������ �������� ������� � ��� ��������
                // PrintDialog printDialog1 = new PrintDialog();

                // �������� ��� ������ �������� ��� ���������������� ���������.
                printDialog1.Document = doc;
                DialogResult result = printDialog1.ShowDialog();

                // ���� ������� ������ OK, �� �������� ��������
                if (result == DialogResult.OK)
                {
                    doc.Print(); // ��������� ������� ������ ���������.
                    // Print ������ ��������� �� ������ ������, ����������� ������� PrintPage � ��������� Graphics, ���������� � ����� PrintPageEventArgs.
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // ������� �������� � ����������� � ���� ���������� �������
                PrintDocument doc = new PrintDocument(); // ����� ������� ������

                // ������� PrintPage ����������, ����� ���������� ������� �� ������ ������� ��������.
                doc.PrintPage += this.Doc_PrintPage;

                // PrintPreviewDialog ������������ ����������� ���������� ���� ���������������� ���������
                PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                printPreviewDialog1.Document = doc; // �������� ��� ������ �������� ��� ���������������� ���������.
                printPreviewDialog1.Show();
            }
            catch (Exception ex)
            {
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                // ��������� ����������� �� �����
                Image im1 = new Bitmap("../../1.jpg");
                Image im2 = new Bitmap("../../2.jpg");
                Graphics gr = e.Graphics;
                gr.DrawImage(im1, new Rectangle(0, 0, 640, 480), new Rectangle(0, 0, 640, 480), GraphicsUnit.Pixel);
                gr.DrawImage(im2, new Rectangle(0, 500, 640, 480), new Rectangle(0, 0, 640, 480), GraphicsUnit.Pixel);
            }
            catch (Exception ex)
            {
            }
        }
    }
}