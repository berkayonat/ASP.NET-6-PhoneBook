using MediatR;
using PhoneBook.Models;
using PhoneBook.Repository.Interfaces;

namespace PhoneBook.CQRS.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, bool>
    {
        private readonly IPersonRepository _personRepository;
        public CreatePersonCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<bool> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = new Person()
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Address = request.Address,
                CreatedDate = DateTime.Now,
            };
            return await _personRepository.Add(entity);
        }
    }
}
