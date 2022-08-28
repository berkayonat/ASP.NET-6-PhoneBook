using MediatR;
using PhoneBook.Models;
using PhoneBook.Repository.Interfaces;

namespace PhoneBook.CQRS.Commands.UpdatePerson
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, bool>
    {
        private readonly IPersonRepository _personRepository;
        public UpdatePersonCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<bool> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = new Person()
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Address = request.Address,

            };
            return await _personRepository.Update(entity);
        }
    }
}
