using System.ComponentModel.DataAnnotations;

namespace CRUDDialogApp.Models
{
    public class Student
    {
        // Идентификатор студента
        public int Id { get; set; }

        // Имя студента
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Name { get; set; }

        // Фамилия студента
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Surname { get; set; }

        // Возраст студента
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Range(15, 55, ErrorMessage = "Неверно указан возраст")]
        public int Age { get; set; }

        // Средний балл
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Range(0, 12, ErrorMessage = "Неверно указан средний балл")]
        public float GPA { get; set; }
    }
}