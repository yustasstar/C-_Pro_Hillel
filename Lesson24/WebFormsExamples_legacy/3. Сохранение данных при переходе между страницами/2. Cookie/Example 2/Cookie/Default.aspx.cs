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
using System.Text;

namespace Cookie
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie name = Request.Cookies["name"];
            if (name != null)
            {
                string str = Request.Cookies["name"].Value;

                // Преобразует заданную строку, представляющую двоичные данные в виде 
                // цифр в кодировке Base64, в эквивалентный массив 8-разрядных целых чисел без знака.
                byte[] def = Convert.FromBase64String(str);
                str = Encoding.Default.GetString(def);

                Label1.Text = str;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = TextBox1.Text;

            byte[] def = Encoding.Default.GetBytes(str);
            // Преобразует массив 8-разрядных целых чисел без знака в эквивалентное строковое 
            // представление, состоящее из цифр в кодировке Base64.
            str = Convert.ToBase64String(def); 
          
            HttpCookie cookie = new HttpCookie("name", str);
            cookie.Expires = new DateTime(2019, 12, 31);
            Response.Cookies.Add(cookie);
            Response.Redirect("Default.aspx");
        }
    }
}
