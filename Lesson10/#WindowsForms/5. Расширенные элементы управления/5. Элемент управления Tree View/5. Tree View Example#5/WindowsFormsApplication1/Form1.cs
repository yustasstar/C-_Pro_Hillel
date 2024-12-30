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
        TreeView treeView1;
        ImageList imageList;

        public Form1()
        {
            InitializeComponent();
            // создаём объект "дерево просмотра"
            treeView1 = new TreeView();

            // "Заморозим" изменение элементов управления
            this.SuspendLayout();

             // Создаем список изображений
            imageList = new ImageList();

            // Инициализируем списки изображений картинками
            imageList.Images.Add(Bitmap.FromFile("1.bmp"));
            imageList.Images.Add(Bitmap.FromFile("2.bmp"));
            imageList.Images.Add(Bitmap.FromFile("3.bmp"));
            imageList.Images.Add(Bitmap.FromFile("4.bmp"));

            // установим местоположение дерева
            treeView1.Location = new Point(0, 0);
            // Зададим размеры дерева
            treeView1.Size = new Size(292, 248);
            // При изменении размеров формы автоматически будет изменяться размер дерева
            treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;

            // ассоциируем список изображений с TreeView
            treeView1.ImageList = imageList;

            // зададим высоту каждого узла дерева в элементе управления иерархического представления
            treeView1.ItemHeight = 20;
            // Добавляем узлы в дерево
            TreeNode node, child;
            for (int x = 0; x < 3; ++x)
            {
                // Добавляем корневой узел
                node = new TreeNode();
                node.ImageIndex = 0;
				node.SelectedImageIndex = 0;
                node.Text = String.Format("Node{0}", x * 4);
                treeView1.Nodes.Add(node);
                for (int y = 1; y < 4; ++y)
                {
                    // Добавляем дочерние узлы 
                    child = new TreeNode();
                    child.ImageIndex = y;
                    child.SelectedImageIndex = y;
                    child.Text = String.Format("Node{0}", x * 4 + y);
                    node.Nodes.Add(child);
                }
            }

            // Инициализация формы
            this.ClientSize = new Size(292, 273);

            // Добавление элементов управления в коллекцию Controls
            this.Controls.Add(treeView1);
            // Настройки для всех элементов формы одновременно вступают в силу
            this.ResumeLayout(false);

        }

    }
}
