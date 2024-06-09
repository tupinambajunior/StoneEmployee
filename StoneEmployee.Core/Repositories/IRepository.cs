using StoneEmployee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Core.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        public Task<List<T>> GetListAsync();
        public Task<T> GetByIdAsync(string id);
        public Task<string> CreateAsync(T entity);
        public Task UpdateAsync();
        public Task DeleteAsync(string id);
        public Task SaveChangesAsync();
    }
}
