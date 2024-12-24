using GenericRepositoryExample.Models;
using GenericRepositoryExample.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericRepositoryExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IMongoRepository<Person> _peopleRepository;

        public PersonController(IMongoRepository<Person> peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        [HttpPost]
        [Route("add/{firstName}/{lastName}")]
        public async Task AddPerson(string firstName, string lastName)
        {
            var person = new Person()
            {
                FirstName = firstName,
                LastName = lastName
            };

            await _peopleRepository.InsertOneAsync(person);
        }

        [HttpGet]
        [Route("people")]
        public IEnumerable<string> GetPeopleData()
        {
            var people = _peopleRepository.FilterBy(
                filter => filter.FirstName != "test",
                projection => projection.FirstName
            );

            return people;
        }
    }
}
