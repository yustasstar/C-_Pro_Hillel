using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace MyStyle
{
    public partial class _Default : System.Web.UI.Page
    {
        private Style primaryStyle = new Style();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                primaryStyle.BorderColor = Color.FromName("Red");
                primaryStyle.BackColor = Color.FromName("Green");
                primaryStyle.ForeColor = Color.FromName("Yellow");
                primaryStyle.BorderStyle = BorderStyle.Dotted;
                primaryStyle.BorderWidth = 3;
                primaryStyle.Font.Name = "Courier";
                primaryStyle.Font.Size = 15;

                //Устанавливаем стили primaryStyle для каждого элемента управления.
                Label1.ApplyStyle(primaryStyle);
                ListBox1.ApplyStyle(primaryStyle);
                Button1.ApplyStyle(primaryStyle);
                Table1.ApplyStyle(primaryStyle);
                TextBox1.ApplyStyle(primaryStyle);
            }
        }
    }
}
