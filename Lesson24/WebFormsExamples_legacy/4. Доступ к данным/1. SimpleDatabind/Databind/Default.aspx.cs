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

// Выражение привязки данных в ASP.NET помещается в ограничительные скобки <%#...%>
namespace Databind
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected SqlDataReader books;

        public void SelectData(object sender, System.EventArgs e)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(@"server=(localdb)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Database_Books.mdf;integrated security=true");
                conn.Open();

                SqlCommand cmd = new SqlCommand("select * from books where id=" + txtNum.Text, conn);
                books = cmd.ExecuteReader();

                if (!books.Read())
                    lblError.Text = "Ошибка: нет записи с данным ID!";
                else
                {
                    lblError.Text = "";
                    this.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateData(object sender, System.EventArgs e)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(@"server=(localdb)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Database_Books.mdf;integrated security=true");
                conn.Open();

                SqlCommand cmd = new SqlCommand("update books set Name='" + txtName.Text + "', Author='" + txtAuthor.Text +
                    "', Press='" + txtPub.Text + "', YearPress=" + txtPubYear.Text + " where id=" + txtNum.Text, conn);
                cmd.ExecuteNonQuery();
                lblError.Text = "Запись успешно изменена!";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
