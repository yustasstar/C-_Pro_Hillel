using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaskedTextBoxControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var source = new AutoCompleteStringCollection();
            source.AddRange(new string[]
                    {
                        "January",
                        "February",
                        "March",
                        "April",
                        "May",
                        "June",
                        "July",
                        "August",
                        "September",
                        "October",
                        "November",
                        "December"
                    });
            textBox3.AutoCompleteCustomSource = source;
            textBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        /*
            Для задания маски можно применять следующие символы:

            0: Позволяет вводить только цифры

            9: Позволяет вводить цифры и пробелы

            #: Позволяет вводить цифры, пробелы и знаки '+' и '-'

            L: Позволяет вводить только буквенные символы

            ?: Позволяет вводить дополнительные необязательные буквенные символы

            A: Позволяет вводить буквенные и цифровые символы

            .: Задает позицию разделителя целой и дробной части

            ,: Используется для разделения разрядов в целой части числа

            :: Используется в временных промежутках - разделяет часы, минуты и секунды

            /: Используется для разделения дат

            $: Используется в качестве символа валюты
        */
        private void maskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            label4.Text = maskedTextBox3.Text;
        }
    }
}
