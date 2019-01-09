using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MySql.Data.MySqlClient;
namespace SP.Repository
{
   public static  class RepositoryExtension
    {
         public static string  XXX<TEntity>(this IBaseRepository<TEntity> baseRepository ,string sqlMapKey="" ) where TEntity : class
        {
            return null;
        }
    }
}
