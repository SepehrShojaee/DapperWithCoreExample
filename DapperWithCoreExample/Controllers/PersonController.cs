using DapperWithCoreExample.Interfaces;
using DapperWithCoreExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperWithCoreExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        
        public ActionResult<List<Person>> Get()
        {
            return  _personRepository.GetAllPerson();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Person> GetPersonById(int id)
        {
            return _personRepository.GetPersonById(id);
        }

        [HttpPost]

        public ActionResult AddPerson(Person person)
        {
             _personRepository.AddPerson(person);
            return Ok(person);
        }
        [HttpPost]
        public ActionResult RemovePerson(Person person)
        {
            _personRepository.RemovePerson(person);
            return Ok(person);
        }
        [HttpPost]
        public ActionResult UpdatePerson(Person person)
        {
            _personRepository.UpdatePerson(person);
            return Ok(person);
        }
    }


}
