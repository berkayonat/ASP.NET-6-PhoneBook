using AutoMapper;
using MediatR;
using PhoneBook.CQRS.DTOs;
using PhoneBook.Repository.Interfaces;

namespace PhoneBook.CQRS.Queries.GetAllPersons
{
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, IEnumerable<PersonDto>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public GetAllPersonsQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public Task<IEnumerable<PersonDto>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            var entities = _personRepository.GetAll();
            return Task.FromResult(_mapper.Map<IEnumerable<PersonDto>>(entities));
        }
    }
}
