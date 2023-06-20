using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NWS_Api1.Context;
using NWS_Api1.Models;

namespace NWS_Api1.Repositories
{
    public class PersonRepository 
    {
        private readonly AppDBContext _context;

        public PersonRepository(AppDBContext context)
        {
            this._context = context;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return _context.Person;
        }

        public IEnumerable<Person> GetOnePerson(string nom, string prenom)
        {
            return _context.Person.Where(x => x.Name == nom && x.Surname == prenom);

        }

        public void InsertOnePerson(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        public ActionResult<Person> UpdateOnePerson(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            _context.SaveChanges();
            return person;
        }

        public void DeleteOnePerson(int id)
        {
            _context.Person.Remove(_context.Person.First(x => x.Id == id));
            _context.SaveChanges();
        }

        public IEnumerable<Person> AgeAscending()
        {
            return _context.Person.OrderBy(person => person.Age);
        }

        public IEnumerable<string> AlphabeticalOrder()
        {
            return _context.Person
                .OrderBy(person => person.Name)
                .ThenBy(person => person.Surname)
                .Select(person => $"{person.Name} {person.Surname}");
        }

        public IEnumerable<Person> HisStatut(string statut)
        {
            return _context.Person
                .Include(o => o.Statut)
                .Where(x => x.Statut.NameStatut == statut);
        }

    }
}
