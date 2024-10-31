using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace PNGEDIT1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            // Для диалогов открытия и сохранения начальная директория - Мои рисунки
            openFileDialog1.InitialDirectory = saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
      }

         private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string s = openFileDialog1.FileName;
                try
                {
                    // класс Bitmap является производным от Image
                    Image im = new Bitmap(s); // присоединим изображение из указанного файла к объекту Bitmap
                    if (pictureBox1.Image != null)
                        pictureBox1.Image.Dispose(); // освободим предыдущий объект Image
                    pictureBox1.Image = im; // поместим на PictureBox выбранное изображение
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                Text = "Image Viewer - " + s;
                saveFileDialog1.FileName = s;
                openFileDialog1.FileName = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s0 = saveFileDialog1.FileName; 
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string s = saveFileDialog1.FileName;
                // .NET не даст сохранить изображение в тот же файл, из которого загружали
                if (s.ToUpper() == s0.ToUpper())// если пытаемся сохранять изображение в тот же файл, из которого загружали
                {
                    // сохраним изображение во временный файл
                    s0 = Path.GetDirectoryName(s0) + "\\($$##$$)";
                    pictureBox1.Image.Save(s0);
                    // разрушим объект Bitmap, связанный с данным изображением 
                    pictureBox1.Image.Dispose();
                    // удалим исходный файл
                    File.Delete(s);
                    // имя временного файла заменим на имя исходного файла
                    File.Move(s0, s);
                    // загрузим на PictureBox новый вариант файла
                    pictureBox1.Image = new Bitmap(s);
                }
                else
                    // сохраним изображение в файл
                    if (pictureBox1.Image != null)
                        pictureBox1.Image.Save(s);
                Text = "Image Editor - " + s;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image im = new Bitmap(500, 300);
            Graphics g = Graphics.FromImage(im);
            g.Clear(Color.White);
            g.Dispose();
            if (pictureBox1.Image != null)
                pictureBox1.Image.Dispose(); // освободим предыдущий объект Image
            pictureBox1.Image = im; // поместим на PictureBox выбранное изображение
        }
    }
}
