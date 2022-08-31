using AutoMapper;
using PhoneBook.CQRS.DTOs;
using PhoneBook.Models;
using PhoneBook.Models.ViewModels;

namespace PhoneBook.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<Person, PersonViewModel>();
            CreateMap<PersonDto, PersonViewModel>();
            CreateMap<PersonViewModel, PersonDto>();
        }
    }
}
