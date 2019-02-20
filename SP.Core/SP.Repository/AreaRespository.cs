using System;
using System.Collections.Generic;
using System.Text;
using SP.Models;
using SP.Infrastructure;
namespace SP.Repository
{
   public class AreaRespository:BaseRepository<SpArea>
    {

        public  AreaRespository(SPDbcontext dbcontext,SqlMap map) : base(dbcontext,map)
        {

        }
    }
}
