using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace RpgAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool isTracking = true
            );
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
