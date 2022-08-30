using MediatR;
using PhoneBook.Models;
using PhoneBook.Repository.Interfaces;

namespace PhoneBook.CQRS.Commands.UpdatePerson
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, int>
    {
        private readonly IPersonRepository _personRepository;
        public UpdatePersonCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public Task<int> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = _personRepository.GetById(request.Id);
            entity.Name = request.Name;
            entity.PhoneNumber = request.PhoneNumber;
            entity.Email = request.Email;
            entity.Address = request.Address;

            _personRepository.Update(entity);
            return Task.FromResult(request.Id);
        }
    }
}
