using WebAPIService.Models;

namespace WebAPIService.Data
{
    public static class PersonDatabase
    {
        public static readonly List<Person> persons = new()
        {
            new Person(){Id = 1, FirstName = "Jonas", LastName="Odogwu", Address ="Lagos, Nigeria", Age=37, CreditCard="123456"},
            new Person(){Id = 2, FirstName = "James", LastName="Faleke", Address ="Kogi, Nigeria", Age=57, CreditCard="657234"},
        };
        
    }
}
