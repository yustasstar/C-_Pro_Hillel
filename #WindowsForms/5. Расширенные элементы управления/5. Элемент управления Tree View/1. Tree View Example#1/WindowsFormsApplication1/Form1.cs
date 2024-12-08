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
        private Button showCheckedNodesButton;
        // Событийный делегат TreeViewCancelEventHandler - описывает метод, обрабатывающий следующие события:
        // BeforeSelect - происходит перед выбором узла дерева.
        // BeforeCollapse - происходит перед свертыванием узла дерева.
        // BeforeExpand - происходит перед развертыванием узла дерева.
        // BeforeCheck - происходит перед установкой флажка для узла дерева.

        private TreeViewCancelEventHandler checkForCheckedChildren;
        
        public Form1()
        {
            InitializeComponent();
            // создаём объект "дерево просмотра"
            treeView1 = new TreeView();
            showCheckedNodesButton = new Button();

            // Для события BeforeCollapse создадим обработчик
            checkForCheckedChildren = new TreeViewCancelEventHandler(CheckForCheckedChildrenHandler);

            // "Заморозим" изменение элементов управления
            this.SuspendLayout();

            // установим местоположение дерева
            treeView1.Location = new Point(0, 25);
            // Зададим размеры дерева
            treeView1.Size = new Size(292, 248);
            // При изменении размеров формы автоматически будет изменяться размер дерева
            treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            // Наличие флажка около каждого узла дерева
            treeView1.CheckBoxes = true;

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

            // Для одного из узлов дерева установим флажок
            treeView1.Nodes[1].Nodes[0].Nodes[0].Checked = true;

            // Зададим настройки для кнопки
            showCheckedNodesButton.Size = new Size(144, 24); // размер кнопки
            showCheckedNodesButton.Text = "Показать отмеченные узлы"; // надпись на кнопке
            showCheckedNodesButton.Click += new EventHandler(showCheckedNodesButton_Click); // обработчик события Click

            // Инициализация формы
            this.ClientSize = new Size(292, 273);

            // Добавление элементов управления в коллекцию Controls
            this.Controls.AddRange(new Control[] { showCheckedNodesButton, treeView1 });
            // Настройки для всех элементов формы одновременно вступают в силу
            this.ResumeLayout(false);

        }

        // обработчик нажатия на кнопку
        private void showCheckedNodesButton_Click(object sender, EventArgs e)
        {
            // Отключаем любую перерисовку иерархического представления
            treeView1.BeginUpdate();

            // Развертываем все узлы дерева
            treeView1.ExpandAll();

            // добавляем обработчик события сворачивания узла
            treeView1.BeforeCollapse += checkForCheckedChildren;

            // Сворачиваем все узелы дерева - будет вызван обработчик CheckForCheckedChildrenHandler
            treeView1.CollapseAll();

            // удаляем обработчик события сворачивания узла, чтобы разрешить обычное свертывание узла, 
            // когда пользователь щелкает знак "минус" рядом с узлом.
            treeView1.BeforeCollapse -= checkForCheckedChildren;

            // Разрешаем перерисовку иерархического представления.
            treeView1.EndUpdate();
        }

        // В данном случае обработчик события BeforeCollapse сработает только при программном сворачивании узлов
        private void CheckForCheckedChildrenHandler(object sender, TreeViewCancelEventArgs e)
        {
            // проверим узел, который сворачивается, на наличие дочерних отмеченных узлов
            if (HasCheckedChildNodes(e.Node)) 
                e.Cancel = true; // отменим сворачивание узла, если тот имеет отмеченные дочерние узлы
        }

        // Определим, имеет ли узел дочерние отмеченные узлы
        private bool HasCheckedChildNodes(TreeNode node)
        {
            if (node.Nodes.Count == 0) // если узел не имеет дочерних узлов, то вернём ложь
                return false;
            // для проверяемого узла просмотрим всю коллекцию дочерних узлов
            foreach (TreeNode childNode in node.Nodes)
            {
                if (childNode.Checked) 
                    return true; // если дочерний узел отмечен, то вернём истину
                // Дочерний узел также необходимо проверить на наличие отмеченных дочерних узлов - вызываем эту же функцию рекурсивно
                if (HasCheckedChildNodes(childNode)) 
                    return true;
            }
            return false; // если нет отмеченных дочерних узлов, то вернём ложь
        }

    }
}
