using MediatR;

namespace PhoneBook.CQRS.Commands.UpdatePerson
{
    public class UpdatePersonCommand : IRequest<bool>
    {
        public UpdatePersonCommand(string? name, string? phoneNumber, string? email, string? address)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
        }

        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
