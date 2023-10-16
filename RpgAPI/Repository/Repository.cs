using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RpgAPI.Data;
using RpgAPI.Repository.IRepository;

namespace RpgAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _userRepository;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _userRepository = db;
            dbSet = _userRepository.Set<T>();
        }
        public T GetById(int id)
        {
            return dbSet.Find(id);
        }
        public IEnumerable<T> GetAll(
            System.Linq.Expressions.Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (include != null)
            {
                query = include(query);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return query.ToList();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }
        public void Save()
        {
            _userRepository.SaveChanges();
        }
    }
}
