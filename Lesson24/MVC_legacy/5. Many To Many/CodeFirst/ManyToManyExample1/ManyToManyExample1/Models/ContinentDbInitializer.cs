using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ManyToManyExample1.Models
{
    public class ContinentDbInitializer: CreateDatabaseIfNotExists<LanguageContext>
    {
        protected override void Seed(LanguageContext context)
        {
            Language lang1 = new Language { Id = 1, Name = "Английский" };
            Language lang2 = new Language { Id = 2, Name = "Испанский" };
            Language lang3 = new Language { Id = 3, Name = "Французский" };
            Language lang4 = new Language { Id = 4, Name = "Португальский" };

            context.Languages.Add(lang1);
            context.Languages.Add(lang2);
            context.Languages.Add(lang3);
            context.Languages.Add(lang4);

            Continent c1 = new Continent
            {
                Id = 1,
                Name = "Африка",
                Languages = new List<Language>() { lang1, lang3, lang4 }
            };
            Continent c2 = new Continent
            {
                Id = 1,
                Name = "Южная Америка",
                Languages = new List<Language>() { lang2, lang4 }
            };
            Continent c3 = new Continent
            {
                Id = 1,
                Name = "Европа",
                Languages = new List<Language>() { lang1, lang2, lang3, lang4 }
            };

            context.Continents.Add(c1);
            context.Continents.Add(c2);
            context.Continents.Add(c3);

            base.Seed(context);
        }
    }
}