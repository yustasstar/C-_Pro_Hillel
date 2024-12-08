using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JPEGVIEW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // AllowMerge - true - ��� ����������� ����������� ����
            // MdiLayout - ��������� ������������ �������� ���� ���������� MDI � ������������ ���� MDI.
            hTile1.Tag = MdiLayout.TileHorizontal; // ��� �������� ���� ���������� MDI ������������� ������ ���� � �������� ���������� ������� ������������ ����� MDI.
            vTile1.Tag = MdiLayout.TileVertical; // ��� �������� ���� ���������� MDI ������������� ����� ������� � �������� ���������� ������� ������������ ����� MDI.
            cascade1.Tag = MdiLayout.Cascade; //��� �������� ���� ���������� MDI ������������� �������� ������ ���������� ������� ������������ ����� MDI.
            arrangeIcons1.Tag = MdiLayout.ArrangeIcons; // ��� �������� ������ ���������� MDI ������������� ������ ���������� ������� ������������ ����� MDI.
        }

        internal void open1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Form2 f = new Form2();
                string n = openFileDialog1.FileName;
                Image i = Image.FromFile(n);
                f.pictureBox1.Image = i;
                f.Text = string.Format("{0} ({1}x{2})", System.IO.Path.GetFileNameWithoutExtension(n), i.Width, i.Height);
                f.MdiParent = this;// ������� ����� (Form1) �������� ������������ ����� ��� �������� ����� Form2
                window1.Visible = true;
                close2.Enabled = stretch2.Enabled = true;
                f.Show();
            }
        }

        private void exit1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void hTile1_Click(object sender, EventArgs e)
        {
            //LayoutMdi - ����������� �������� MDI-����� ������ ������������ MDI-�����.
            LayoutMdi((MdiLayout)(sender as ToolStripMenuItem).Tag);
        }

        private void close2_Click(object sender, EventArgs e)
        {
            // ��������� �������� �������� �����
            this.ActiveMdiChild.Close();
        }

        private void stretch2_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ActiveMdiChild as Form2).stretch1;
            mi.Checked = !mi.Checked;
        }
    }
}
