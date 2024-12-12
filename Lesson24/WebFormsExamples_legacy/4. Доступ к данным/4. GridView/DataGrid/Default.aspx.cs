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

namespace DataGrid
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
                SqlCommand cmd = new SqlCommand("select Name as book_name, author as book_author, Press as book_izd from books", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
                dr.Close();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }
    }
}
