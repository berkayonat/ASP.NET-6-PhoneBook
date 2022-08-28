using MediatR;
using PhoneBook.Repository.Interfaces;

namespace PhoneBook.CQRS.Commands.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly IPersonRepository _personRepository;
        public DeletePersonCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            return await _personRepository.Delete(request.Id);
        }
    }
}
