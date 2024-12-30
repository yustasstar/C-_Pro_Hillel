using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Clear();
            string fileName = @"c:\windows\regedit.exe";
            // ������� ���������� � ��������� �����.
            FileVersionInfo fileInfo = FileVersionInfo.GetVersionInfo(fileName);
            FileInfo fi = new FileInfo(fileName);

            listBox1.Items.Add("�����������: " + fileInfo.Comments);
            listBox1.Items.Add("�������������: " + fileInfo.CompanyName);
            listBox1.Items.Add("��� �����: " + fileInfo.FileName);
            listBox1.Items.Add("������ �����: " + fi.Length.ToString());
            listBox1.Items.Add("����� ������ �����: " + fileInfo.FileBuildPart);
            listBox1.Items.Add("�������� �����: " + fileInfo.FileDescription);
            listBox1.Items.Add("����� ������ �����: " + fileInfo.FileVersion);
            listBox1.Items.Add("�������� ����� ������ ������: " + fileInfo.FileMajorPart);
            listBox1.Items.Add("��������������� ����� ������ ������: " + fileInfo.FileMinorPart);
            listBox1.Items.Add("����� �������� ����� �����: " + fileInfo.FilePrivatePart);
            listBox1.Items.Add("��������� �����: " + fileInfo.LegalCopyright);
            listBox1.Items.Add("�������� �����: " + fileInfo.LegalTrademarks);
            listBox1.Items.Add("�������� ��������: " + fileInfo.ProductName);
        }

    }
}