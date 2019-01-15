using System;
using System.Collections.Generic;
using System.Text;
using SP.Models;
using SP.Infrastructure;
namespace SP.Repository
{
   public class ForumRepository:BaseRepository<Forum>
    {
        public ForumRepository(SPDbcontext dbcontext) : base(dbcontext)
        {

        }
    }
}
