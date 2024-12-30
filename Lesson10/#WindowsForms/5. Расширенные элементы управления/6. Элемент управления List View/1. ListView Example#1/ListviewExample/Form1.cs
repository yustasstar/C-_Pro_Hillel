using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListviewExample
{
    public partial class Form1 : Form
    {
        ListView listView1;
        public Form1()
        {
            InitializeComponent();
            // Создаем новый ListView
            listView1 = new ListView();

            // Зададим размер и местоположение списка на форме
            listView1.Bounds = new Rectangle(new Point(10, 30), new Size(300, 200));

            // Установим табличный режим отображения
            listView1.View = View.Details;

            // Позволим пользователю редактировать поле элемента списка
            listView1.LabelEdit = true;

            // Позволим пользователю перемещать столбцы в табличном режиме
            listView1.AllowColumnReorder = true;

            // Возле каждого элемента списка будет флажок
            listView1.CheckBoxes = true;

            // При выборе элемента списка будет подсвечена вся строка
            listView1.FullRowSelect = true;

            // Отобразим линии сетки в табличном режиме
            listView1.GridLines = true;

            // Установим сортировку элементов в порядке возрастания
            listView1.Sorting = SortOrder.Ascending;

            // Создадим три элемента списка и три подэлемента для каждого из них 
            ListViewItem item1 = new ListViewItem("item1", 0);
            item1.Checked = true; // Флажок элемента списка будет включен
            item1.SubItems.Add("1");
            item1.SubItems.Add("2");
            item1.SubItems.Add("3");

            ListViewItem item2 = new ListViewItem("item2", 1);
            item2.SubItems.Add("4");
            item2.SubItems.Add("5");
            item2.SubItems.Add("6");

            ListViewItem item3 = new ListViewItem("item3", 0);
            item3.Checked = true; // Флажок элемента списка будет включен
            item3.SubItems.Add("7");
            item3.SubItems.Add("8");
            item3.SubItems.Add("9");

            // Создадим колонки (1 параметр - название столбца, 2 параметр - ширина столбца, выравнивание названия)
            listView1.Columns.Add("Item Column", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 2", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 3", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 4", 60, HorizontalAlignment.Center);

            // Добавляем элементы в список
            listView1.Items.AddRange(new ListViewItem[] { item1, item2, item3 });

            // Создаем два пустых списка изображений для больших и малых значков
            ImageList imageListSmall = new ImageList();
            ImageList imageListLarge = new ImageList();
            imageListLarge.ImageSize = new Size(48, 48);

            // Инициализируем списки изображений картинками
            imageListSmall.Images.Add(Bitmap.FromFile("1.bmp"));
            imageListSmall.Images.Add(Bitmap.FromFile("2.bmp"));
            imageListLarge.Images.Add(Bitmap.FromFile("3.bmp"));
            imageListLarge.Images.Add(Bitmap.FromFile("4.bmp"));

            // ассоциируем списки изображений с ListView
            listView1.LargeImageList = imageListLarge;
            listView1.SmallImageList = imageListSmall;

            // Добавляем ListView в коллекцию элементов управления
            this.Controls.Add(listView1);

            Width = 350; // Ширина формы
            Height = 250; // Высота формы
        }

        private void большиеЗначкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void малыеЗначкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }

        private void таблицаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }
    }
}
