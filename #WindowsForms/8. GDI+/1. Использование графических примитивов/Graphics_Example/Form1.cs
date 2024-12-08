using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Graphics_Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // обработчик Paint срабатывает при необходимости прорисовки формы или элемента управления
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            /* Graphics инкапсулирует поверхность рисования GDI+. 
            Класс Graphics предоставляет методы для вывода объектов в устройстве отображения. 
            Объект Graphics связан с конкретным контекстом устройства.
            */
            using (Graphics g = e.Graphics) 
            {
                // using неявно вызывает метод Dispose для освобождения системных ресурсов, когда они больше не используются
                //(в данном случае для освобождения объекта Graphics)

                // Pen определяет объект, используемый для рисования прямых линий и кривых.
                using(Pen pen = new Pen(Color.Red, 3.0f)) // создаем перо красного цвета
                {
                    // using неявно вызывает метод Dispose для освобождения системных ресурсов, когда они больше не используются
                    // (в данном случае для освобождения объекта Pen)

                    /*
                     Проводит линию, соединяющую две точки, задаваемые парами координат.
                     public void DrawLine(
                         Pen pen, //Структура Pen, определяющая цвет, ширину и стиль линии. 
                         int x1,// Координата X первой точки. 
                         int y1, // Координата Y первой точки. 
                         int x2, // Координата X второй точки. 
                         int y2 // Координата Y второй точки. 
                     )
                     */
                    g.DrawLine(pen, 0, 0, 200, 100); // рисуем линию

                    /*
                    Рисует эллипс, определяемый ограничивающей структурой Rectangle.
                    public void DrawEllipse(
	                    Pen pen, // Структура Pen, определяющая цвет, ширину и стиль эллипса.
	                    Rectangle rect // Структура Rectangle, определяющая границы эллипса.
                    )
                    */
                    g.DrawEllipse(pen, new Rectangle(50, 50, 100, 150)); // рисуем эллипс
                }

                string s = "Sample Text";
                //Font определяет конкретный формат текста, включая начертание шрифта, его размер и атрибуты стиля.
                Font font = new Font("Arial", 18); // создаем шрифт Arial размером 18pt

                // Определяет кисть одного цвета. Кисти используются для заливки графических фигур, 
                // таких как прямоугольники, эллипсы, круги, многоугольники и контуры.
                SolidBrush brush = new SolidBrush(Color.Blue); // создаем кисть синего цвета

                /*
                Создает указываемую текстовую строку в заданном месте с помощью определяемых объектов Brush и Font.
                public void DrawString(
	                string s, // Строка для рисования. 
	                Font font, // Объект Font, определяющий формат текстовой строки. 
	                Brush brush, // Объект Brush, определяющий цвет и текстуру создаваемого текста. 
	                float x, // Координата X верхнего левого угла отображаемого текста. 
	                float y // Координата Y верхнего левого угла отображаемого текста. 
                )
                */
                float x = 100.0F;
                float y = 20.0F;
                g.DrawString(s, font, brush, x, y); // выводим текст

               using(Pen pen = new Pen(Color.Black, 3))
               {
                Point[] points =
                 {
                     new Point(15,  10),
                     new Point(15, 100),
                     new Point(200,  50),
                     new Point(250, 250)
                 };
                /*
                   public void DrawLines(
	                    Pen pen, // Структура Pen, определяющая цвет, ширину и стиль сегментов линии. 
	                    Point[] points // Массив структур Point, которые представляют собой точки для соединения. 
                    )
                                        
                */
                g.DrawLines(pen, points); // рисуем ломаную линию
               }
                font.Dispose(); // освобождаем шрифт
                brush.Dispose(); // освобождаем кисть
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
             Создает новый объект Graphics из указанного дескриптора окна.
             public static Graphics FromHwnd(
	            IntPtr hwnd
            )
            */
            Graphics gr = Graphics.FromHwnd(this.Handle);
            gr.DrawLine(new Pen(Color.Green), 10, 50, 10, 200); // рисуем на форме

            Graphics gr1 = Graphics.FromHwnd(label1.Handle);
            gr1.DrawLine(new Pen(Color.Green, 5.0f), 20, 10, 90, 10); // рисуем на статике

            /*
            Рисует прямоугольник, который определен парой координат, шириной и высотой.
            public void DrawRectangle(
	            Pen pen, // Структура Pen, определяющая цвет, ширину и стиль прямоугольника. 
	            int x, // Координата X верхнего левого угла прямоугольника для рисования. 
	            int y, // Координата Y верхнего левого угла прямоугольника для рисования. 
	            int width, // Ширина прямоугольника для рисования. 
	            int height // Высота прямоугольника для рисования. 
            )
            */
            using (Pen p = new Pen(Color.Red, 4f))
            {
                p.DashStyle = DashStyle.DashDotDot;
                gr.DrawRectangle(p, 160, 100, 100, 100); // отрисовываем контур прямоугольника штриховой линией
            }
            

            // Определяет кисть одного цвета. Кисти используются для заливки графических фигур, 
            // таких как прямоугольники, эллипсы, круги, многоугольники и контуры.
            SolidBrush brush = new SolidBrush(Color.Blue);

            /*
           Заполняет внутреннюю часть прямоугольника, который определен парой координат, шириной и высотой.
           public void FillRectangle(
               Brush brush, // Объект Brush, определяющий параметры заливки.  
               int x, // Координата X верхнего левого угла прямоугольника для заливки. 
               int y, // Координата Y верхнего левого угла прямоугольника для заливки. 
               int width, // Ширина прямоугольника для заливки. 
               int height // Высота прямоугольника для заливки. 
           )
           */
            gr.FillRectangle(brush, 300, 10, 100, 100); // заполняем прямоугольник синей кистью

            // Задает прямоугольную кисть со стилем штриховки, основным цветом и цветом фона.
            HatchBrush hatch_brush = new HatchBrush(HatchStyle.ZigZag, Color.Green, Color.Tomato);
            /*
            Заполняет внутреннюю часть эллипса, определяемого ограничивающим прямоугольником, заданным с помощью пары координат, ширины и высоты.
             public void FillEllipse(
	            Brush brush, //  Объект Brush, определяющий параметры заливки. 
	            int x, // Координата X верхнего левого угла ограничивающего прямоугольника, который определяет эллипс. 
	            int y, // Координата Y верхнего левого угла ограничивающего прямоугольника, который определяет эллипс. 
	            int width, // Ширина ограничивающего прямоугольника, определяющего эллипс. 
	            int height // Высота ограничивающего прямоугольника, определяющего эллипс.
            )
            */
            gr.FillEllipse(hatch_brush, 300, 120, 100, 100); // заполняем прямоугольник узорчатой кистью

            using(Pen p = new Pen(hatch_brush,10))
            {
                gr.DrawEllipse(p, 450, 10, 100, 100); // отрисовываем контур круга
            }
     
            Image img = Image.FromFile("fon2.bmp");
            TextureBrush texture = new TextureBrush(img);
            gr.FillRectangle(texture, 450, 120, 100, 100); // заполняем прямоугольник текстурой

            LinearGradientBrush gradient = new LinearGradientBrush(new Point(12, 12),
                new Point(110, 110), Color.Red, Color.Black);
            gr.FillRectangle(gradient, 600, 10, 100, 100); // заполняем прямоугольник градиентной заливкой

            Point[] pts = new Point[6] { new Point(600, 150), new Point(640, 130), new Point(680, 140), new Point(700, 200), new Point(680, 230), new Point(620, 200) };

            // Инкапсулирует объект Brush, заполняющий градиентом внутреннюю область объекта GraphicsPath
            PathGradientBrush path = new PathGradientBrush(pts);
             /*
             Заполняет внутреннюю часть многоугольника, определяемого массивом точек, заданных структурами Point.
             public void FillPolygon(
	                Brush brush, // Объект Brush, определяющий параметры заливки. 
	                Point[] points, // Массив структур Point, которые представляют вершины закрашиваемого многоугольника. 
                )
             */
            gr.FillPolygon(path, pts);

            // Освобождаем системные ресурсы
            brush.Dispose();
            path.Dispose();
            img.Dispose();
            texture.Dispose();
            gradient.Dispose();
            gr1.Dispose();
            gr.Dispose();
        }
    }
}