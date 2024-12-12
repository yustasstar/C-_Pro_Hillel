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

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox3.Text = DateTime.Now.ToLongTimeString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Text = DateTime.Now.ToLongTimeString();
            TextBox2.Text = DateTime.Now.ToLongTimeString();
            TextBox3.Text = DateTime.Now.ToLongTimeString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox2.Text = DateTime.Now.ToLongTimeString();
            TextBox1.Text = DateTime.Now.ToLongTimeString(); // обновления Panel1 не будет
            TextBox3.Text = DateTime.Now.ToLongTimeString();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            TextBox1.Text = DateTime.Now.ToLongTimeString();
            TextBox2.Text = DateTime.Now.ToLongTimeString();
        }

      
    }
}
