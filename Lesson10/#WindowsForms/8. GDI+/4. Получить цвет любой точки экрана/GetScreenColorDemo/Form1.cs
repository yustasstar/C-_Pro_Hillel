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
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Создаем битовый образ, соответствующий размерам экрана
            Bitmap screenPicture = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                 Screen.PrimaryScreen.Bounds.Height);
            using (Graphics g = Graphics.FromImage(screenPicture))
            {
                /*
                 // создает скриншот экрана
                 public void CopyFromScreen(
	                int sourceX, // Координата X точки в верхнем левом углу исходного прямоугольника.
	                int sourceY, // Координата Y точки в верхнем левом углу исходного прямоугольника.
	                int destinationX, // Координата X точки в верхнем левом углу конечного прямоугольника.
	                int destinationY, // Координата Y точки в верхнем левом углу конечного прямоугольника.
	                Size blockRegionSize // Размер передаваемой области.
                )
                 */
                // копируем изображение всего экрана
                g.CopyFromScreen(0, 0, 0, 0, screenPicture.Size);
            }
            /*
             public Color GetPixel( //Получает цвет указанной точки в данном изображении Bitmap.
	            int x, // Координата точки по оси X. 
	            int y // Координата точки по оси Y. 
            )
            */
            // Получим цвет точки под курсором мыши.
            Color myColor = screenPicture.GetPixel(MousePosition.X, MousePosition.Y);
            label1.BackColor = myColor; // Покрасим статик в полученный цвет.
            // Преобразуем структуру Color в строку.
            label2.Text = ColorTranslator.ToHtml(myColor);
            screenPicture.Dispose();
        }

    }
}