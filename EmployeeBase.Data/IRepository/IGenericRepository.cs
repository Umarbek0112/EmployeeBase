using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using EmployeeBase.Domain.Commons;

namespace EmployeeBase.Data.IRepository
{
    public interface IGenericRepository<T> where T : Auditable
    {
        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null, string[] includes = null, bool isTracking = true);
        public Task<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null, bool isTracking = true);
        public Task<T> CreateAsync(T entity);
        public Task<bool> DeleteAsync(int id);
        public T Update(T entity);
        public Task SaveChangesAsync();
    }
}
