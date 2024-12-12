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

namespace Collection_Databind
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList ContinentArrayList = new ArrayList();
            ContinentArrayList.Add("Европа");
            ContinentArrayList.Add("Америка");
            ContinentArrayList.Add("Африка");
            ContinentArrayList.Insert(1, "Азия");
            GridView1.DataSource = ContinentArrayList;
            GridView1.DataBind();
            ContinentDropDownList.DataSource = ContinentArrayList;
            ContinentDropDownList.DataBind();
        }
    }
}
