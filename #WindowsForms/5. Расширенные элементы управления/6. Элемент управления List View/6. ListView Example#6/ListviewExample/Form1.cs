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
        ListView findListView = new ListView();
        Button findButton = new Button();
        TextBox edit = new TextBox();
        public Form1()
        {
            InitializeComponent();
            edit.Location = new Point(150, 20);
            edit.Text = "Швеция";
            // Set up the location and event handling for the button.
            findButton.Click += new EventHandler(findButton_Click);
            findButton.Location = new Point(150, 50);
            findButton.Text = "Найти";
            // Set up the location of the ListView and add some items.
            findListView.Location = new Point(10, 20);
            findListView.Items.Add(new ListViewItem("Украина"));
            findListView.Items.Add(new ListViewItem("Италия"));
            findListView.Items.Add(new ListViewItem("Россия"));
            findListView.Items.Add(new ListViewItem("Швеция"));
            findListView.Items.Add(new ListViewItem("Испания"));
            findListView.View = View.List;
            // Add the button and ListView to the form.
            this.Controls.Add(findButton);
            this.Controls.Add(findListView);
            this.Controls.Add(edit);
            Width = 300;
            Height = 200;
        }

        void findButton_Click(object sender, EventArgs e)
        {
            // Call FindItemWithText, sending output to MessageBox.
            ListViewItem item1 = findListView.FindItemWithText(edit.Text);
            if (item1 != null)
                MessageBox.Show(item1.ToString());
            else
                MessageBox.Show("По данному запросу ничего не найдено!");
        }

    }
}
