using System;
using System.Drawing;
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

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                // ћетод Print класса PrintDocument задает выводимые на печать данные, 
                // обрабатыва€ событие PrintPage и использу€ Graphics, включенный в класс PrintPageEventArgs.

                // загружаем изображение из файла
                Image im1 = new Bitmap("../../1.jpg");
                Image im2 = new Bitmap("../../2.jpg");
                Graphics gr = e.Graphics;
                gr.DrawImage(im1, new Rectangle(0, 0, 640, 480), new Rectangle(0, 0, 640, 480), GraphicsUnit.Pixel);
                gr.DrawImage(im2, new Rectangle(0, 500, 640, 480), new Rectangle(0, 0, 640, 480), GraphicsUnit.Pixel);
            }
            catch (Exception ex)
            {
            }
       }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // —оздаем документ и прикрепл€ем к нему обработчик событи€
                PrintDocument doc = new PrintDocument(); // новое задание печати

                // —обытие PrintPage происходит, когда необходимо вывести на печать текущую страницу.
                doc.PrintPage += this.Doc_PrintPage;

                // PrintDialog вызывает стандартное диалоговое окно печати Microsoft Windows, 
                //позвол€ющее пользователю выбирать принтер и его свойства
                // PrintDialog printDialog1 = new PrintDialog();

                // ѕолучает или задает документ дл€ предварительного просмотра.
                printDialog1.Document = doc;
                DialogResult result = printDialog1.ShowDialog();

                // ≈сли выбрана кнопка OK, то печатаем документ
                if (result == DialogResult.OK)
                {
                    doc.Print(); // «апускаем процесс печати документа.
                    // Print задает выводимые на печать данные, обрабатыва€ событие PrintPage и использу€ Graphics, включенный в класс PrintPageEventArgs.
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
                // —оздаем документ и прикрепл€ем к нему обработчик событи€
                PrintDocument doc = new PrintDocument(); // новое задание печати

                // —обытие PrintPage происходит, когда необходимо вывести на печать текущую страницу.
                doc.PrintPage += this.Doc_PrintPage;

                // PrintPreviewDialog представл€ет стандартное диалоговое окно предварительного просмотра
                PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                printPreviewDialog1.Document = doc; // ѕолучает или задает документ дл€ предварительного просмотра.
                printPreviewDialog1.Show();
            }
            catch (Exception ex)
            {
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                // загружаем изображение из файла
                Image im1 = new Bitmap("../../1.jpg");
                Image im2 = new Bitmap("../../2.jpg");
                Graphics gr = e.Graphics;
                gr.DrawImage(im1, new Rectangle(0, 0, 640, 480), new Rectangle(0, 0, 640, 480), GraphicsUnit.Pixel);
                gr.DrawImage(im2, new Rectangle(0, 500, 640, 480), new Rectangle(0, 0, 640, 480), GraphicsUnit.Pixel);
            }
            catch (Exception ex)
            {
            }
        }
    }
}