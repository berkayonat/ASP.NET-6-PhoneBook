using AutoMapper;
using MediatR;
using PhoneBook.CQRS.DTOs;
using PhoneBook.Repository.Interfaces;

namespace PhoneBook.CQRS.Queries.GetPersonsWithFilters
{
    public class GetPersonsWithFiltersQueryHandler : IRequestHandler<GetPersonsWithFiltersQuery, IEnumerable<PersonDto>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public GetPersonsWithFiltersQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public Task<IEnumerable<PersonDto>> Handle(GetPersonsWithFiltersQuery request, CancellationToken cancellationToken)
        {
            var entities = _personRepository.GetAll();
            
            if (!String.IsNullOrEmpty(request.Filter))
            {
                entities = entities.Where(x => x.Name.Contains(request.Filter) || x.PhoneNumber.Contains(request.Filter));
            }
            var result = _mapper.Map<IEnumerable<PersonDto>>(entities.OrderByDescending(x => x.CreatedDate));
            
            return Task.FromResult(result);
        }
    }
}
