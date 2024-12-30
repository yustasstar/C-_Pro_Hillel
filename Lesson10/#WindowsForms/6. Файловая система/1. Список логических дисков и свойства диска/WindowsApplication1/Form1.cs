using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] astrLogicalDrives = System.IO.Directory.GetLogicalDrives(); // System.Environment.GetLogicalDrives();
            listBox1.Items.Clear();
            foreach (string disk in astrLogicalDrives)
                listBox1.Items.Add(disk);
        }

       
        private void butDiskProperty_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index == -1)
                return;
            string disk = listBox1.Items[index].ToString();
            // ������� ���������� � �����
            System.IO.DriveInfo drv = new System.IO.DriveInfo(disk);
            listBox1.Items.Clear();
            listBox1.Items.Add("����: " + drv.Name);

            if (drv.IsReady)
            {
                listBox1.Items.Add("��� �����: " + drv.DriveType.ToString());
                listBox1.Items.Add("�������� �������: " + drv.DriveFormat.ToString());
                listBox1.Items.Add("��������� ����� �� �����: " + drv.AvailableFreeSpace.ToString());
                listBox1.Items.Add("������� �����: " + drv.TotalSize.ToString());
            }

        }
    }
}