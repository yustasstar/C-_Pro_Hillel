using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TimerExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*
            public Timer(); - конструктор.
            public int Interval {get; set;} – для задания интервала в миллисекундах. 
            public void Start(); - запускает таймер
            public void Stop(); - останавливает таймер.
            public virtual bool Enabled {get; set;} – запускает или останавливает таймер.
            public event EventHandler Tick; - событие для обработки прерываний таймера
            public delegate void EventHandler( 
               object sender, - ссылка на тот таймер, для которого сработало событие
               EventArgs e  - дополнительная информация о событии.
            );
        */

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = DateTime.Now.ToString();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                timer1.Start();
            if (e.Button == MouseButtons.Right)
                timer1.Stop();
        }
    }
}
