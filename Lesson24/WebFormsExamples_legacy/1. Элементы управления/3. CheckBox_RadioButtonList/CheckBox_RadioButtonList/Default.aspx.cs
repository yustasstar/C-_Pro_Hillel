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

namespace CheckBox_RadioButtonList
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void chkDirection_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDirection.Checked)
            {
                RadioButtonList1.RepeatDirection = RepeatDirection.Horizontal;
                chkDirection.Text = "Отобразить вертикально";
            }
            else
            {
                RadioButtonList1.RepeatDirection = RepeatDirection.Vertical;
                chkDirection.Text = "Отобразить горизонтально";
            }  
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList list = (RadioButtonList)sender;
            Label1.Text = "Вы выбрали: " + list.SelectedItem.Text;
        }
    }
}
