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

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void HandlerClick(object sender, EventArgs e)
        {
            /*
			Загрузка страницы выполняется в результате набора
			ее адреса в браузере или перехода на страницу с другой
			страницы, в том числе программным способом, например
			в результате выполнения Response.Redirect( )
			*/
            Response.Redirect("WebForm1.aspx?name=" + Name.Value + "&surname=" + Surname.Value);
        }
          
    }
}
