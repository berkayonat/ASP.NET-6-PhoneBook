using MediatR;
using PhoneBook.CQRS.DTOs;

namespace PhoneBook.CQRS.Queries.GetAllPersons
{
    public class GetAllPersonsQuery : IRequest<IEnumerable<PersonDto>>
    {
        public GetAllPersonsQuery()
        {

        }
    }
}
