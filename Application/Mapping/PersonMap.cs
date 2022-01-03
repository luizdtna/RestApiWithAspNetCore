using Application.Model;
using AutoMapper;
using Domain.Entityes;

namespace Application.Mapping
{
    public class PersonMap : Profile
    {
        public PersonMap()
        {
            CreateMap<PersonModel, Person>();
            CreateMap<Person, PersonModel>();
        }
    }
}
