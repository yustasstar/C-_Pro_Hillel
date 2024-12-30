using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaticControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Статик";
            label1.Parent = this;
            label1.Location = new Point(10, 10); // Location – позиция левого верхнего угла
            // label1.AutoSize = true; //подстройка размера статика под содержимое
            label1.Width = 200; // ширина статика
            label1.Height = 200; // высота статика
            label1.BorderStyle = BorderStyle.Fixed3D; // трёхмерный стиль границ
            BackColor = Color.AliceBlue; // цвет фона формы
            label1.BackColor = Color.Orange; // цвет фона статика
            label1.ForeColor = Color.FromArgb(255, 0, 0); // цвет текста на статике
            label1.Cursor = Cursors.Hand; // тип курсора
            Opacity = 0.8; // Степень прозрачности формы
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            Label l = (Label)sender;
            l.Text = String.Format("X = {0}  Y = {1}", e.X, e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = String.Format("X = {0}  Y = {1}", e.X, e.Y);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://msdn.microsoft.com/ru-ru/default.aspx");
        }
    }
}
