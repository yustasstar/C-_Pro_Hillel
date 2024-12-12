using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DropdownList
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*
         *  Cобытия ASP.NET бывают двух типов:
        • События, требующие немедленного ответа. К числу таких событий относится 
        щелчок на кнопке отправки формы (Submit) или на какой-то другой кнопке,  
        области изображения или ссылке в многофункциональном веб-элементе управления, 
        который инициирует обратную отправку данных вызовом JavaScript-функции 
        doPostBack() . 
        • События изменения. К числу таких событий относится изменение выбора в  
        элементе управления или текста в текстовом поле. Эти события запускаются для  
        веб-элементов управления немедленно, если свойство AutoPostBack установлено в 
        true. В противном случае они запускаются при следующей обратной отправке 
        страницы. 
        */


        protected void Button1_Click(object sender, EventArgs e)
        {
            ColorText.Text += "<br>Button!";
        }
        protected void Selection_Change(object sender, EventArgs e)
        {
            // Устанавливает цвет шрифта в элементе управления Label, 
            //в зависимости от того, что выбрано в элементе управления DropDownList
            ColorText.ForeColor = System.Drawing.Color.FromName(ColorList.SelectedItem.Value);
            ColorText.Text += "<br>ComboBox!";
        }

    }
}
