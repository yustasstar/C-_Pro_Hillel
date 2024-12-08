using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void butStringToColor_Click(object sender, EventArgs e)
        {
            string htmlColor = "Red";
            // Преобразуем строку htmlColor в структуру GDI+ Color
            Color myColor = ColorTranslator.FromHtml(htmlColor);
            // установим на кнопке красный цвет фона
            butStringToColor.BackColor = myColor;

            // другой способ
            // Преобразуем строку htmlColor в структуру GDI+ Color
            Color myColor2 = ColorTranslator.FromHtml("#FF0000");
            // установим на кнопке красный цвет фона
            butStringToColor.BackColor = myColor2;
        }

        private void butColorToString_Click(object sender, EventArgs e)
        {
            // Преобразуем структуру Color в строку
            Color myColor = Color.BlueViolet;
            string htmlColor = ColorTranslator.ToHtml(myColor);
            // Выводим окно сообщения с полученным значением
            MessageBox.Show(htmlColor);
            pictureBox1.Image = Properties.Resources.cat;
        }

        private void butColorToInt_Click(object sender, EventArgs e)
        {
            // Преобразуем целое число в цвет (в структуру Color) 
            Color myColor = Color.FromArgb(0x7900FF00);
            // установим на кнопке полученный цвет фона
            butColorToInt.BackColor = myColor;
        }

        private void butSetPixel_Click(object sender, EventArgs e)
        {
           // Инициализируем новый экземпляр класса Bitmap указанным существующим изображением.
            Bitmap bm = new Bitmap(Properties.Resources.cat01);
            // Помещаем битовый образ на PictureBox
            pictureBox1.Image = bm;
            for (int i = 0; i < 400; i++)
            {
                // рисуем на изображении линию из 400 пикселей красного цвета
                bm.SetPixel(i, i, Color.Red);
            }
            // Вызовем перерисовку PictureBox
            //pictureBox1.Update();
        }

        /*
         SolidBrush определяет кисть одного цвета. Кисти используются для заливки графических фигур, 
          таких как прямоугольники, эллипсы, круги, многоугольники и контуры.
         
           FillRectangle заполняет внутреннюю часть прямоугольника, который определен парой координат, шириной и высотой.
           public void FillRectangle(
               Brush brush, // Объект Brush, определяющий параметры заливки.  
               int x, // Координата X верхнего левого угла прямоугольника для заливки. 
               int y, // Координата Y верхнего левого угла прямоугольника для заливки. 
               int width, // Ширина прямоугольника для заливки. 
               int height // Высота прямоугольника для заливки. 
           )
        */
        private void butDrawPoint_Click(object sender, EventArgs e)
        {
            /* Класс Graphics инкапсулирует поверхность рисования GDI+. 
            Класс Graphics предоставляет методы для вывода объектов в устройстве отображения. 
            Объект Graphics связан с конкретным контекстом устройства.
            */
            Graphics g = CreateGraphics();
            // Рисуем ряд черных точек
            for (int i = 0; i < 500; i += 5)
                g.FillRectangle(new SolidBrush(Color.Black), i, 10, 1, 1);
            g.Dispose();
        }
    }
}