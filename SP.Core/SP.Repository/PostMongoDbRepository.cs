using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SP.Infrastructure;
using System.Linq;
using MongoDB.Driver;
using System.Linq.Expressions;
using SP.Models.Cache;
using MongoDB.Bson;

namespace SP.Repository
{
   public class PostMongoDbRepository
       
    {
        private readonly SpMongoDbContext dbContext;
        public PostMongoDbRepository(SpMongoDbContext _dbContext)
        {
            dbContext = _dbContext;
            string collectionName = nameof(PostCache);
            this.CheckOrCreateCollectionName(collectionName);
        }
        private IMongoCollection<PostCache> Collection;
        public async Task  AddAsync(PostCache entity)
        {                
            //获取集合
           
            await Collection.InsertOneAsync(entity);
        }
        public void Add(PostCache entity)
        {       
             Collection.InsertOne(entity);
        }
        private  async Task CheckOrCreateCollectionNameAsync(string collectionName)
        {
            var collections = await dbContext.DataBase.ListCollectionNamesAsync();
            var collectionNames=collections.ToList();
            if (!collectionNames.Contains(collectionName))
            {
                await dbContext.DataBase.CreateCollectionAsync(collectionName);
                this.Collection = dbContext.DataBase.GetCollection<PostCache>(collectionName);

            }
            else
            {
                this.Collection = dbContext.DataBase.GetCollection<PostCache>(collectionName);
            }                                        
        }
        private void CheckOrCreateCollectionName(string collectionName)
        {
            var collections = dbContext.DataBase.ListCollectionNames();
            var collectionNames = collections.ToList();
            if (!collectionNames.Contains(collectionName))
            {
                dbContext.DataBase.CreateCollection(collectionName);
                this.Collection = dbContext.DataBase.GetCollection<PostCache>(collectionName);
            }
            else
            {
                this.Collection = dbContext.DataBase.GetCollection<PostCache>(collectionName);
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
            var findFilter = Builders<PostCache>.Filter.Eq(x => x.ForumId, forumId);

            var options = new FindOptions<PostCache>
            {
                Sort = Builders<PostCache>.Sort.Descending(x => x.EndReplyTime),
                Limit = pageCount,
                Skip = pageIndex - 1
            };
           var result=  await this.Collection.FindAsync(findFilter, options);
            return result.ToList();
        }
        private IEnumerable<PostCache> GetGreaterThenEndReplyTime(List<PostCache> postCaches, DateTime endReplyTime)
        {
             for(var i=0; i < postCaches.Count; i++)
            {
                if (DateTime.Compare(postCaches[i].CreateTime, endReplyTime)>0)
                {
                    yield return postCaches[i];
                }
            }
        }
        private void UpdateFild()
        {         
            var findFilter = Builders<PostCache>.Filter.Gt(x => x.Id, -1);
         
          



           
        }
    }
}
