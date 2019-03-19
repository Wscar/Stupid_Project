using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SP.Models.Cache;
using SP.Repository;
namespace Sp.Service
{
    public class PostCacheService : ICacheService<PostCache>
    {
        private readonly PostMongoDbRepository dbRepository;
        public  PostCacheService(PostMongoDbRepository _dbRepository)
        {
            dbRepository = _dbRepository;
        }
        public PostCache AddCache(PostCache value)
        {
            dbRepository.Add(value);
            return value;
        }

        public async Task<PostCache> AddCacheAsync(PostCache value)
        {
            await dbRepository.AddAsync(value);
            return await Task.FromResult(value);
        }

        public PostCache GetCache(PostCache value)
        {
           return dbRepository.Query(x => x.Id == value.Id);
        }

        public Task<PostCache> GetCacheAsync(PostCache value)
        {
            throw new NotImplementedException();
        }

        public void UpdateCache(PostCache value)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCacheAsync(PostCache value)
        {
            throw new NotImplementedException();
        }
        
    }
}
