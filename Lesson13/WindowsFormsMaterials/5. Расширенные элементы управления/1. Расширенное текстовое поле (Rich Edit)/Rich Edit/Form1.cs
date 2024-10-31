using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Rich_Edit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public string BufferText = "";

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Перед вызовом диалога Шрифт проинициализируем его
            fontDialog1.ShowColor = true;
            fontDialog1.Font = richTextBox1.SelectionFont;
            fontDialog1.Color = richTextBox1.SelectionColor;
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
                richTextBox1.SelectionColor = fontDialog1.Color;
            }

        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            // Перед вызовом диалога Цвет установим начальный цвет
            colorDialog1.Color = richTextBox1.SelectionColor;
           if (colorDialog1.ShowDialog() == DialogResult.OK && colorDialog1.Color != richTextBox1.SelectionColor)
            {
               // Если пользователь выбрал другой цвет и нажал на кнопку OK,
                // то применим к ричедиту выбранный цвет
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
               StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.Default);
               string str = sr.ReadToEnd();
               richTextBox1.Rtf = str;
                sr.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Default);
                sw.WriteLine(richTextBox1.Rtf);
                sw.Close();
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Rtf = "";
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedRtf = BufferText;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BufferText = richTextBox1.SelectedRtf;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BufferText = richTextBox1.SelectedRtf;
            richTextBox1.SelectedRtf = "";
        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedRtf = "";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = richTextBox1.TextLength;
            //richTextBox1.SelectAll(); 
        }
    }

        
}
