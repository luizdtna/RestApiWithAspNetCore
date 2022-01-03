using Domain.Entityes;
using System.Collections.Generic;

namespace Domain.Repositories.Interface
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);
        Person FindByID(long id);
        IEnumerable<Person> ListAll();
    }
}
