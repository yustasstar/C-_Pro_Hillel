using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoodsCatalog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ClearAll_Click(object sender, EventArgs e)
        {//Очистить весь список
            listBox1.Items.Clear();
        }

        private void DeleteGood_Click(object sender, EventArgs e)
        {//Удаление выделенного элемента
            if (listBox1.SelectedIndex == -1)//Если товар не выбран
            {
                MessageBox.Show("Вы не выбрали товар"); 
                return;
            }
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            
        }
        Tovar t = null;
        private void AddGood_Click(object sender, EventArgs e)
        {//Добавление товара
            t = new Tovar();
            Form2 addform = new Form2(t, true);
            if (addform.ShowDialog() == DialogResult.OK)
            {//если пользователь нажал ок, добавляем товар в список
                listBox1.Items.Add(t);
            }
        }

        private void EditGood_Click(object sender, EventArgs e)
        {//редактирование товара
            if (listBox1.SelectedIndex == -1)//Если товар не выбран
            {
                MessageBox.Show("Вы не выбрали товар"); return;
            }

            int n = listBox1.SelectedIndex;//запоминаем выделенный элемент
            t = (Tovar)listBox1.Items[n];//Забираем ссылку на выделенный элемент
            Form2 editform = new Form2(t, false);
            editform.ShowDialog();
            listBox1.Items.RemoveAt(n);//Удаляем выделенный элемент
            listBox1.Items.Insert(n, t);//и добавляем его снова в ту же позицию, чтобы он перерисовался в списке
            listBox1.SelectedIndex = n; //Снова выделяем этот элемент
        }
    }
}
