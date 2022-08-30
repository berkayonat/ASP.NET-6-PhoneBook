using AutoMapper;
using MediatR;
using PhoneBook.CQRS.DTOs;
using PhoneBook.Repository.Interfaces;

namespace PhoneBook.CQRS.Queries.GetPersonById
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonDto>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public GetPersonByIdQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public Task<PersonDto> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = _personRepository.GetById(request.Id);
            return Task.FromResult(_mapper.Map<PersonDto>(entity));
        }
    }
}
