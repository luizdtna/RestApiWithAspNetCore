using Application.Model;
using Application.Services.Interface;
using AutoMapper;
using Domain.Entityes;
using Domain.Repositories.Interface;
using Repository.Model;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Implemantations
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IMapper mapper, IPersonRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public PersonModel Create(PersonModel personModel)
        {
            var person = _mapper.Map<Person>(personModel);
            
            var personResult = _personRepository.Create(person);

            return _mapper.Map<PersonModel>(personResult);
        }

        public void Delete(long id)
        {
            _personRepository.Delete(id);
        }

        public PersonModel FindByID(long id)
        {
            var person = _personRepository.FindByID(id);
            return _mapper.Map<PersonModel>(person);
        }

        public IEnumerable<PersonModel> ListAll()
        {
            var personList = _personRepository.ListAll();
            return _mapper.Map<IEnumerable<PersonModel>>(personList);

        }

        public PersonModel Update(PersonModel personModel)
        {
            var person = _mapper.Map<Person>(personModel);

            var personResult = _personRepository.Update(person);

            return _mapper.Map<PersonModel>(personResult);
        }
    }
}
