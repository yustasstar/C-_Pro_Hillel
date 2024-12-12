using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoringPassword
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LastName"] != null && Session["FirstName"] != null)
            {
                header.InnerText = "Здравствуйте, " + Session["FirstName"].ToString() + "  " + Session["LastName"].ToString() + "!";
            }
            else
                Response.Redirect("Default.aspx");
        }
    }
}