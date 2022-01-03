using AutoMapper;
using Domain.Entityes;
using Repository.Model;

namespace Repository.Mapping
{
    public class PersonDbMap : Profile
    {
        public PersonDbMap()
        {
            CreateMap<PersonDbModel, Person>();
            CreateMap<Person, PersonDbModel>()
                .ForMember(dest => dest.Id, m => m.Ignore());
        }
    }
}
