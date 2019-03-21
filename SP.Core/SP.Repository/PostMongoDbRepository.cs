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
            await  CheckOrCreateCollectionNameAsync(collectionName);
            //获取集合
             Collection= dbContext.DataBase.GetCollection<PostCache>(collectionName);
            await Collection.InsertOneAsync(entity);
        }
        public void Add(PostCache entity)
        {
            string collectionName = nameof(PostCache);
             CheckOrCreateCollectionName(collectionName);
            //获取集合
            Collection = dbContext.DataBase.GetCollection<PostCache>(collectionName);
             Collection.InsertOne(entity);
        }
        private  async Task CheckOrCreateCollectionNameAsync(string collectionName)
        {
            var collections = await dbContext.DataBase.ListCollectionNamesAsync();
            var collectionNames=collections.ToList();
            if (!collectionNames.Contains(collectionName))
            {
                await dbContext.DataBase.CreateCollectionAsync(collectionName);
            }                                        
        }
        private void CheckOrCreateCollectionName(string collectionName)
        {
            var collections = dbContext.DataBase.ListCollectionNames();
            var collectionNames = collections.ToList();
            if (!collectionNames.Contains(collectionName))
            {
                dbContext.DataBase.CreateCollection(collectionName);
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
                        var updateResult = await Collection.UpdateOneAsync(filterDefintion, updateDefintion);
                    }
                }
            }
          
        }
        public  void Update(PostCache entity)
        {
            var post =  Collection.Find<PostCache>(x => x.Id == entity.Id);

            if (post != null)
            {
                if (post.Equals(entity))
                {
                    if (!entity.Comments.IsNullOrEmpty())
                    {
                        //说明这时候要更新或插入评论了
                        var filterDefintion = Builders<PostCache>.Filter.And(Builders<PostCache>.Filter.Where(x => x.Id == entity.Id));
                        var updateDefintion = Builders<PostCache>.Update.PushEach(x => entity.Comments, entity.Comments);
                        var updateResult =  Collection.UpdateOne(filterDefintion, updateDefintion);
                    }
                }
            }

        }
        public async Task<PostCache> QueryAsync(Expression<Func<PostCache, bool>> filter)
        {
            var result = await this.Collection.FindAsync(filter);
            return await result.FirstOrDefaultAsync();
        }
        public PostCache Query(Expression<Func<PostCache, bool>> filter)
        {
            var result =  this.Collection.Find(filter);
            return  result.FirstOrDefault();
        }
        public async Task<List<PostCache>> GetPageAsync(int forumId, int pageIndex, int pageCount=20)
        {
            // 这些数据只作为展示用的，所以不需要评论内容
            var newFilter = Builders<PostCache>.Filter.Eq(x => x.ForumId, forumId);
            var sort = Builders<PostCache>.Sort.Descending(x => x.EndReplyTime);
            var options = new FindOptions<PostCache>()
            {
                Sort = sort,
                Limit = pageCount = 20,
                Skip = (pageIndex - 1) * pageCount
            };
            var result=   await  this.Collection.FindAsync(newFilter, options);
            return result.ToList();

        }
    }
}
