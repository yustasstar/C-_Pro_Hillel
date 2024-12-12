using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cookie
{
    public partial class Default : System.Web.UI.Page
    {
         HttpCookie first = new HttpCookie("FirstName");
         HttpCookie last = new HttpCookie("LastName");
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Request.Cookies["FirstName"] != null && Request.Cookies["LastName"] != null)
                {
                    string str1 = Request.Cookies["FirstName"].Value;
                    string str2 = Request.Cookies["LastName"].Value;

                    byte[] b1 = Convert.FromBase64String(str1);
                    byte[] b2 = Convert.FromBase64String(str2);
                    str1 = Encoding.Default.GetString(b1);
                    str2 = Encoding.Default.GetString(b2);
                    oldinfo.Text = str1 + " " + str2;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FirstName.Text.Length > 0 && LastName.Text.Length > 0)
            {
                string str = FirstName.Text;
                byte[] def = Encoding.Default.GetBytes(str);
                // Преобразует массив 8-разрядных целых чисел без знака в эквивалентное строковое 
                // представление, состоящее из цифр в кодировке Base64.
                str = Convert.ToBase64String(def);
                first.Value = str;

                str = LastName.Text;
                def = Encoding.Default.GetBytes(str);
                str = Convert.ToBase64String(def);
                last.Value = str;

                Response.Cookies.Add(first);
                Response.Cookies.Add(last);
            }
            info.Text = FirstName.Text + " " + LastName.Text;
        }
    }
}