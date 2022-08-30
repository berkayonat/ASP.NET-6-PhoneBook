using MediatR;

namespace PhoneBook.CQRS.Commands.UpdatePerson
{
    public class UpdatePersonCommand : IRequest<int>
    {
        public UpdatePersonCommand(int id, string? name, string? phoneNumber, string? email, string? address)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
