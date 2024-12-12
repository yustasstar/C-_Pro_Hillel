using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace DynamicCreateControls
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OK"] != null)
            {
                TextBox txt = new TextBox();
                txt.ID = "txt1";
                txt.Text = "Hello!";
                PlaceHolder1.Controls.Add(txt);
                Button btn = new Button();
                btn.Text = "Click Me";
                btn.ID = "btn1";
                btn.Click += new EventHandler(btn_Click);
                PlaceHolder1.Controls.Add(btn);
                Label label = new Label();
                label.ID = "label1";
                PlaceHolder1.Controls.Add(label);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["OK"] = 1;
            Response.Redirect("Default.aspx");
        }

        void btn_Click(object sender, EventArgs e)
        {
            Label l = (Label)PlaceHolder1.FindControl("label1");
            TextBox txt = (TextBox)PlaceHolder1.FindControl("txt1");
            l.Text = txt.Text;
        }
    }
}
