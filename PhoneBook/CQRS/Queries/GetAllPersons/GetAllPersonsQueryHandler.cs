using MediatR;
using PhoneBook.CQRS.DTOs;
using PhoneBook.Repository.Interfaces;

namespace PhoneBook.CQRS.Queries.GetAllPersons
{
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, IEnumerable<PersonDto>>
    {
        private readonly IPersonRepository _personRepository;
        public GetAllPersonsQueryHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<IEnumerable<PersonDto>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            var entities =  await _personRepository.GetAll();
            return (IEnumerable<PersonDto>)entities;
        }
    }
}
