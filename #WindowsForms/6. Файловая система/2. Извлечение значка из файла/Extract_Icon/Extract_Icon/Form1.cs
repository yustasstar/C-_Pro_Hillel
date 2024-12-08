using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Extract_Icon
{
    public partial class Form1 : Form
    {
        ImageList image_list1 = new ImageList(); // список изображений для хранения малых значков
        ImageList image_list2 = new ImageList(); // список изображений для хранения больших значков
        string pathToFolder = "C:\\Windows";
        public Form1()
        {
            InitializeComponent();
            // глубина цвета изображений
            image_list1.ColorDepth = ColorDepth.Depth32Bit;

            // установим размер изображения
            image_list1.ImageSize = new Size(16, 16);

            // ассоциируем список маленьких изображений с ListView
            listView1.SmallImageList = image_list1;

            // глубина цвета изображений
            image_list2.ColorDepth = ColorDepth.Depth32Bit;

            // установим размер изображения
            image_list2.ImageSize = new Size(32, 32);

            // ассоциируем список маленьких изображений с ListView
            listView1.LargeImageList = image_list2;

            string[] files = Directory.GetFiles(pathToFolder);
            string[] directories = Directory.GetDirectories(pathToFolder);
            Icon icon = new Icon(@"../../CLSDFOLD.ICO");
            image_list1.Images.Add(icon);
            image_list2.Images.Add(icon);
            foreach (string dir in directories)
            {
                listView1.Items.Add(dir, 0);
            }
            int index = 1;
            foreach (string file in files)
            {
                icon = Icon.ExtractAssociatedIcon(file);
                image_list1.Images.Add(icon);
                image_list2.Images.Add(icon);
                listView1.Items.Add(file, index++);
            }

        }
    }
}
