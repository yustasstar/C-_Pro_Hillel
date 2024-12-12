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

namespace CompareValidator
{
    public partial class _Default : System.Web.UI.Page
    {
        /*
            Свойства:
            ControlToValidate – Содержит идентификатор элемента управления, 
	            данные которого необходимо проверить.
            ControlToCompare	– Содержит идентификатор элемента управления, 
	            с данными которого будет происходить сравнение.
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
            IsValid – Содержит значение true, если проверка корректности данных 
	            прошла успешно, и false – в противном случае.
            Operator – Определяет оператор сравнения, используемый при проведении 
	            сравнений. Возможные значения: Equal, NotEqual, GreaterThan, 
	            GreaterThanEqual, LessThan, LessThanEqual, DataTypeCheck.
            Text – Устанавливает сообщение об ошибке, выводимое в элементе 
	            управления.
            Type – Определяет тип данных, используемый при проведении проверки 
	            сравнения значений. Возможные значения: Currency, Date, Double, 
	            Integer и String.
            ValueToCompare – Указывает значение, используемое для сравнения.

            Методы:
            Validate – Выполняет проверку корректности данных и обновляет 
	            значение свойства IsValid.
        */

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Button_Click(Object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                lblOutput.Text = "Результат: Верно!";
            }
            else
            {
                lblOutput.Text = "Результат: Не верно!";
            }
        }

        public void Operator_Index_Changed(Object sender, EventArgs e)
        {
            Compare1.Operator = (ValidationCompareOperator)ListOperator.SelectedIndex;
            Compare1.Validate();
        }

        public void Type_Index_Changed(Object sender, EventArgs e)
        {
            Compare1.Type = (ValidationDataType)ListType.SelectedIndex;
            Compare1.Validate();
        }
    }
}
