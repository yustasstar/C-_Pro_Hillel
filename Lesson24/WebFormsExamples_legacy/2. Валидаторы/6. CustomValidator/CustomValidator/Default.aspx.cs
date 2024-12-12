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

namespace CustomValidator
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*
        Свойства:
        ClientValidationFunction – Содержит имя функции клиентской 
	        проверки корректности данных.
        ControlToValidate – Содержит идентификатор элемента управления, 
	        данные которого необходимо проверить.
        Display – Устанавливает, как будет выводиться сообщение об 
	        ошибке, содержащиеся в свойстве Text. Возможные значения: 
	        Static (по умолчанию), Dynamic и None.
        EnabledClientScript – Разрешает или запрещает клиентскую 
	        проверку корректности данных. По умолчанию используется true.
        Enabled – Разрешает или запрещает клиентскую и серверную проверки 
	        корректности данных. По умолчанию используется true.
        ErrorMessage – Содержит сообщение об ошибке, которое выводится в 
	        элементе управления ValidationSummary, если свойство Text 
	        не установлено.
        IsValid – Содержит значение true, если проверка корректности 
	        данных прошла успешно, и false – в противном случае.
        Text – Устанавливает сообщение об ошибке, выводимое в элементе 
	        управления.
        	
        Методы:
        OnServerValidate – Вызывает событие ServerValidate.
        Validate – Выполняет проверку корректности данных и обновляет 
	        значение свойства IsValid.
        	
        События:
        ServerValidate – Представляет функцию, выполняющую серверную проверку 
	        корректности данных. 

        */

        public void ValidateBtn_OnClick(object sender, EventArgs e)
        {
            // Отображает, прошла ли страница проверку.
            if (Page.IsValid)
            {
                Message.Text = "Page is valid.";
            }
            else
            {
                Message.Text = "Page is not valid!";
            }
        }
        public void ServerValidation(object source, ServerValidateEventArgs args)
        {
            try
            {
                // Проверяет введенное значение на четность.
                int i = int.Parse(args.Value);
                args.IsValid = ((i % 2) == 0);
            }
            catch (Exception ex)
            {
                args.IsValid = false;
            }
        }

    }
}
