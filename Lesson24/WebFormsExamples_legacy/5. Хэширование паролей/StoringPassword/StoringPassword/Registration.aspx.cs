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
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SqlConnection connect = new SqlConnection();
                SqlCommand command = new SqlCommand();
                try
                {
                    byte[] saltbuf = new byte[16];

                    // Реализует криптографический генератор случайных чисел, используя реализацию, предоставляемую поставщиком служб шифрования (CSP). 
                    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                    rng.GetBytes(saltbuf);

                    StringBuilder sb = new StringBuilder(16);
                    for (int i = 0; i < 16; i++)
                        sb.Append(string.Format("{0:X2}", saltbuf[i]));
                    string salt = sb.ToString();

                    // Формирует хэшированный пароль, подходящий для хранения в файле конфигурации, в зависимости от указанного пароля и алгоритма хэширования.
                    string hash = FormsAuthentication.HashPasswordForStoringInConfigFile(
                        salt + Password1.Text /* Пароль для хэширования */,
                        "MD5" /* Используемый хэш-алгоритм */);

                    connect.ConnectionString = ConfigurationManager.ConnectionStrings["UserConnectionString"].ToString();
                    connect.Open();
                    command.Connection = connect;
                    string query =
                        string.Format(
                            "INSERT INTO users (firstname, lastname, login, password, salt) VALUES ('{0}','{1}','{2}','{3}','{4}')",
                            FirstName.Text, LastName.Text, Login.Text, hash, salt);
                    command.CommandText = query;
                    int n = command.ExecuteNonQuery();
                    if (n == 1)
                        Response.Redirect("Default.aspx");
                }
                catch (Exception ex)
                {
                    info.Text = ex.Message;
                }
                finally
                {
                    command.Dispose();
                    connect.Close();
                }
            }
        }
    }
}