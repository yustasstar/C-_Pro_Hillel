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
            if (IsPostBack)
            {
                if (Session["FirstName"] != null && Session["LastName"] != null)
                {
                    oldinfo.Text = Session["FirstName"].ToString() + " " + Session["LastName"].ToString();
                }
            }
            //else
            //    Session.Abandon();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FirstName.Text.Length > 0 && LastName.Text.Length > 0)
            {
                Session["FirstName"] = FirstName.Text;
                Session["LastName"] = LastName.Text;
            }
            info.Text = FirstName.Text + " " + LastName.Text;
        }
    }
}