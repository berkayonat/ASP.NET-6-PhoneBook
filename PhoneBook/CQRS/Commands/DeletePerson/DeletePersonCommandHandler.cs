using MediatR;
using PhoneBook.Repository.Interfaces;

namespace PhoneBook.CQRS.Commands.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, int>
    {
        private readonly IPersonRepository _personRepository;
        public DeletePersonCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public Task<int> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            _personRepository.Delete(request.Id);
            return Task.FromResult(request.Id);
        }
    }
}
