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

namespace CheckBoxList
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Check_Clicked(object sender, EventArgs e)
        {
            Message.Text = "Selected Item(s):<br /><br />";
            // Пробегаем по коллекции Items элемента управления CheckBoxList 
            // и отображаем выбранные элементы.
            for (int i = 0; i < checkboxlist1.Items.Count; i++)
            {
                if (checkboxlist1.Items[i].Selected)
                {
                    Message.Text += checkboxlist1.Items[i].Text + "<br />";
                }
            }
        }
    }
}
