using MediatR;
using PhoneBook.CQRS.DTOs;

namespace PhoneBook.CQRS.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest<bool>
    {
        public CreatePersonCommand(string? name, string? phoneNumber, string? email, string? address)
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
