using PhoneBook.Data;
using PhoneBook.Models;
using PhoneBook.Repository.Interfaces;

namespace PhoneBook.Repository.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext context) : base(context)
        {
        }
    }
}
