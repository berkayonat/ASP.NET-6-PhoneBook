using MediatR;
using PhoneBook.CQRS.DTOs;
using PhoneBook.Repository.Interfaces;

namespace PhoneBook.CQRS.Queries.GetPersonById
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonDto>
    {
        private readonly IPersonRepository _personRepository;
        public GetPersonByIdQueryHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<PersonDto> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _personRepository.GetById(request.Id);
            return new PersonDto
            {
                Id = entity.Id,
                Name = entity.Name,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                Address = entity.Address,
                CreatedDate = entity.CreatedDate,
            };
        }
    }
}
