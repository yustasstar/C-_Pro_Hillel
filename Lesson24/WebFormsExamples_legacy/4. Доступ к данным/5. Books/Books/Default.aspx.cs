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

namespace Books
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection conn = null;
                try
                {
                    conn = new SqlConnection(@"server=(localdb)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\books.mdf;integrated security=true");
                    
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    // заполнение элемента DropDownList 
                    // 1) выполнение запроса на выборку категорий и создание DataReader-a
                    cmd.CommandText = "select distinct(Izd) from books";
                    SqlDataReader dr = cmd.ExecuteReader();
                    // 2) указываем источник данных
                    ddl_press.DataSource = dr;
                    // 3) указываем какое поле будет попадать в Value, а какое в Text
                   // ddl_press.DataValueField = "id";
                    ddl_press.DataTextField = "Izd";
                    // 4) производим связывание
                    ddl_press.DataBind();
                    dr.Close();
                    cmd.CommandText = "select distinct(Themes) from books";
                    dr = cmd.ExecuteReader();
                    ddl_themes.DataSource = dr;
                    // 3) указываем какое поле будет попадать в Value, а какое в Text
                   // ddl_themes.DataValueField = "id";
                    ddl_themes.DataTextField = "Themes";
                    // 4) производим связывание
                    ddl_themes.DataBind();
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

        public void ShowData(object sender, System.EventArgs e)
        {
             SqlConnection conn = null;
             try
             {
             conn = new SqlConnection(@"server=(localdb)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\books.mdf;integrated security=true");
                 conn.Open();
                 SqlCommand cmd = new SqlCommand();
                 cmd.Connection = conn;
                 string s1 = ddl_press.SelectedItem.Text;
                 string s2 = ddl_themes.SelectedItem.Text;
                 cmd.CommandText = "select * from books where Izd='" + s1 + "' and Themes='" + s2 + "'";
                 SqlDataReader dr = cmd.ExecuteReader();
                 GridView1.DataSource = dr;
                 GridView1.DataBind();
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
