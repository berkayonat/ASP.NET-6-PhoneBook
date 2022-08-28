using MediatR;
using PhoneBook.CQRS.DTOs;

namespace PhoneBook.CQRS.Queries.GetPersonById
{
    public class GetPersonByIdQuery : IRequest<PersonDto>
    {
        public int Id { get; set; }
        public GetPersonByIdQuery(int id)
        {
            Id = id;
        }
    }
}
