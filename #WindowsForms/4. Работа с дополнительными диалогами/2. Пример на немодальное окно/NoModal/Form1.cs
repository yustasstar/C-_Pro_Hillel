using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NoModal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Form2 ChildForm { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ChildForm != null)
            {
                ChildForm.Activate();
                return;
            }
            ChildForm = new Form2();
            ChildForm.MainForm = this;
            ChildForm.Show();
        }
    }
}
