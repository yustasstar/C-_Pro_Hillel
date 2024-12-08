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
        int number = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            // ������������� �� ������ ������� ��� ������ SelectedTab
            this.tabControl1.SelectedTab = this.tabPage2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ������������� �� ������ ������� ��� ������ SelectedIndex
            this.tabControl1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ��������� ����� ������� 
            tabControl1.Controls.Add(new TabPage("����� �������"));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // ������� ��������� ������� 
            tabControl1.Controls.Remove(tabControl1.SelectedTab); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int target = tabControl1.SelectedIndex;
            int counter = tabControl1.Controls.Count;
            // ��������� ������������ ������� � ������� �������� 
            Control[] c = new Control[counter];
            tabControl1.Controls.CopyTo(c, 0);
            tabControl1.Controls.Clear();

            // ��������� ������� �� ������������ �������� 
            for (int i = 0; i < target; ++i)
                tabControl1.Controls.Add(c[i]);
            // ��������� ���� ������� 
            tabControl1.Controls.Add(new TabPage("����������� �������"+number.ToString()));
            number++;
            // ��������� ������� ����� ������������ �������� 
            for (int i = target; i < counter; ++i)
                tabControl1.Controls.Add(c[i]);

            // �������� ����������� ������� 
            tabControl1.SelectedIndex = target;
        }
    }
}