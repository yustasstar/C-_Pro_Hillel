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

namespace BulletedList
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BulletedListLinks_Click(object sender, BulletedListEventArgs e)
        {
            switch (e.Index)
            {
                case 0: BulletedListLinks.BackColor =  System.Drawing.Color.LightCoral;
                    break;
                case 1: BulletedListLinks.BackColor =  System.Drawing.Color.Aqua;
                    break;
                case 2: BulletedListLinks.BackColor =  System.Drawing.Color.LightGreen;
                    break;
            }

        }
    }
}
