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
        /*
         *          В случае создания веб-страницы с одним 
                или более веб-элементами управления, для которых настраивается AutoPostBack, 
                ASP.NET добавляет в визуализируемую HTML-страницу JavaScript-функцию по имени 
                doPostBack (). При вызове эта функция инициирует обратную отправку, отправляя 
                страницу обратно веб-серверу со всеми данными формы. 
                Помимо этого, ASP.NET также добавляет два скрытых поля ввода, которые функция 
                doPostBack () использует для передачи обратно серверу определенной информации. 
                Этой информацией является идентификатор элемента управления, который  
                инициировал событие, и другие значимые сведения. 
         * */

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                this.Title = TextBox1.Text;
            }
        }
    }
}
