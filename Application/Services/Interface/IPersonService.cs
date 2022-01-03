using Application.Model;
using System.Collections.Generic;

namespace Application.Services.Interface
{
    public interface IPersonService
    {
        PersonModel Create(PersonModel person);
        PersonModel Update(PersonModel person);
        void Delete(long id);
        PersonModel FindByID(long id);
        IEnumerable<PersonModel> ListAll();
    }
}
