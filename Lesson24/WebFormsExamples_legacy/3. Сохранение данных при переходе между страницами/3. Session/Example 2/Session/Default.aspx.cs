using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Session
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Label3.Visible = false;
                Panel1.Visible = true;
            }
            else
            {
                Label3.Visible = true;
                Panel1.Visible = false;
            }
        }

        protected void Vhod(object sender, EventArgs e)
        {
            Session["login"] = login.Text;
            Session.Timeout = 10; // Длительность сеанса (тайм-аут завершения сеанса)
            Response.Redirect("WebForm1.aspx");
        }
    }
}