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
        bool choice = false;
        ListView ListView1;
        public Form1()
        {
            InitializeComponent();
            // Создаем новый ListView
            this.ListView1 = new ListView();

            // список является дочерним элементом для формы
            ListView1.Parent = this;

            // список "привязан" к верхнему краю клиентской области формы
            this.ListView1.Dock = DockStyle.Top;

            // Зададим местоположение списка
            this.ListView1.Location = new System.Drawing.Point(0, 0);

            // Зададим размеры списка
            this.ListView1.Size = new System.Drawing.Size(292, 130);

            // Установим табличный режим отображения
            this.ListView1.View = View.Details;

            // При выборе элемента списка будет подсвечена вся строка
            this.ListView1.FullRowSelect = true;

            string[] breakfast = new string[]{"Continental Breakfast", 
            "Pancakes and Sausage", "Denver Omelet", "Eggs & Bacon", 
            "Bagel & Cream Cheese"};

            string[] breakfastPrices = new string[]{"3.09", "4.09", 
            "4.19", "4.79", "2.09"};

            PopulateMenu("Breakfast", breakfast, breakfastPrices);

        }
        private void PopulateMenu(string meal,string[] menuItems, string[] menuPrices)
        {
            // Создаём первый столбец для табличного режима
            ColumnHeader columnHeader1 = new ColumnHeader();
            // Укажем название столбца
            columnHeader1.Text = meal + " Choices";
            // Зададим выравнивание столбца
            columnHeader1.TextAlign = HorizontalAlignment.Left;
            // Установим ширину столбца
            columnHeader1.Width = 146;

            // Создаём второй столбец для табличного режима
            ColumnHeader columnHeader2 = new ColumnHeader();
            // Укажем название столбца
            columnHeader2.Text = "Price";
            // Зададим выравнивание столбца
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            // Установим ширину столбца
            columnHeader2.Width = 142;

            // Добавим столбцы в список
            this.ListView1.Columns.Add(columnHeader1);
            this.ListView1.Columns.Add(columnHeader2);

            for (int count = 0; count < menuItems.Length; count++)
            {
                // Создадим элемент списка, указав в конструкторе текст элемента списка
                ListViewItem listItem = new ListViewItem(menuItems[count]);

                // Для элемента списка зададим подэлемент (второй столбец в табличном представлении)
                listItem.SubItems.Add(menuPrices[count]);

                // Созданный элемент списка присоединим к списку
                ListView1.Items.Add(listItem);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // ListView1.SelectedIndices - коллекция индексов выбранных элементов списка
            for (int i = 0; i < ListView1.SelectedIndices.Count; i++)
            {
                
                // ListView1.Items[i].SubItems - коллекция столбцов
                for (int j = 0; j < ListView1.Items[i].SubItems.Count; j++)
                {
                    // индекс выделенного элемента списка
                    int selected_index = ListView1.SelectedIndices[i];
                    // получим значение каждого столбца выделенного элемента списка
                    MessageBox.Show(ListView1.Items[selected_index].SubItems[j].Text);
                }
            }
            if (choice)
            {
                // Если это уже ланч - отключим кнопку выбора :)
                button1.Enabled = false;
                return;
            }

            // Создадим новые значения для списка
            string[] lunch = new string[]{"Hamburger", "Grilled Cheese", "Soup & Salad", "Club Sandwich", "Hotdog"};

            string[] lunchPrices = new string[]{"4.09", "5.09", "5.19","4.79", "2.09"};

            ListView1.Clear(); // очищаем список

            PopulateMenu("Lunch", lunch, lunchPrices);
            button1.Text = "Lunch choice";
            choice = true;
        }

    }
}
