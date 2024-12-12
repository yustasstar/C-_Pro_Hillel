using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Core.Objects;

namespace DatabaseEntityFramework
{
    public partial class Default : System.Web.UI.Page
    {
        VUZEntities entity = new VUZEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Запрос на выборку без указания фильтра
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var q = from faculty in entity.FACULTY
                        select new { faculty.Name, faculty.Dean, faculty.Building, faculty.Fund };
                GridView1.DataSource = q.ToList();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }

        // Выбрать всех преподавателей с фамилией на "В"
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                var q = from a in entity.TEACHER
                        where a.Name.StartsWith("В")
                        select new { a.Name, a.TchPK };
                DropDownList1.DataSource = q.ToList();
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "TchPK";
                DropDownList1.DataBind();
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }

        // Добавление кафедры с помощью хранимой процедуры
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                var q =
                 from fac in entity.FACULTY
                 from dep in entity.DEPARTMENT
                 where fac.FacPK == dep.FacFK
                 orderby dep.Name descending
                 select new { DepartmentName = dep.Name, FacultyName = fac.Name, dep.Fund, dep.Head, dep.Building };
                GridView1.DataSource = q.ToList();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }

        // Исполнение хранимой процедуры
        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                ObjectParameter prm = new ObjectParameter("s", typeof(Int32));
                entity.how_many_teacher(prm);
                Label1.Text = "Количество преподавателей: " + prm.Value.ToString();
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }
    }
}