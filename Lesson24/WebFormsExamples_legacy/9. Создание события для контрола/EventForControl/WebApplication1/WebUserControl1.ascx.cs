using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        public event EventHandler RightButtonClick;
        public event EventHandler LeftButtonClick;

        protected void Button1_Click(object sender, EventArgs e)
        {
            LeftButtonClick(sender, e);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            RightButtonClick(sender, e);
        }
    }
}