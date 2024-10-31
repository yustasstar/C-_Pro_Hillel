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
        private Button button1, button2;

        private TreeViewCancelEventHandler checkForCheckedChildren;
        
        public Form1()
        {
            InitializeComponent();

            // создаём объект "дерево просмотра"
            treeView1 = new TreeView();
            button1 = new Button();
            button2 = new Button();

            // "Заморозим" изменение элементов управления
            this.SuspendLayout();

            // установим местоположение дерева
            treeView1.Location = new Point(0, 25);
            // Зададим размеры дерева
            treeView1.Size = new Size(292, 248);
            // При изменении размеров формы автоматически будет изменяться размер дерева
            treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            // не будем прятать выделение узла при потере фокуса
            treeView1.HideSelection = false;
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

            button1.Size = new Size(144, 24); // размер кнопки
            button1.Location = new Point(0, 0);
            button1.Text = "Информация об узле"; // надпись на кнопке
            button1.Click += new EventHandler(Button1_Click); // обработчик события Click

            button2.Size = new Size(144, 24); // размер кнопки
            button2.Location = new Point(150, 0);
            button2.Text = "Изменить текст"; // надпись на кнопке
            button2.Click += new EventHandler(Button2_Click); // обработчик события Click

            // Инициализация формы
            this.ClientSize = new Size(292, 273);

            // Добавление элементов управления в коллекцию Controls
            this.Controls.AddRange(new Control[] { button1, button2, treeView1 });
            // Настройки для всех элементов формы одновременно вступают в силу
            this.ResumeLayout(false);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            TreeNode tree = treeView1.SelectedNode; // получим выделенный узел
            if (tree == null)
            {
                MessageBox.Show("Необходимо выделить узел");
                return;
            }
            MessageBox.Show("Выделенный узел: " + tree.Text);
            TreeNode parent = tree.Parent; // получить родительский узел
            if (parent != null)
                MessageBox.Show("Родительский узел: " + parent.Text);
            else
                MessageBox.Show("Выделенный узел является корневым!");
            if (tree.Nodes.Count == 0)
                MessageBox.Show("Выделенный узел дочерних узлов не содержит!");
            else
            {
                foreach (TreeNode node in tree.Nodes) // просмотрим коллекцию дочерних узлов
                    MessageBox.Show("Дочерний узел: " + node.Text);
            }
            TreeNode prev = tree.PrevNode; // получим предыдущий соседний узел
            if (prev != null)
                MessageBox.Show("Предыдущий узел: " + prev.Text);
            else
                MessageBox.Show("У выделенного узла нет предыдущего соседнего узла!");
            TreeNode next = tree.NextNode;  // получим следующий соседний узел
            if (next != null)
                MessageBox.Show("Следующий узел: " + next.Text);
            else
                MessageBox.Show("У выделенного узла нет следующего соседнего узла!");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            TreeNode tree = treeView1.SelectedNode; // получим выделенный узел
            if (tree != null)
                tree.Text = "Выделенный узел";
            else
                MessageBox.Show("Необходимо выделить узел");
        }
       
    }
}
