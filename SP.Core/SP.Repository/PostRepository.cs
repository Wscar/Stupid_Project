using SP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using SP.Infrastructure;
using SP.Models.Cache;
namespace SP.Repository
{
   public  class PostRepository:BaseRepository<Post>
    {
        private readonly PostMongoDbRepository mongoDbRepository;
        public PostRepository(SPDbcontext dbcontext, SqlMap sqlMap ) : base(dbcontext,sqlMap)
        {
           
        }
       
    }
}
