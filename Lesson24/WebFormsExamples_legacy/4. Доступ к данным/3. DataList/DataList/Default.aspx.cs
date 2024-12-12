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

namespace DataList
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(@"server=(localdb)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Database_Books.mdf;integrated security=true");
                conn.Open();
                // 1) выполнение запроса на выборку
                SqlCommand cmd = new SqlCommand("select name, author, press from books", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                // 2) указываем источник данных
                DataList1.DataSource = dr;
                // 3) для форматирования 5-й записи будет использоваться шаблон выбранного элемента
                DataList1.SelectedIndex = 5;
                // 4) производим связывание
                DataList1.DataBind();
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
