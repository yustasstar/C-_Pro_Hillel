using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard_messages
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true; // Сообщения клавиатуры будут приходить главному окну (форме)
            Text = "Разрешение экрана: " + Screen.PrimaryScreen.Bounds.Width.ToString() +
                "x" + Screen.PrimaryScreen.Bounds.Height.ToString()
                + "   Рабочая область экрана: " + Screen.GetWorkingArea(this).Width.ToString() +
                "x" + Screen.GetWorkingArea(this).Height.ToString(); 
        }
        /*
             public delegate void KeyEventHandler(
	            Object sender,- ссылка на тот объект, которому пришло событие.
	            KeyEventArgs e - содержит дополнительную информацию о клавиатурном сообщении.
            );
 
            Свойства KeyEventArgs.
            public int KeyValue { get; } - виртуальный код клавиши
            public Keys KeyCode { get; } - название клавиши
            public Keys KeyData { get; } - название нажатой клавиши вместе с любыми флагами, показывающими, 
                                           какие из клавиш CTRL, SHIFT и ALT были одновременно нажаты 
            public enum Keys – название клавиши (например, Keys.Return, Keys.Left, Keys.A и т.д.)
        */
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Form frm = (Form)sender;
            frm.Text = "KeyValue = " + e.KeyValue.ToString()
                + "   KeyCode = " + e.KeyCode
                + "   KeyData = " + e.KeyData;
            if (e.KeyCode == Keys.Return)
                MessageBox.Show("Нажата клавиша <ENTER>");
            else if (e.KeyCode == Keys.A && e.Shift)
                MessageBox.Show("Нажата комбинация клавиш <SHIFT><A>");
            else if (e.KeyCode == Keys.Escape)
                Application.Exit();
        }
    }
}
