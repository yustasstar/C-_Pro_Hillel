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

namespace RangeValidator
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*
        Свойства:
        ControlToValidate – Содержит идентификатор элемента управления, 
	        данные которого необходимо проверить.
        Display – Устанавливает, как будет выводиться сообщение об ошибке, 
	        содержащиеся в свойстве Text. Возможные значения: Static (по 
	        умолчанию), Dynamic и None.
        EnabledClientScript – Разрешает или запрещает клиентскую проверку 
	        корректности данных. По умолчанию используется true.
        Enabled – Разрешает или запрещает клиентскую и серверную проверки 
	        корректности данных. По умолчанию используется true.
        ErrorMessage – Содержит сообщение об ошибке, которое выводится в 
	        элементе управления ValidationSummary, если свойство Text не 
	        установлено.
        IsValid – Содержит значение true, если проверка корректности 
	        данных прошла успешно, и false – в противном случае.
        MinimumValue – Минимальное значение диапазона допустимых значений.
        MaximumValue – Максимальное значение диапазона допустимых значений.
        Text – Устанавливает сообщение об ошибке, выводимое в элементе управления.
        Type – Определяет тип данных, используемый при проведении проверки 
	        сравнения значений. Возможные значения: Currency, Date, Double, 
	        Integer и String.
        	
        Методы:
        Validate – Выполняет проверку корректности данных и обновляет значение 
	        свойства IsValid.
        */

        protected void AddButton_Click(Object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int Answer;
                Answer = Convert.ToInt32(Value1.Text) + Convert.ToInt32(Value2.Text);
                AnswerMessage.Text = Answer.ToString();
            }
        }
    }
}
