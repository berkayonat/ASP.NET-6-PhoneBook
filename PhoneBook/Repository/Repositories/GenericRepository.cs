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
            _context.SaveChanges();
            return true;    
        }

        public async Task<bool> Delete(int id)
        {
            var exist = await dbSet.FindAsync(id);


            if (exist == null) return false;

            dbSet.Remove(exist);
            _context.SaveChanges();

            return true;
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetById(int id)
        {  
            return dbSet.Find(id);
        }

        public Task<bool> Update(T entity)
        {
            dbSet.Update(entity);
            _context.SaveChanges();
            return Task.FromResult(true);
        }
    }
}
