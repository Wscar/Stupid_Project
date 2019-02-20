using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SP.Infrastructure;
using System.Linq;
namespace SP.Repository
{
   public class MongoDbRepository<TEntity> where TEntity:class,new()
       
    {
        private readonly SpMongoDbContext dbContext;
        public MongoDbRepository(SpMongoDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task  AddAsync(TEntity entity)
        {
            string collectionName = nameof(TEntity);
            await  CheckOrCreateCollectionName(collectionName);
            //获取集合
            var collection= dbContext.DataBase.GetCollection<TEntity>(collectionName);
            await collection.InsertOneAsync(entity);
        }
        private  async Task CheckOrCreateCollectionName(string collectionName)
        {
           var collections=await dbContext.DataBase.ListCollectionNamesAsync();
           var allCollectionNames = collections.Current;
            if (!allCollectionNames.Contains(collectionName))
            {
               await  dbContext.DataBase.CreateCollectionAsync(collectionName);
            }
        
        }
        public async Task UpdateAsync(TEntity entity)
        {

        }
        public async Task Query()
        {

        }
        public async Task Delete()
        {

        }
    }
}
