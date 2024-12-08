using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void butScreenCapture_Click(object sender, EventArgs e)
        {
            // Вычисляем размеры экрана
            Bitmap screenPicture = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                 Screen.PrimaryScreen.Bounds.Height);
            using (Graphics g = Graphics.FromImage(screenPicture))//Создадим новый объект Graphics из указанного рисунка Image
            {
                // копируем изображение всего экрана
                g.CopyFromScreen(0, 0, 0, 0, screenPicture.Size);
            }
            pictureBox1.Image = screenPicture;
            screenPicture.Save("Screen.jpg", ImageFormat.Jpeg);

            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            /*
             public void DrawToBitmap(
	                Bitmap bitmap, // Точечный рисунок, который требуется нарисовать.
	                Rectangle targetBounds // Границы, в которых выполняется визуализация элемента управления.
                )
             */
            // Получим изображение формы
            this.DrawToBitmap(bitmap, new Rectangle(new Point(0, 0), this.Size));
            bitmap.Save("Screen2.jpg", ImageFormat.Jpeg);// Сохраняет объект Image в указанный файл в указанном формате.
            bitmap.Dispose();
            // Получим изображение кнопки
            Bitmap bitmap2 = new Bitmap(butScreenCapture.Width, butScreenCapture.Height);
            butScreenCapture.DrawToBitmap(bitmap2, new Rectangle(new Point(0, 0), butScreenCapture.Size));
            bitmap2.Save("Screen3.jpg", ImageFormat.Jpeg);// Сохраняет объект Image в указанный файл в указанном формате.
            bitmap2.Dispose();

        }

    }
}