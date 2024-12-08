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
        private TreeView treeView1;
        private Button button;
        private TextBox edit;

        public Form1()
        {
            InitializeComponent();
            // создаём объект "дерево просмотра"
            treeView1 = new TreeView();
            button = new Button();
            edit = new TextBox();

            // "Заморозим" изменение элементов управления
            this.SuspendLayout();

            // установим местоположение дерева
            treeView1.Location = new Point(0, 0);
            // Зададим размеры дерева
            treeView1.Size = new Size(292, 248);

            treeView1.HideSelection = false;

            // нажатие кнопки мыши на любом месте дерева
            treeView1.MouseDown += new MouseEventHandler(treeView1_MouseDown);

            // событие AfterSelect - происходит после выбора узла дерева
            treeView1.AfterSelect +=new TreeViewEventHandler(treeView1_AfterSelect);
            // Добавляем узлы в дерево
            TreeNode node;
            for (int x = 0; x < 3; ++x)
            {
                // Добавляем корневой узел
                node = treeView1.Nodes.Add(String.Format("Node{0}", x * 4));
                for (int y = 1; y < 4; ++y)
                {
                    // Добавляем дочерние узлы 
                    node = node.Nodes.Add(String.Format("Node{0}", x * 4 + y));
                }
            }

            // Инициализация кнопки
            button.Location = new Point(0, 250);
            button.Text = "Вставить новый узел";
            button.Size = new Size(150, 30);
            button.Click +=new EventHandler(button_Click);

            // Инициализация текстового поля
            edit.Location = new Point(160, 250);
            edit.Text = "Введите текст";
            edit.Size = new Size(100, 50);

            // Инициализация формы
            this.ClientSize = new Size(292, 300);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Добавление элементов управления в коллекцию Controls
            this.Controls.Add(treeView1);
            this.Controls.Add(button);
            this.Controls.Add(edit);

            // Настройки для всех элементов формы одновременно вступают в силу
            this.ResumeLayout(false);

        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                // Удалим узел под курсором мыши, если нажата правая кнопка 
                TreeNode node = treeView1.GetNodeAt(e.X, e.Y); // получим узел по координатам мыши
                if (node != null)
                    node.Remove();
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // поместим текст выделенного элемента в заголовок окна
            Text = e.Node.Text;
        }

        private void button_Click(object sender, EventArgs e)
        {
            string str = edit.Text;
            str = str.Trim();
            if(str.Length == 0)
            {
                MessageBox.Show("Не указан текст для нового узла");
                return;
            }
            // получим выделенный узел
            TreeNode node = treeView1.SelectedNode;
            if (node == null)
            {
                // добавим узел в коллекцию корневых узлов
                treeView1.Nodes.Add(str);
            }
            else
            {
                // Получим родителя для выделенного узла
                TreeNode parent = node.Parent;
                if (parent == null)
                    // если родителя нет, то выделенный узел корневой
                    treeView1.Nodes.Insert(node.Index, str); 
                else
                    node.Parent.Nodes.Insert(node.Index, str);
            }
        }
    }
}
