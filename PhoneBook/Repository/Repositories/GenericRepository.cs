using Microsoft.EntityFrameworkCore;
using PhoneBook.Data;
using PhoneBook.Repository.Interfaces;
using System.Linq.Expressions;

namespace PhoneBook.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
        public async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;    
        }

        public async Task<bool> Delete(int id)
        {
            var exist = await dbSet.FindAsync(id);


            if (exist == null) return false;

            dbSet.Remove(exist);

            return true;
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public Task<bool> Update(T entity)
        {
            dbSet.Update(entity);
            return Task.FromResult(true);
        }
    }
}
