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

namespace Application__counter_
{
    // HttpApplicationState позволяет обмен общими сведениями между несколькими сеансами и запросами в приложении ASP.NET.
    public partial class _Default : System.Web.UI.Page
    {
        /* 
            В примере используются метод Lock и метод UnLock для предотвращения изменения значения переменной 
            приложения в других сеансах до тех пор, пока они не будут изменены в течение текущего сеанса
            Объект Application хранит состояние приложения.
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            // Блокирует доступ к переменной HttpApplicationState для упрощения синхронизации доступа
            Application.Lock();
            if (Application["count"] == null)
                // Добавление нового объекта в коллекцию HttpApplicationState
                Application["count"] = 1;
            else
                Application["count"] = (int)Application["count"] + 1;
            // Разблокирует доступ к переменной HttpApplicationState для упрощения синхронизации доступа
            Application.UnLock();
            Label1.Text = "Количество посещений: " + Application["count"].ToString();
        }
    }
}
