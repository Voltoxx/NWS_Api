using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NWS_Api1.Context;
using NWS_Api1.Models;

namespace NWS_Api1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        
        private readonly AppDBContext context;

        public PersonController(AppDBContext context)
        {
            this.context = context;
        }

        
        //GET Person/GetAllPeople
        [HttpGet("GetAllPeople")]
        public IEnumerable<Person> GetAllPeople()
        {
            return context.person;
        }

        
        //GET Person/GetOnePerson
        [HttpGet("GetOne/{nom}{prenom}")]
        public IEnumerable<Person> GetOnePerson(string nom, string prenom)
        {
            return context.person.Where(x => x.Name == nom && x.Surname == prenom);
           
        }

        //POST Person/InsertOnePerson
        [HttpPost("InsertOnePerson")]

        public ActionResult<Person> InsertOnePerson(Person person)
        {
            context.person.Add(person);
            context.SaveChanges();
            return Ok();
        }

        //PUT Person/UpdateOnePerson
        [HttpPut("UpdateOnePerson")]

        public ActionResult<Person> UpdateOnePerson(Person person)
        {
            context.Entry(person).State = EntityState.Modified;
            context.SaveChanges();
            return person;
        }

        //DELETE Person/DeleteOnePerson
        [HttpDelete("DeleteOnePerson")]

        public ActionResult<Person> DeleteOnePerson(Person person)
        {
            context.person.Remove(person);
            context.SaveChanges();
            return Ok();
        }

        //GET Person/AgeAscending
        [HttpGet("AgeAscending")]

        public IEnumerable<Person> AgeAscending()
        {
            return context.person.OrderBy(person => person.Age);
        }

        //GET Person/AlphabeticalOrder
        [HttpGet("AlphabeticalOrder")]

        public IEnumerable<string> AlphabeticalOrder()
        {
            return context.person
                .OrderBy(person => person.Name)
                .ThenBy(person => person.Surname)
                .Select(person => $"{person.Name} {person.Surname}");
        } 
    }
}
