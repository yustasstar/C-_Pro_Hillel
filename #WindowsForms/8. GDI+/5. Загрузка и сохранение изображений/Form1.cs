using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace PNGEDIT1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            // ��� �������� �������� � ���������� ��������� ���������� - ��� �������
            openFileDialog1.InitialDirectory = saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
      }

         private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string s = openFileDialog1.FileName;
                try
                {
                    // ����� Bitmap �������� ����������� �� Image
                    Image im = new Bitmap(s); // ����������� ����������� �� ���������� ����� � ������� Bitmap
                    if (pictureBox1.Image != null)
                        pictureBox1.Image.Dispose(); // ��������� ���������� ������ Image
                    pictureBox1.Image = im; // �������� �� PictureBox ��������� �����������
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                Text = "Image Viewer - " + s;
                saveFileDialog1.FileName = s;
                openFileDialog1.FileName = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s0 = saveFileDialog1.FileName; 
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string s = saveFileDialog1.FileName;
                // .NET �� ���� ��������� ����������� � ��� �� ����, �� �������� ���������
                if (s.ToUpper() == s0.ToUpper())// ���� �������� ��������� ����������� � ��� �� ����, �� �������� ���������
                {
                    // �������� ����������� �� ��������� ����
                    s0 = Path.GetDirectoryName(s0) + "\\($$##$$)";
                    pictureBox1.Image.Save(s0);
                    // �������� ������ Bitmap, ��������� � ������ ������������ 
                    pictureBox1.Image.Dispose();
                    // ������ �������� ����
                    File.Delete(s);
                    // ��� ���������� ����� ������� �� ��� ��������� �����
                    File.Move(s0, s);
                    // �������� �� PictureBox ����� ������� �����
                    pictureBox1.Image = new Bitmap(s);
                }
                else
                    // �������� ����������� � ����
                    if (pictureBox1.Image != null)
                        pictureBox1.Image.Save(s);
                Text = "Image Editor - " + s;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image im = new Bitmap(500, 300);
            Graphics g = Graphics.FromImage(im);
            g.Clear(Color.White);
            g.Dispose();
            if (pictureBox1.Image != null)
                pictureBox1.Image.Dispose(); // ��������� ���������� ������ Image
            pictureBox1.Image = im; // �������� �� PictureBox ��������� �����������
        }
    }
}
