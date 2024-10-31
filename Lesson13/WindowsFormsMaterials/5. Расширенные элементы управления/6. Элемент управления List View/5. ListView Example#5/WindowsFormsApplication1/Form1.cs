using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        ListView list = new ListView();
        ColumnHeader column = new ColumnHeader();
        ColumnHeader column2 = new ColumnHeader();
        ColumnHeader column3 = new ColumnHeader();
        Button button1 = new Button();
        Button button2 = new Button();
        Button button3 = new Button();
        Button button4 = new Button();
        Button button5 = new Button();
        Button button6 = new Button();
        Button button7 = new Button();
        Button button8 = new Button();
        ImageList image_list1 = new ImageList(); // список изображений для хранения малых значков
        ImageList image_list2 = new ImageList(); // список изображений для хранения больших значков

        public Form1()
        {
            InitializeComponent();
            // список является дочерним элементом для формы
            list.Parent = this;

            // Зададим местоположение списка
            list.Location = new Point(10, 10);

            // Зададим размеры списка
            list.Size = new Size(300, 300);

            // настроим параметры столбцов (название и ширина)
            column.Text = "Город";
            column.Width = 100;
            column2.Text = "Страна"; 
            column2.Width = 70;
            column3.Text = "Континент"; 
            column3.Width = 120;
            // добавим столбцы в список
            list.Columns.AddRange(new ColumnHeader[] { column, column2, column3 });

            // установим размеры формы
            this.Size = new Size(500, 500);

            // Установим табличный режим отображения
            list.View = View.Details;

            // При выборе элемента списка будет подсвечена вся строка
            list.FullRowSelect = true;

            // отображение линий сетки
            list.GridLines = true;

            // ширина и высота элемента списка в мозаичном стиле
            list.TileSize = new Size(200, 60);
             
            // при наведении курсора мыши на элемент, последний будет подсвечен
            list.HoverSelection = true;

            // множественная выборка
            list.MultiSelect = true;

            // возможность редактировать текст элемента
            list.LabelEdit = true;

            // возможность перемещать столбцы
            list.AllowColumnReorder = true;

            // глубина цвета изображений
            image_list1.ColorDepth = ColorDepth.Depth32Bit;

            // добавляем изображения в список изображений
            image_list1.Images.Add(Image.FromFile("1.bmp"));
            image_list1.Images.Add(Image.FromFile("2.bmp"));
            image_list1.Images.Add(Image.FromFile("3.bmp"));
            image_list1.Images.Add(Image.FromFile("4.bmp"));
            
            // установим размер изображения
            image_list1.ImageSize = new Size(16, 16);

            // ассоциируем список маленьких изображений с ListView
            list.SmallImageList = image_list1;

            // глубина цвета изображений
            image_list2.ColorDepth = ColorDepth.Depth32Bit;

            // добавляем изображения в список изображений
            image_list2.Images.Add(Image.FromFile("1.bmp"));
            image_list2.Images.Add(Image.FromFile("2.bmp"));
            image_list2.Images.Add(Image.FromFile("3.bmp"));
            image_list2.Images.Add(Image.FromFile("4.bmp"));

            // установим размер изображения
            image_list2.ImageSize = new Size(32, 32);

            // ассоциируем список маленьких изображений с ListView
            list.LargeImageList = image_list2;

            // добавим 4 элемента в список
            list.Items.AddRange(new ListViewItem[] {
                new ListViewItem(new string[]{ "Одесса", "Украина", "Европа"}, 0), 
			    new ListViewItem(new string[]{"Нью-Йорк", "США", "Северная Америка"}, 1),
                new ListViewItem(new string[]{"Пекин", "Китай", "Азия"}, 2),
                new ListViewItem(new string[]{"Каир", "Египет", "Африка"}, 3)
            });

            //настроим параметры каждой кнопки
            button1.Location = new Point(320, 10);
            button1.Width = 150;
            button1.Text = "Получить информацию";
            button1.Parent = this;
            button1.Click += new EventHandler(button1_Click);

            button2.Text = "Удалить выделенный элемент";
            button2.Location = new Point(320, 50);
            button2.Width = 150;
            button2.Parent = this;
            button2.Click += new EventHandler(button2_Click);

            button3.Text = "Удалить помеченный элемент";
            button3.Location = new Point(320, 90);
            button3.Width = 150;
            button3.Parent = this;
            button3.Click += new EventHandler(button3_Click);

            button4.Text = "Details";
            button4.Location = new Point(320, 130);
            button4.Width = 150;
            button4.Parent = this;
            button4.Click += new EventHandler(button4_Click);

            button5.Text = "LargeIcon";
            button5.Location = new Point(320, 170);
            button5.Width = 150;
            button5.Parent = this;
            button5.Click += new EventHandler(button5_Click);

            button6.Text = "SmallIcon";
            button6.Location = new Point(320, 210);
            button6.Width = 150;
            button6.Parent = this;
            button6.Click += new EventHandler(button6_Click);

            button7.Text = "List";
            button7.Location = new Point(320, 250);
            button7.Width = 150;
            button7.Parent = this;
            button7.Click += new EventHandler(button7_Click);

            button8.Text = "Tile";
            button8.Location = new Point(320, 290);
            button8.Width = 150;
            button8.Parent = this;
            button8.Click += new EventHandler(button8_Click);
            Height = 400;
            this.Width = 500;
            list.CheckBoxes = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //list.SelectedIndices - коллекция индексов выбранных элементов
            for (int i = 0; i < list.SelectedIndices.Count; i++)
            {
                for (int j = 0; j < list.Items[i].SubItems.Count; j++)
                {
                    // получим значение каждого столбца выделенного элемента списка
                    MessageBox.Show(list.Items[list.SelectedIndices[i]].SubItems[j].Text);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
           //list.SelectedIndices - коллекция индексов выбранных элементов
           for (int i = list.SelectedIndices.Count - 1; i >= 0; i--)
            {
               // удалим все выделенные элементы
                list.Items.RemoveAt(list.SelectedIndices[i]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //list.CheckedIndices - коллекция индексов отмеченных элементов
            for (int i = list.CheckedIndices.Count - 1; i >= 0; i--)
            {
                // удалим все отмеченные элементы
                list.Items.RemoveAt(list.CheckedIndices[i]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // режим табличного представления
            list.View = View.Details;
            list.CheckBoxes = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // режим отображения больших значков
            list.CheckBoxes = false; // флажки недопустимы в этом режиме
            list.View = View.LargeIcon;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // режим отображения маленьких значков
            list.CheckBoxes = false; // флажки недопустимы в этом режиме
            list.View = View.SmallIcon;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            // режим списочного представления
            list.CheckBoxes = false; // флажки недопустимы в этом режиме
            list.View = View.List;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            // мозаичный режим представления
            list.CheckBoxes = false; // флажки недопустимы в этом режиме
            list.View = View.Tile;
        }
    }
}
