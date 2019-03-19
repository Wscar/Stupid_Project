using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sp.Service
{
    public interface ICacheService<TCache> where TCache : new()
    {
        Task<TCache> GetCacheAsync(TCache value);
        TCache GetCache(TCache value);
        Task UpdateCacheAsync(TCache value);
        void UpdateCache(TCache value);
        Task<TCache> AddCacheAsync(TCache value);
        TCache AddCache(TCache value);
    }
}
