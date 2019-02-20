using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SP.Repository
{
    interface IMongoDbRepository<TEntity> where TEntity:class,new()
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync();
        Task QueryAsync();
        Task DeleteAsync();
    }
}
