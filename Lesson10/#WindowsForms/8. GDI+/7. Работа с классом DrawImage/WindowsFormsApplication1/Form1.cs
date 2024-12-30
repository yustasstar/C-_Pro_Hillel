using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 400;
            this.Height = 400;

            // создаем битовый образ по размеру экрана
            Bitmap screenPicture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            // создаем объект Graphics из указанного рисунка Image (или Bitmap).
            Graphics g1 = Graphics.FromImage(screenPicture);
            // создаем скриншот экрана
            g1.CopyFromScreen(0, 0, 0, 0, screenPicture.Size);
            // освобождаем объект Graphics (контекст устройства)
            // Graphics инкапсулирует поверхность рисования GDI+
            g1.Dispose();

            // загружаем изображение из файла
            Image im1 = new Bitmap("autumn.jpg");

            // создаем новое изображение
            Image im2 = new Bitmap(400, 400);
            // создаем объект Graphics из созданного изображения
            Graphics g2 = Graphics.FromImage(im2);
            // заполняем изображение белым цветом
            g2.Clear(Color.White);
            // связываем изображение с PictureBox
            pictureBox1.Image = im2;

            // рисуем на PictureBox 4 фрагмента изображений
            g2.DrawImage(screenPicture, new Rectangle(0, 200, 200, 200), new Rectangle(200, 200, 200, 200), GraphicsUnit.Pixel);
            g2.DrawImage(screenPicture, new Rectangle(200, 0, 200, 200), new Rectangle(0, 0, 200, 200), GraphicsUnit.Pixel);
            g2.DrawImage(im1, new Rectangle(0, 0, 200, 200), new Rectangle(0, 0, 200, 200), GraphicsUnit.Pixel);
            g2.DrawImage(im1, new Rectangle(200, 200, 200, 200), new Rectangle(200, 200, 200, 200), GraphicsUnit.Pixel);

            // освобождаем объект Graphics (контекст устройства)
            g2.Dispose();
        }
    }
}
