using Apple1_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Apple1_Domain.Contracts
{
    public interface IGenericRepository<T> where T : BaseEntity, IHasName
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindByNameAsync(string name);
        Task<T?> GetByIdAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAsyncCollection(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<decimal> SumAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, decimal>> selector);

        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
