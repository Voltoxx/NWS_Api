using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NWS_Api1.Context;
using NWS_Api1.Models;
using NWS_Api1.Repositories;

namespace NWS_Api1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private IPersonRepository personRepository = null;

        public PersonController(IPersonRepository persoRepository)
        {
            personRepository = persoRepository;
        }

        //GET Person/GetAllPeople
        [HttpGet("GetAllPeople")]
        public IEnumerable<Person> GetAllPeople()
        {
            return personRepository.GetAllPeople();
        }

        
        //GET Person/GetOnePerson
        [HttpGet("GetOne/{nom}/{prenom}")]
        public IEnumerable<Person> GetOnePerson(string nom, string prenom)
        {
            return personRepository.GetOnePerson(nom,prenom);
           
        }

        //POST Person/InsertOnePerson
        [HttpPost("InsertOnePerson")]

        public void InsertOnePerson(Person person)
        {
            personRepository.InsertOnePerson(person);
        }

        //PUT Person/UpdateOnePerson
        [HttpPut("UpdateOnePerson")]

        public ActionResult<Person> UpdateOnePerson(Person person)
        {
            personRepository.UpdateOnePerson(person);
            return person;
        }

        //DELETE Person/DeleteOnePerson
        [HttpDelete("DeleteOnePerson/{id}")]

        public void DeleteOnePerson(int id)
        {
            personRepository.DeleteOnePerson(id);
        }

        //GET Person/AgeAscending
        [HttpGet("AgeAscending")]

        public IEnumerable<Person> AgeAscending()
        {
            return personRepository.AgeAscending();
        }

        //GET Person/AlphabeticalOrder
        [HttpGet("AlphabeticalOrder")]

        public IEnumerable<string> AlphabeticalOrder()
        {
            return personRepository.AlphabeticalOrder();
        } 
    }
}
