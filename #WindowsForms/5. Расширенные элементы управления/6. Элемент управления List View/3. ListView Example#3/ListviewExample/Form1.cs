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
        ListView ListView1;
        public Form1()
        {
            InitializeComponent();

            // Создаем новый ListView
            this.ListView1 = new ListView();

            // Зададим цвет фона списка
            this.ListView1.BackColor = SystemColors.Control;

            // список "привязан" к верхнему краю клиентской области формы
            this.ListView1.Dock = DockStyle.Top;

            // Зададим местоположение списка
            this.ListView1.Location = new Point(0, 0);

            // Зададим размеры списка
            this.ListView1.Size = new Size(292, 130);

            // Установим табличный режим отображения
            this.ListView1.View = View.Details;

            // Запретим кликать мышкой по заголовку столбца
            this.ListView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            // Добавим списку обработчик события изменения выбора элемента
            this.ListView1.SelectedIndexChanged +=new EventHandler(ListView1_SelectedIndexChanged);

            // Создаём первый столбец для табличного режима
            ColumnHeader columnHeader1 = new ColumnHeader();
            // Укажем название столбца
            columnHeader1.Text = "Breakfast Item";
            // Зададим выравнивание столбца
            columnHeader1.TextAlign = HorizontalAlignment.Left;
            // Установим ширину столбца
            columnHeader1.Width = 146;

            // Создаём второй столбец для табличного режима
            ColumnHeader columnHeader2 = new ColumnHeader();
            // Укажем название столбца
            columnHeader2.Text = "Price Each";
            // Зададим выравнивание столбца
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            // Установим ширину столбца
            columnHeader2.Width = 142;

            // Добавим столбцы в список
            this.ListView1.Columns.Add(columnHeader1);
            this.ListView1.Columns.Add(columnHeader2);

            string[] foodList = new string[]{"Juice", "Coffee", 
            "Cereal & Milk", "Fruit Plate", "Toast & Jelly", 
            "Bagel & Cream Cheese"};
            string[] foodPrice = new string[]{"1,09", "1,09", "2,19", 
            "2,49", "1,49", "1,49"};

            for (int count = 0; count < foodList.Length; count++)
            {
                // Создадим элемент списка, указав в конструкторе текст элемента списка
                ListViewItem listItem = new ListViewItem(foodList[count]);

                // Для элемента списка зададим подэлемент (второй столбец в табличном представлении)
                listItem.SubItems.Add(foodPrice[count]);

                // Созданный элемент списка присоединим к списку
                ListView1.Items.Add(listItem);
            }
            // Добавляем ListView в коллекцию элементов управления
            this.Controls.Add(ListView1);
        }

       // Обработчик события изменения выбора элемента списка
        private void ListView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // получим коллекцию выбранных элементов списка
            ListView.SelectedListViewItemCollection breakfast = this.ListView1.SelectedItems;

            double price = 0.0;
            foreach (ListViewItem item in breakfast)
            {
                //просуммируем значения по второму столбцу (цена)
                price += Double.Parse(item.SubItems[1].Text);
            }
            // полученную сумму выведем в заголовок окна
            Text = price.ToString();
        }

       
    }
}
