using Microsoft.AspNetCore.Mvc;
using NWS_Api1.Models;

namespace NWS_Api1.Repositories
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAllPeople();
        IEnumerable<Person> GetOnePerson(string nom, string prenom);
        void InsertOnePerson(Person person);
        ActionResult<Person> UpdateOnePerson(Person person);
        void DeleteOnePerson(int id);
        IEnumerable<Person> AgeAscending();
        IEnumerable<string> AlphabeticalOrder();
        IEnumerable<string> HisStatut(string statut);

    }
}
