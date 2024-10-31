using System;
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

        private void Button1Click(object sender, EventArgs e)
        {
            try
            {
                // �������� PrinterSettings.InstalledPrinters �������� �������� ���� ���������, ������������� �� ����������.
                foreach (string printerName in PrinterSettings.InstalledPrinters)
                {
                    // ������� ��� ��������
                    textBox1.Text += "�������: " + printerName + "\r\n";
                    // ������ ������ PrinterSettings ������������ ����� �������� ��������
                    PrinterSettings printer = new PrinterSettings(); // �������� ��������� �������� �� ���������
                    printer.PrinterName = printerName; // �������� � ������ ��������
                    // ���������, ������������ �� �������
                    if (printer.IsValid)
                    {
                        // ������� ������ �������������� ����������
                        textBox1.Text += "�������������� ����������:" + "\r\n";
                        foreach (PrinterResolution resolution in printer.PrinterResolutions)
                        {
                            textBox1.Text += resolution + "\r\n";
                        }
                        textBox1.Text += "\r\n";
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}