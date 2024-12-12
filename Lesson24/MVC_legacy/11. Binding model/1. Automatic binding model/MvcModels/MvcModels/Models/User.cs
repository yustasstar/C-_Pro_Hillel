using System.ComponentModel;

namespace MvcModels.Models
{
    public class User
    {
        public int UserId { get; set; }

        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [DisplayName("Адрес")]
        public Address HomeAddress { get; set; }

    }

    public class Address
    {
        [DisplayName("Страна")]
        public string Country { get; set; }  
        
        [DisplayName("Город")]
        public string City { get; set; }

        [DisplayName("Адрес")]
        public string Line { get; set; }

        [DisplayName("Почтовый индекс")]
        public string PostalCode { get; set; }
    }

}