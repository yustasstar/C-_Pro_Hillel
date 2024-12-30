using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace PictureBoxControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Type t = this.GetType();
                Bitmap pic1 = new Bitmap(t, "p_cat2s.jpg"); // Свойство Build Action : Embedded Resource
                Cursor cur = new Cursor(t, "cursor1.cur"); // Свойство Build Action : Embedded Resource
                this.button1.BackgroundImage = pic1;
                this.pictureBox1.BackgroundImage = Properties.Resources.s109; // Project Properties -> Resources
                this.Cursor = cur;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer("../../sound.wav");
            // player.SoundLocation = "../../sound.wav";
            player.Play();
            // player.PlayLooping();
        }
    }
}
