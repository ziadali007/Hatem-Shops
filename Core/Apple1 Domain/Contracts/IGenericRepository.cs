using Apple1_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple1_Domain.Contracts
{
    public interface IGenericRepository<T> where T : BaseEntity, IHasName
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindByNameAsync(string name);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
