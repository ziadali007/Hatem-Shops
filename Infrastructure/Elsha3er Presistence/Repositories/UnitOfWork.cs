using Elsha3er_Domain.Contracts;
using Elsha3er_Domain.Models;
using Elsha3er_Presistence.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsha3er_Presistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Apple1DbContext _apple1;
        private readonly ConcurrentDictionary<Type, object> _repositories;

        public UnitOfWork(Apple1DbContext apple1)
        {
            _apple1 = apple1;
            _repositories = new ConcurrentDictionary<Type, object>();
        }

        public IGenericRepository<T> GetRepository<T>() where T : BaseEntity, IHasName
        {
            return (IGenericRepository<T>)_repositories.GetOrAdd(typeof(T), (Type _) => new GenericRepository<T>(_apple1));
        }

        public async Task<int> SaveChangesAsync()
        {
           return await _apple1.SaveChangesAsync();
        }
    }
}
