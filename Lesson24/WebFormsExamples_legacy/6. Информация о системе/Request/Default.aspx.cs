using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Request
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ip_address.Text = Request.UserHostAddress;
            dns.Text = Request.UserHostName;
            virtualpath.Text = Request.ApplicationPath;
            machine.Text = System.Environment.MachineName;
            os.Text = System.Environment.OSVersion.ToString();
            memory.Text = System.Environment.WorkingSet.ToString();
            machinename.Text = HttpContext.Current.Server.MachineName;
            localip.Text = HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"];
        }

        public void GetDateTime()
        {
            Response.Write("Текущие дата и время: " + DateTime.Now.ToString());
        }

    }
}
