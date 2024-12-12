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

namespace CalendarControl
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                TextToUser.Text = "Вы поедете " + calVoyage.SelectedDate.ToLongDateString();
            }
        }

        protected void calSelectChange(object sender, EventArgs e)
        {
            if (calVoyage.SelectedDate > DateTime.Today)
            {
                TextToUser.Text = "Вы действительно хотите отправиться в путешествие " + calVoyage.SelectedDate.ToShortDateString() + "?";
                Button ok = new Button();
                ok.Width = 100;
                ok.Text = "Да";
                form1.Controls.Add(ok);
            }
            else
                TextToUser.Text = "Выберите будущую дату";
        }
    }
}
