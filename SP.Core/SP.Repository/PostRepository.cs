using SP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using SP.Infrastructure;
namespace SP.Repository
{
   public  class PostRepository:BaseRepository<Post>
    {
        public PostRepository(SPDbcontext dbcontext, SqlMap sqlMap) : base(dbcontext,sqlMap)
        {

        }
    }
}
