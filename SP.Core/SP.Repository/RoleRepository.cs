using System;
using System.Collections.Generic;
using System.Text;
using SP.Infrastructure;
using SP.Models;
namespace SP.Repository
{
   public class RoleRepository:BaseRepository<UserRole>
    {
        public RoleRepository(SPDbcontext _dbcontext,SqlMap sqlMap) : base(_dbcontext,sqlMap )
        {

        }
    }
}
