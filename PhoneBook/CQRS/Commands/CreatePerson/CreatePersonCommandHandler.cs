using MediatR;
using PhoneBook.Models;
using PhoneBook.Repository.Interfaces;

namespace PhoneBook.CQRS.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IPersonRepository _personRepository;
        public CreatePersonCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = new Person()
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Address = request.Address,
                CreatedDate = DateTime.Now,
            };
            _personRepository.Add(entity);
            return Task.FromResult(entity.Id);
        }
    }
}
