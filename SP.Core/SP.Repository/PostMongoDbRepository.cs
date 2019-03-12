using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SP.Infrastructure;
using System.Linq;
using MongoDB.Driver;
using System.Linq.Expressions;
using SP.Models.Cache;
namespace SP.Repository
{
   public class PostMongoDbRepository
       
    {
        private readonly SpMongoDbContext dbContext;
        public PostMongoDbRepository(SpMongoDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        private IMongoCollection<PostCache> Collection;
        public async Task  AddAsync(PostCache entity)
        {
            string collectionName = nameof(PostCache);
            await  CheckOrCreateCollectionName(collectionName);
            //获取集合
             Collection= dbContext.DataBase.GetCollection<PostCache>(collectionName);
            await Collection.InsertOneAsync(entity);
        }
        private  async Task CheckOrCreateCollectionName(string collectionName)
        {
            var collections = await dbContext.DataBase.ListCollectionNamesAsync();
            var collectionNames=collections.ToList();
            if (!collectionNames.Contains(collectionName))
            {
                await dbContext.DataBase.CreateCollectionAsync(collectionName);
            }                                        
        }
        public async Task UpdateAsync(PostCache entity)
        {
             var post=  await Collection.FindAsync<PostCache>(x=>x.Id==entity.Id);
            if (post != null)
            {
                if (post.Equals(entity))
                {   
                    if (!entity.Comments.IsNullOrEmpty())
                    {
                        //说明这时候要更新或插入评论了
                        var filterDefintion = Builders<PostCache>.Filter.And(Builders<PostCache>.Filter.Where(x=>x.Id==entity.Id));
                        var updateDefintion = Builders<PostCache>.Update.PushEach(x => entity.Comments, entity.Comments);
                        var updateResult = Collection.UpdateOne(filterDefintion, updateDefintion);
                    }
                }
            }
          
        }
        public async Task Query()
        {

        }
        public async Task Delete()
        {

        }
    }
}
