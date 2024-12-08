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
       
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            Form2 form2 = new Form2();
            AddOwnedForm(form2); // form2 является дочерним окном по отношению к form1
            form2.ShowInTaskbar = false;
            form2.Show();
        }
    }
}
