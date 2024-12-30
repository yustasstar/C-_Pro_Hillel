using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckBoxControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Width = 300;
            Height = 100;
            this.MaximizeBox = false;
            label1.TextAlign = ContentAlignment.MiddleCenter; // выравнивание
            label1.Location = new Point(10, 10);
            label1.Width = 100; // ширина статика
            label1.Height = 20; // высота статика
            label1.BorderStyle = BorderStyle.Fixed3D; // трёхмерный стиль границ
            BackColor = Color.AliceBlue; // цвет фона формы
            label1.BackColor = Color.Orange; // цвет фона статика
            label1.ForeColor = Color.FromArgb(255, 0, 0); // цвет текста на статике
            timer1.Start();
            checkBox1.Location = new Point(120, 10);
            checkBox1.Width = 200;
            checkBox1.Text = "Показывать секунды";
            checkBox1.Checked = true; // флажок установлен
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now; // получим текущее время
            string str;
            if (checkBox1.Checked) // если флажок установлен, то отображаем секунды
                str = string.Format("{0:D2}:{1:D2}:{2:D2}", dt.Hour, dt.Minute, dt.Second);
            else // иначе секунды не отображаем
                str = string.Format("{0:D2}:{1:D2}", dt.Hour, dt.Minute);
            label1.Text = str;
        }
    }
}
