using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;


namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        private Font printFont;
        private StreamReader streamToPrint;

        public Form1()
        {
            InitializeComponent();
            try
            {
                streamToPrint = new StreamReader("../../1.txt", Encoding.Default);
                string str = streamToPrint.ReadToEnd();// Вычитываем весь файл и помещаем в многострочное текстовое поле
                streamToPrint.Close();
                textBox1.Text = str;
                textBox1.SelectionStart = 0;
                textBox1.SelectionLength = 0; // Снимаем выделение
                printFont = new Font("Arial", 10);
            }
            catch (Exception ex)
            {
            }
        }

        // Метод вызывается для печати текущей страницы
        private void Doc_PrintPage(object sender, PrintPageEventArgs ev)
        {
            try
            {
                float linesPerPage = 0;
                float yPos = 0; // координата Y точки начала печати очередной строки
                int count = 0; // счётчик количества выведенных строк
                float leftMargin = ev.MarginBounds.Left; // отступ слева
                float topMargin = ev.MarginBounds.Top; // отступ сверху
                string line = null;

                // Определим, сколько строк помещается на странице
                // ev.MarginBounds.Height - высота страницы
                // Метод GetHeight возвращает значение междустрочного интервала данного шрифта в текущих единицах измерения указанного контекста Graphics. 
                linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

                // Печатаем заданное количество строк файла
                while (count < linesPerPage && ((line = streamToPrint.ReadLine()) != null))
                {
                    yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));//смещаем вниз координату Y
                    ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());// выводим очередную строку
                    count++;// увеличиваем счётчик выведенных строк
                }
                // Если есть еще строки в файле, то печатаем следующую страницу,
                // иначе закрываем поток
                // ev.HasMorePages определяет, нужно ли выводить на печать следующую страницу
                if (line != null)
                    ev.HasMorePages = true;
                else
                {
                    ev.HasMorePages = false;
                    streamToPrint.Close();
                }
            }
            catch (Exception ex)
            {

            }
       }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаем документ и прикрепляем к нему обработчик события
                PrintDocument doc = new PrintDocument(); // новое задание печати

                //  Событие PrintPage происходит, когда необходимо вывести на печать текущую страницу
                doc.PrintPage += this.Doc_PrintPage;

                // Пользователь может выбирать принтер и его свойства через стандартное диалоговое окно
                // PrintDialog printDialog1 = new PrintDialog();

                printDialog1.Document = doc;
                DialogResult result = printDialog1.ShowDialog();
                // Если выбрана кнопка OK, то печатаем документ
                if (result == DialogResult.OK)// модальный диалог
                {
                    streamToPrint = new StreamReader("../../1.txt", Encoding.Default);
                    doc.Print();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаем документ и прикрепляем к нему обработчик события
                PrintDocument doc = new PrintDocument(); // новое задание печати

                //  Событие PrintPage происходит, когда необходимо вывести на печать текущую страницу.
                doc.PrintPage += this.Doc_PrintPage;

                // PrintPreviewDialog представляет стандартное диалоговое окно предварительного просмотра
                PrintPreviewDialog dlgPreview = new PrintPreviewDialog();
                dlgPreview.Document = doc;
                streamToPrint = new StreamReader("../../1.txt", Encoding.Default);
                dlgPreview.Show(); // немодальный диалог
            }
            catch (Exception ex)
            {

            }
        }
    }
}