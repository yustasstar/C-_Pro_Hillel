using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManyToManyExample1.Models
{
    public class Continent
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Language> Languages { get; set; }
    }
}