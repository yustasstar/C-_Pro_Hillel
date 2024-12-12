using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace StoringPassword
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                connect.ConnectionString = ConfigurationManager.ConnectionStrings["UserConnectionString"].ToString();
                connect.Open();
                cmd.Connection = connect;
                string query = string.Format("select * from users where login = '{0}'", login.Text);
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    info.Text = "Неверный логин!";
                    return;
                }
                string salt = reader["salt"].ToString();

                // Формирует хэшированный пароль, подходящий для хранения в файле конфигурации, 
                // в зависимости от указанного пароля и алгоритма хэширования.
                string hash = FormsAuthentication.HashPasswordForStoringInConfigFile(
                    salt + password.Text /* Пароль для хэширования */,
                    "MD5" /* Используемый хэш-алгоритм */);

                string pass = reader["password"].ToString();
                if (pass != hash)
                {
                    info.Text = "Неверный пароль!";
                    return;
                }
                Session["FirstName"] = reader["firstname"].ToString();
                Session["LastName"] = reader["lastname"].ToString();
                Response.Redirect("HomePage.aspx");
            }
            catch (Exception ex)
            {
                info.Text = ex.Message;
            }
            finally
            {
                cmd.Dispose();
                connect.Close();
            }
        }
    }
}