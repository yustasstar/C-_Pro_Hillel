using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CreateToolBar
{
    public partial class Form1 : Form
    {
        ToolBar tBar;
        ImageList list;
        public Form1()
        {
            InitializeComponent();
            list = new ImageList();
            list.ImageSize = new Size(32, 32);
            list.Images.Add(new Bitmap("Open.png"));
            list.Images.Add(new Bitmap("Save.png"));
            list.Images.Add(new Bitmap("Exit.png"));

            tBar = new ToolBar();
                        
            tBar.ImageList = list; //привяжем список картинок к тулбару
            ToolBarButton toolBarButton1 = new ToolBarButton();
            ToolBarButton toolBarButton2 = new ToolBarButton();
            ToolBarButton toolBarButton3 = new ToolBarButton();
            ToolBarButton separator = new ToolBarButton();
            separator.Style = ToolBarButtonStyle.Separator;

            toolBarButton1.ImageIndex = 0; //Open
            toolBarButton2.ImageIndex = 1; // Save
            toolBarButton3.ImageIndex = 2; //Exit

            tBar.Buttons.Add(toolBarButton1);
            tBar.Buttons.Add(separator);
            tBar.Buttons.Add(toolBarButton2);
            tBar.Buttons.Add(separator);
            tBar.Buttons.Add(toolBarButton3);

            tBar.Appearance = ToolBarAppearance.Flat;
            tBar.BorderStyle = BorderStyle.Fixed3D;
            tBar.ButtonClick += new ToolBarButtonClickEventHandler(tBar_ButtonClick); 
            
            this.Controls.Add(tBar);
            
        }

        void tBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            try
            {
                OpenFileDialog f1;
                SaveFileDialog f2;
                switch (e.Button.ImageIndex)
                {
                    case 0:

                        f1 = new OpenFileDialog();
                        if (f1.ShowDialog() == DialogResult.OK)
                        {
                            StreamReader r = new StreamReader(f1.FileName, Encoding.Default);
                            textBox1.Text = r.ReadToEnd();
                            r.Close();
                        }
                        break;
                    case 1:
                        f2 = new SaveFileDialog();
                        if (f2.ShowDialog() == DialogResult.OK)
                        {
                            StreamWriter w = new StreamWriter(f2.FileName);
                            w.WriteLine(textBox1.Text);
                            w.Close();
                        }
                        break;
                    case 2:
                        Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
