using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        private void RBClick(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Нажата правая кнопка');</script>");
        }
        private void LBClick(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Нажата левая кнопка');</script>");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            myUserControl.RightButtonClick += new EventHandler(RBClick);
            myUserControl.LeftButtonClick += new EventHandler(LBClick);
        }
    }
}