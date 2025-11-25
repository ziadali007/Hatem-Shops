using Apple1_Domain.Contracts;
using Apple1_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Presistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, IHasName
    {
        private readonly Apple1DbContext _apple1;
        public GenericRepository(Apple1DbContext apple1)
        {
            _apple1 = apple1;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _apple1.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> FindByNameAsync(string name)
        {
            return await _apple1.Set<T>().FirstOrDefaultAsync(e => e.Name == name);
        }
        public async Task AddAsync(T entity)
        {
            await _apple1.Set<T>().AddAsync(entity);
        }
        public void Update(T entity)
        {
            _apple1.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            _apple1.Set<T>().Remove(entity);
        }

    }
}
