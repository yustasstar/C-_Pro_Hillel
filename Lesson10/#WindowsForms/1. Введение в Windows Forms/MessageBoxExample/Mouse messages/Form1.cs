using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mouse_messages
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Windows Forms";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Width = 500;
            this.Height = 500;
        }

        /*
         public event MouseEventHandler MouseMove; - событие
         * 
         public delegate void MouseEventHandler( - делегат.
           object sender, - ссылка на тот объект, которому пришло событие.
           MouseEventArgs events – содержит дополнительную информацию о сообщении мыши.
        );

        Свойства MouseEventArgs.
        public int X {get;} – координаты мыши.
        public int Y {get;}
        public int Delta {get;} – количество сдвигов колеса
        public MouseButtons Button {get;} – перечисление, которое определяет какие кнопки 
                    мыши были нажаты в момент возникновения события. (	Left Middle	Right )
        */
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Form frm = (Form)sender;
            frm.Text = String.Format("x = {0}  y = {1}  Button = {2}", e.X, e.Y, e.Button);
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Двойной щелчок мышью", "Обработка сообщений мыши", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Form frm = (Form)sender;
            frm.Text = String.Format("x = {0}  y = {1}  Button = {2}", e.X, e.Y, e.Button);
            if (e.Button == MouseButtons.Right)
                MessageBox.Show("Вы нажали правую кнопку мыши", "Обработка сообщений мыши", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (e.Button == MouseButtons.Middle)
                MessageBox.Show("Вы нажали среднюю кнопку", "Обработка сообщений мыши", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
