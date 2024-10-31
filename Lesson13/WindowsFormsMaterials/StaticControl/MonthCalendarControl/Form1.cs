using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonthCalendarControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            monthCalendar1.TodayDate = new DateTime(2015, 09, 6); // определяет текущую дату 
            // По умолчанию используется системная дата на компьютере, но с помощью данного свойства мы можем ее изменить
            monthCalendar1.ShowTodayCircle = true; // при значении true текущая дата будет обведена кружочком
            monthCalendar1.ShowToday = true; // при значении true отображает внизу календаря текущую дату
            monthCalendar1.SelectionStart = new DateTime(2015, 9, 7); // задает начальную дату выделения
            monthCalendar1.SelectionEnd = new DateTime(2015, 9, 13); // определяет конечную дату выделения
            monthCalendar1.AddBoldedDate(new DateTime(2015, 9, 13)); // содержит набор дат, которые будут отмечены жирным (только для текущего года)
            monthCalendar1.AddAnnuallyBoldedDate(new DateTime(2015, 9, 2)); // содержит набор дат, которые будут отмечены жирным в календаре для каждого года

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            label1.Text = String.Format("Вы выбрали: {0}", e.Start.ToLongDateString());
            //label1.Text = String.Format("Вы выбрали: {0}", monthCalendar1.SelectionStart.ToLongDateString());
        }
    }
}
