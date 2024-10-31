using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;


namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        private Font printFont;
        private StreamReader streamToPrint;

        public Form1()
        {
            InitializeComponent();
            try
            {
                streamToPrint = new StreamReader("../../1.txt", Encoding.Default);
                string str = streamToPrint.ReadToEnd();// ���������� ���� ���� � �������� � ������������� ��������� ����
                streamToPrint.Close();
                textBox1.Text = str;
                textBox1.SelectionStart = 0;
                textBox1.SelectionLength = 0; // ������� ���������
                printFont = new Font("Arial", 10);
            }
            catch (Exception ex)
            {
            }
        }

        // ����� ���������� ��� ������ ������� ��������
        private void Doc_PrintPage(object sender, PrintPageEventArgs ev)
        {
            try
            {
                float linesPerPage = 0;
                float yPos = 0; // ���������� Y ����� ������ ������ ��������� ������
                int count = 0; // ������� ���������� ���������� �����
                float leftMargin = ev.MarginBounds.Left; // ������ �����
                float topMargin = ev.MarginBounds.Top; // ������ ������
                string line = null;

                // ���������, ������� ����� ���������� �� ��������
                // ev.MarginBounds.Height - ������ ��������
                // ����� GetHeight ���������� �������� �������������� ��������� ������� ������ � ������� �������� ��������� ���������� ��������� Graphics. 
                linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

                // �������� �������� ���������� ����� �����
                while (count < linesPerPage && ((line = streamToPrint.ReadLine()) != null))
                {
                    yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));//������� ���� ���������� Y
                    ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());// ������� ��������� ������
                    count++;// ����������� ������� ���������� �����
                }
                // ���� ���� ��� ������ � �����, �� �������� ��������� ��������,
                // ����� ��������� �����
                // ev.HasMorePages ����������, ����� �� �������� �� ������ ��������� ��������
                if (line != null)
                    ev.HasMorePages = true;
                else
                {
                    ev.HasMorePages = false;
                    streamToPrint.Close();
                }
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

                //  ������� PrintPage ����������, ����� ���������� ������� �� ������ ������� ��������
                doc.PrintPage += this.Doc_PrintPage;

                // ������������ ����� �������� ������� � ��� �������� ����� ����������� ���������� ����
                // PrintDialog printDialog1 = new PrintDialog();

                printDialog1.Document = doc;
                DialogResult result = printDialog1.ShowDialog();
                // ���� ������� ������ OK, �� �������� ��������
                if (result == DialogResult.OK)// ��������� ������
                {
                    streamToPrint = new StreamReader("../../1.txt", Encoding.Default);
                    doc.Print();
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

                //  ������� PrintPage ����������, ����� ���������� ������� �� ������ ������� ��������.
                doc.PrintPage += this.Doc_PrintPage;

                // PrintPreviewDialog ������������ ����������� ���������� ���� ���������������� ���������
                PrintPreviewDialog dlgPreview = new PrintPreviewDialog();
                dlgPreview.Document = doc;
                streamToPrint = new StreamReader("../../1.txt", Encoding.Default);
                dlgPreview.Show(); // ����������� ������
            }
            catch (Exception ex)
            {

            }
        }
    }
}