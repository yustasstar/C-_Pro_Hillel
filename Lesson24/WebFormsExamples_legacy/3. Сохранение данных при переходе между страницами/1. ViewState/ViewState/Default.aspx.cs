using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewState
{
    public partial class Default : System.Web.UI.Page
    {
     
        protected void Button1_Click(object sender, EventArgs e)
        {
         if (ViewState["oldinfo"] != null)
            {
                oldinfo.Text = (string)ViewState["oldinfo"];
            }
            info.Text = FirstName.Text + " " + LastName.Text;
            ViewState["oldinfo"] = info.Text;
        }

    }
}