using MediatR;
using PhoneBook.CQRS.DTOs;

namespace PhoneBook.CQRS.Queries.GetPersonsWithFilters
{
    public class GetPersonsWithFiltersQuery : IRequest<IEnumerable<PersonDto>>
    {
        public GetPersonsWithFiltersQuery(string? filter)
        {
            Filter = filter;

        }
        public string? Filter { get; set; }

    }
}
