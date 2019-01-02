using System;
using System.Collections.Generic;
using System.Text;
using SP.Models;
using SP.Infrastructure;
namespace SP.Repository
{
    public  class AppUserRepository:BaseRepository<AppUser>
    {
       
        public AppUserRepository(SPDbcontext _dbcontext):base(_dbcontext)
        {        
        }
    }
}
