using System;
using System.Windows.Forms;
using System.Drawing.Printing;


namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1Click(object sender, EventArgs e)
        {
            try
            {
                // Свойство PrinterSettings.InstalledPrinters получает названия всех принтеров, установленных на компьютере.
                foreach (string printerName in PrinterSettings.InstalledPrinters)
                {
                    // Выводим имя принтера
                    textBox1.Text += "Принтер: " + printerName + "\r\n";
                    // Объект класса PrinterSettings представляет собой описание принтера
                    PrinterSettings printer = new PrinterSettings(); // Получаем настройки принтера по умолчанию
                    printer.PrinterName = printerName; // название и модель принтера
                    // Проверяем, действителен ли принтер
                    if (printer.IsValid)
                    {
                        // Выводим список поддерживаемых разрешений
                        textBox1.Text += "Поддерживаемые разрешения:" + "\r\n";
                        foreach (PrinterResolution resolution in printer.PrinterResolutions)
                        {
                            textBox1.Text += resolution + "\r\n";
                        }
                        textBox1.Text += "\r\n";
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}