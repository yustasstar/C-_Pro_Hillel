using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageBoxExample
{
    /*
    public static DialogResult Show( - отображает Message Box
       string text, - содержимое 
       string caption, - заголовок
       MessageBoxButtons buttons, - enum кнопок
				    AbortRetryIgnore
 				    OK
				    OKCancel
 				    RetryCancel
				    YesNo
 				    YesNoCancel
       MessageBoxIcon icon- enum иконки
 				    Asterisk
 				    Error
 				    Exclamation
 				    Question
    );
    DialogResult определяет на какую кнопку нажал пользователь для закрытия Message Box.
 			    OK
 			    Cancel
 			    Ignore
*/
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("Старт!", "Окна сообщений");

            MessageBox.Show(Application.ExecutablePath, "Путь к запущенному ехе-файлу",
                MessageBoxButtons.OK, MessageBoxIcon.Information); // путь к запущенному ехе-файлу

            MessageBox.Show(Application.StartupPath, "Путь к папке, в которой находится ехе-файл",
                MessageBoxButtons.OK, MessageBoxIcon.Information); // путь к папке, в которой находится ехе-файл.

            DialogResult result = MessageBox.Show("Нажмите на одну из кнопок", "Окна сообщений",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Нажата кнопка OK", "Окна сообщений");
            }
            else if (result == DialogResult.Cancel)
            {
                MessageBox.Show("Нажата кнопка Отмена", "Окна сообщений");
            }
            result = MessageBox.Show("Нажмите на одну из кнопок", "Окна сообщений", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question);
            if (result == DialogResult.Abort)
            {
                MessageBox.Show("Нажата кнопка Прервать", "Окна сообщений", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == DialogResult.Retry)
            {
                MessageBox.Show("Нажата кнопка Повтор", "Окна сообщений", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (result == DialogResult.Ignore)
            {
                MessageBox.Show("Нажата кнопка Пропустить", "Окна сообщений", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
