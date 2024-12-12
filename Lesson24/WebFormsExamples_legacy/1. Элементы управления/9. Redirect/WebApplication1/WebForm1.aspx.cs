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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // UrlReferrer получает сведения об URL-адресе предыдущего запроса клиента, связанного с текущим URL-адресом.
            if (Request.UrlReferrer != null)
            {
                // Request.QueryString получает коллекцию переменных строки запроса HTTP.
                Response.Write("Имя: "+ Request.QueryString.Get("name"));
                Response.Write("\nФамилия: " + Request.QueryString.Get("surname"));
            }
            else
            {
                /*
			    Загрузка страницы выполняется в результате набора ее адреса в браузере или перехода на страницу с другой
			    страницы, в том числе программным способом, например, в результате выполнения Response.Redirect( )
                По умолчанию, несмотря на то, что Redirect () перенаправляет пользователя и закрывает соединение, любой 
                оставшийся код в методе по-прежнему будет выполняться вместе с остальными событиями страницы. 
                Это позволяет при  необходимости провести очистку. 
                Если во втором параметре передается значение true, ASP.NET немедленно прекратит обработку страницы, что 
                потенциально сокращает рабочую нагрузку веб-сервера. 
			    */
                Response.Redirect("Default.aspx", true);
            }
        }
    }
}
