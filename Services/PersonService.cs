using WebAPIService.Data;
using WebAPIService.Dtos;
using WebAPIService.Interface;
using WebAPIService.Models;

namespace WebAPIService.Services
{
    public class PersonService : IPersonInterface
    {
        /*private readonly List<Person> persons = new()
        {
            new Person(){Id = 1, FirstName = "Jonas", LastName="Odogwu", Address ="Lagos, Nigeria", Age=37, CreditCard="123456"},
            new Person(){Id = 2, FirstName = "James", LastName="Faleke", Address ="Kogi, Nigeria", Age=57, CreditCard="657234"},
        };*/

        private readonly ApplicationDbContext _context;
        public PersonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetPersons()
        {
            return _context.Persons;
        }

        public Person GetPerson(int id)
        {
            return _context.Persons.FirstOrDefault(x => x.Id == id);
           // return GetPersons().FirstOrDefault(x => x.Id == id);
        }

        public void Create(Person person)
        {
            //PersonDatabase.persons.Add(person);
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        public void Update(int id)
        {
            _context.Persons.Where(x => x.Id == id).FirstOrDefault();
            _context.SaveChanges();
            //PersonDatabase.persons.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Delete(int id)
        {
            _context.Persons.Remove(GetPerson(id));
            _context.SaveChanges();
            //PersonDatabase.persons.Remove(GetPerson(id));
        }
    }
}
