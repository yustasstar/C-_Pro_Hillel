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
    public partial class Form2 : Form
    {
        public Form1 MainForm { get; set; }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.ChildForm = null;
        }
    }
}
