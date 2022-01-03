using AutoMapper;
using Domain.Entityes;
using Domain.Repositories.Interface;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MysqlContext _context;
        private readonly IMapper _mapper;

        public PersonRepository(MysqlContext mysqlContext, IMapper mapper)
        {
            _context = mysqlContext;
            _mapper = mapper;
        }
        public IEnumerable<Person> ListAll()
        {
            List<PersonDbModel> personDb = _context.Persons.ToList();
            return _mapper.Map<IEnumerable<Person>>(personDb);
        }

        public Person Create(Person person)
        {
            try
            {
                var personDbModel = _mapper.Map<PersonDbModel>(person);
                _context.Add(personDbModel);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return person;
        }

        public void Delete(long id)
        {
            try
            {
                var personDbModel = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
                _context.Persons.Remove(personDbModel);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Person FindByID(long id)
        {
            var personDbModel = _context.Persons.SingleOrDefault(person => person.Id.Equals(id));
            return _mapper.Map<Person>(personDbModel);
        }

        public Person Update(Person person)
        {
            if (Existis(person.Id) is false)
                return new Person();

            try
            {
                var personToUpdate = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
                var personDbModel = _mapper.Map<PersonDbModel>(person);
                personDbModel.Id = personToUpdate.Id;

                _context.Entry(personToUpdate).CurrentValues.SetValues(personDbModel);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return person;
        }

        private bool Existis(long id)
        {
            return _context.Persons.Any(person => person.Id.Equals(id));
        }
    }
}
