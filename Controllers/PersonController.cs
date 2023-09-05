using Microsoft.AspNetCore.Mvc;
using WebAPIService.Dtos;
using WebAPIService.Interface;
using WebAPIService.Models;
using WebAPIService.Services;

namespace WebAPIService.Controllers
{
    [Route("api")]
    [ApiController]
    
    public class PersonController : Controller
    {
        private readonly IPersonInterface _personInterface;
        public PersonController(IPersonInterface personInterface)
        {
            _personInterface = personInterface;
        }


        [HttpGet]
        public IEnumerable<PersonDTO> Index()
        {
            var persons = _personInterface.GetPersons().Select(x => new PersonDTO()
            { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName, Address = x.Address });
            return persons;
           
        }

        [HttpGet("id")]
        public ActionResult<PersonDTO> GetOnePerson(int? id)
        {
            var person = _personInterface.GetPersons().FirstOrDefault(x => x.Id == id);
            if(person == null)
            {
                return NotFound();
            }

            return new PersonDTO
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Address = person.Address
            };

         }

        [HttpPost]
        public ActionResult<PersonDTO> CreateNew(PersonDTO personDTO)
        {
            Person person = new()
            {
                Id = personDTO.Id,
                FirstName = personDTO.FirstName,
                LastName = personDTO.LastName,
                Address = personDTO.Address
            };
            _personInterface.Create(person);
            
            return CreatedAtAction(nameof(GetOnePerson), new { id = personDTO.Id }, personDTO);

        }

        [HttpPut("id")]
        public ActionResult UpdatePerson(int id, PersonDTO personDTO)
        {
            var person = _personInterface.GetPerson(id);
           
            if(person == null)
            {
                return NotFound();
            }


            Person personUpdate = person;
            personUpdate.FirstName = personDTO.FirstName;
            personUpdate.LastName = personDTO.LastName;
            personUpdate.Address = personDTO.Address;               
   
           return NoContent();
            
        }

        [HttpDelete("id")]
        public void Delete(int id)
        {
            _personInterface.Delete(id);
            
        }
    }
}
