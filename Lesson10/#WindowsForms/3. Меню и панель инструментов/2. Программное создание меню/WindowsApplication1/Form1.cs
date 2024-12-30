using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        MainMenu MyMenu;
        MenuItem m1, m2, subm1, subm2, subm3, subm4, subm5, subm6;
        Label l;
        bool flag = true;
        bool flag2 = true;
        public Form1()
        {
            InitializeComponent();
            l = new Label();
            l.Parent = this;
            l.Location = new Point(10, 100);
            l.Width = 200;
            l.Height = 50;
            l.BorderStyle = BorderStyle.FixedSingle;
            this.Text = "Работа с меню";
            MyMenu = new MainMenu();
            m1 = new MenuItem("Игра");
            m1.Select += new EventHandler(subm1_Select);
            MyMenu.MenuItems.Add(m1);
            m2 = new MenuItem("О программе");
            m2.Select += new EventHandler(subm1_Select);
            MyMenu.MenuItems.Add(m2);
            subm1 = new MenuItem("Начать игру");
            subm1.Click += new EventHandler(BeginGame);
            subm1.Select += new EventHandler(subm1_Select);
            m1.MenuItems.Add(subm1);
            subm2 = new MenuItem("Уровень");
            subm2.Select += new EventHandler(subm1_Select);
            m1.MenuItems.Add(subm2);
            subm3 = new MenuItem("Лёгкий уровень");
            subm2.MenuItems.Add(subm3);
            subm3.Checked = true;
            subm4 = new MenuItem("Средний уровень");
            subm2.MenuItems.Add(subm4);
            subm5 = new MenuItem("Сложный уровень");
            subm2.MenuItems.Add(subm5);
            EventHandler eventhandler = delegate(object sender, EventArgs e)
            {
                MenuItem item = (MenuItem)sender;
                Menu par = item.Parent;
                for (int i = 0; i < par.MenuItems.Count; i++)
                    par.MenuItems[i].Checked = false;
                item.Checked = true;
                MessageBox.Show("Пункт меню " + item.Text);
            };
            subm3.Click += eventhandler;
            subm3.Select += new EventHandler(subm1_Select);
            subm4.Click += eventhandler;
            subm4.Select += new EventHandler(subm1_Select);
            subm5.Click += eventhandler;
            subm5.Select += new EventHandler(subm1_Select);
            subm6 = new MenuItem("Выход");
            m1.MenuItems.Add(subm6);
            subm6.Click += new EventHandler(Quit);
            subm6.Select += new EventHandler(subm1_Select);
            Menu = MyMenu;
        }

        private void subm1_Select(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            l.Text = item.Text;
        }

        //обработчик пункта меню Уровень
        /*
        private void Level(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            Menu par = item.Parent;
            for (int i = 0; i < par.MenuItems.Count; i++)
                par.MenuItems[i].Checked = false;
            item.Checked = true;
            MessageBox.Show("Пункт меню " + item.Text);
        }
        */

        //обработчик пункта меню Выход
        private void Quit(object sender, EventArgs e)
        {
            Close();
        }

        //обработчик пункта меню Начать игру
        private void BeginGame(object sender, EventArgs e)
        {
            MessageBox.Show("Пункт меню 'Начать игру'");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                button1.Text = "Включить главное меню";
                Menu = null;
            }
            else
            {
                button1.Text = "Отключить главное меню";
                Menu = MyMenu;
            }
            flag = !flag;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (flag2)
            {
                button2.Text = "Включить пункт меню \"О программе\"";
                MyMenu.MenuItems.Remove(m2);
            }
            else
            {
                button2.Text = "Отключить пункт меню \"О программе\"";
                m2 = new MenuItem("О программе");
                m2.Select += new EventHandler(subm1_Select);
                MyMenu.MenuItems.Add(m2);
            }
            flag2 = !flag2;
        }
    }
}