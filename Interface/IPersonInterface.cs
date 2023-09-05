using WebAPIService.Dtos;
using WebAPIService.Models;

namespace WebAPIService.Interface
{
    public interface IPersonInterface
    {
        IEnumerable<Person> GetPersons();

        Person GetPerson(int id);

        void Create(Person person);

        void Update(int id);

        void Delete(int id);
    }
}
