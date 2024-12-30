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
            // Получим информацию о свойствах файла.
            FileVersionInfo fileInfo = FileVersionInfo.GetVersionInfo(fileName);
            FileInfo fi = new FileInfo(fileName);

            listBox1.Items.Add("Комментарии: " + fileInfo.Comments);
            listBox1.Items.Add("Производитель: " + fileInfo.CompanyName);
            listBox1.Items.Add("Имя файла: " + fileInfo.FileName);
            listBox1.Items.Add("Размер файла: " + fi.Length.ToString());
            listBox1.Items.Add("Номер сборки файла: " + fileInfo.FileBuildPart);
            listBox1.Items.Add("Описание файла: " + fileInfo.FileDescription);
            listBox1.Items.Add("Номер версии файла: " + fileInfo.FileVersion);
            listBox1.Items.Add("Основная часть номера версии: " + fileInfo.FileMajorPart);
            listBox1.Items.Add("Вспомогательная часть номера версии: " + fileInfo.FileMinorPart);
            listBox1.Items.Add("Номер закрытой части файла: " + fileInfo.FilePrivatePart);
            listBox1.Items.Add("Авторские права: " + fileInfo.LegalCopyright);
            listBox1.Items.Add("Товарные знаки: " + fileInfo.LegalTrademarks);
            listBox1.Items.Add("Название продукта: " + fileInfo.ProductName);
        }

    }
}