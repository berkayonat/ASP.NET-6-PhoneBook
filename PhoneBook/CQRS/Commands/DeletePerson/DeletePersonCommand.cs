using MediatR;

namespace PhoneBook.CQRS.Commands.DeletePerson
{
    public class DeletePersonCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeletePersonCommand(int id)
        {
            Id = id;
        }
    }
}
