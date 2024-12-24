using System;

namespace GenericRepositoryExample.Models
{
    [BsonCollection("people")]
    public class Person : Document
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
