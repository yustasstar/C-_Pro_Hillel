using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Application["FirstName"] != null && Application["LastName"] != null)
                {
                    oldinfo.Text = Application["FirstName"].ToString() + " " + Application["LastName"].ToString();
                }
            }
            else
            {
                Application["FirstName"] = null;
                Application["LastName"] = null;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FirstName.Text.Length > 0 && LastName.Text.Length > 0)
            {
                Application["FirstName"] = FirstName.Text;
                Application["LastName"] = LastName.Text;
            }
            info.Text = FirstName.Text + " " + LastName.Text;
        }
    }
}