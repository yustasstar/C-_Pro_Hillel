using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioButtonControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = null;
            if (radioButton1.Checked)
                str += "RadioButton#1   ";
            if (radioButton2.Checked)
                str += "RadioButton#2   ";
            if (radioButton3.Checked)
                str += "RadioButton#3   ";
            if (radioButton4.Checked)
                str += "RadioButton#4   ";
            if (radioButton5.Checked)
                str += "RadioButton#5   ";
            if (radioButton6.Checked)
                str += "RadioButton#6   ";
            MessageBox.Show(str, "RadioButton", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radioButton_Click(object sender, EventArgs e)
        {
            RadioButton r = (RadioButton)sender;
            Text = r.Text;
        }
    }
}
