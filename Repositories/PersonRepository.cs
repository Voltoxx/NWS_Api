using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NWS_Api1.Context;
using NWS_Api1.Models;

namespace NWS_Api1.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDBContext context;

        public PersonRepository(AppDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return context.person;
        }

        public IEnumerable<Person> GetOnePerson(string nom, string prenom)
        {
            return context.person.Where(x => x.Name == nom && x.Surname == prenom);

        }

        public void InsertOnePerson(Person person)
        {
            context.person.Add(person);
            context.SaveChanges();
        }

        public ActionResult<Person> UpdateOnePerson(Person person)
        {
            context.Entry(person).State = EntityState.Modified;
            context.SaveChanges();
            return person;
        }

        public void DeleteOnePerson(int id)
        {
            context.person.Remove(context.person.Find(id));
            context.SaveChanges();
        }

        public IEnumerable<Person> AgeAscending()
        {
            return context.person.OrderBy(person => person.Age);
        }

        public IEnumerable<string> AlphabeticalOrder()
        {
            return context.person
                .OrderBy(person => person.Name)
                .ThenBy(person => person.Surname)
                .Select(person => $"{person.Name} {person.Surname}");
        }

        public IEnumerable<string> HisStatut(string statut)
        {
            return context.person
                .Include(o => o.Statut)
                .Where(x => x.StatutId == statut);
        }

    }
}
