using System.Linq.Expressions;

namespace PhoneBook.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        Task<bool> Add(T entity);
        Task<bool> Delete(int id);
        Task<bool> Update(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
