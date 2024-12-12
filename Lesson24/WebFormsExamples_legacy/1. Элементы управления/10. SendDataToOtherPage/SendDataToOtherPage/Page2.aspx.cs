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

namespace SendDataToOtherPage
{
    public partial class Page2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.PreviousPage != null)
            {
                TextBox pp_Textbox1;
                Calendar pp_Calendar1;
                pp_Textbox1 = PreviousPage.FindControl("Textbox1") as TextBox;
                pp_Calendar1 = PreviousPage.FindControl("Calendar1") as Calendar;
                Label1.Text = "Здравствуйте, " + pp_Textbox1.Text + "!<br />" + "Вы выбрали: " + pp_Calendar1.SelectedDate.ToShortDateString();
            }

        }
    }
}
