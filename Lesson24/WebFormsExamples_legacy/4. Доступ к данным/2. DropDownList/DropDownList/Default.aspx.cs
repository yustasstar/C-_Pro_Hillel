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
using System.Data.SqlClient;

namespace DropDownList
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             IsPostBack
             Получает значение, указывающее, загружается ли страница в ответ на обратный запрос клиента, 
             или же загрузка страницы и доступ к ней осуществляется в первый раз.
             true, если страница загружается в ответ на обратный запрос клиента; иначе — false.
            */

            if (!IsPostBack)
            {
                 SqlConnection conn = null;
                 try
                 {
                     conn = new SqlConnection(@"server=(localdb)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Database_Books.mdf;integrated security=true");
                     conn.Open();

                     SqlCommand cmd = new SqlCommand();
                     cmd.Connection = conn;

                     // заполнение элемента DropDownList 
                     // 1) выполнение запроса на выборку издательств книг
                     cmd.CommandText = "select id, press from books";
                     SqlDataReader dr = cmd.ExecuteReader();

                     // 2) указываем источник данных
                     ddl_press.DataSource = dr;

                     // 3) указываем какое поле будет попадать в Value, а какое в Text
                     ddl_press.DataValueField = "id"; // значение элемента списка
                     ddl_press.DataTextField = "Press"; // текстовое содержимое элемента списка

                     // 4) производим связывание
                     ddl_press.DataBind();

                     dr.Close();

                     // 1) выполнение запроса на выборку названий книг
                     cmd.CommandText = "select id, Name from books";
                     dr = cmd.ExecuteReader();

                     // 2) указываем источник данных
                     ddl_name.DataSource = dr;

                     // 3) указываем какое поле будет попадать в Value, а какое в Text
                     ddl_name.DataValueField = "id"; // значение элемента списка
                     ddl_name.DataTextField = "Name"; // текстовое содержимое элемента списка

                     // 4) производим связывание
                     ddl_name.DataBind();

                     dr.Close();
                 }
                 catch (Exception ex)
                 {

                 }
                 finally
                 {
                     conn.Close();
                 }
            }
        }
    }
}
