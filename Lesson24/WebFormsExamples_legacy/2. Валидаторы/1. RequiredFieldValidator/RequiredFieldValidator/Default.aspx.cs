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

namespace RequiredFieldValidator
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                this.Title = "PostBack";
        }

        /*
        Свойства:
        ControlToValidate – Содержит идентификатор элемента управления, данные 
	        которого необходимо проверить.
        Display – Устанавливает, как будет выводиться сообщение об ошибке, 
	        содержащиеся в свойстве Text. Возможные значения: Static (по 
	        умолчанию), Dynamic и None.
        EnabledClientScript – Разрешает или запрещает клиентскую проверку 
	        корректности данных. По умолчанию используется true.
        Enabled – Разрешает или запрещает клиентскую и серверную проверки 
	        корректности данных. По умолчанию используется true.
        ErrorMessage – Содержит сообщение об ошибке, которое выводится в 
	        элементе управления ValidationSummary, если свойство Text не установлено.
        InitialValue – Определяет начальное значение элемента управления, 
	        указанного свойством ControlToValidate.
        IsValid – Содержит значение true, если проверка корректности данных 
	        прошла успешно, и false – в противном случае.
        Text – Устанавливает сообщение об ошибке, выводимое в элементе управления.

        Методы:
        Validate – Выполняет проверку корректности данных и обновляет значение 
	        свойства IsValid.
        */

        public void ValidateBtn_Click(Object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                lblOutput.Text = "Необходимое поле заполнено!";
            }
            else
            {
                lblOutput.Text = "Необходимое поле пусто!";
            }
        }
    }
}
