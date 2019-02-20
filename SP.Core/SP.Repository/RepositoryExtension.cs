using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using SP.Models;
using System.Data;
namespace SP.Repository
{
   public static  class RepositoryExtension
    {
        public static IEnumerable<dynamic> ExecuteSql<TEntity>(this BaseRepository<TEntity> baseRepository, string sqlMapKey, Dictionary<string, object> parameter = null) where TEntity : class, new() 
        {   
           
            var sql= baseRepository.sqlMap.GetSqlStatment(sqlMapKey);
            IEnumerable<dynamic> result;
            using (var conn = new MySqlConnection(baseRepository.sqlMap.SqlConnStr))
            {
                if (parameter == null)
                {
                   
                   result=  conn.Query(sql);
                }
                else
                {
                    var paramets = new DynamicParameters();
                    foreach (var key in parameter)
                    {
                        paramets.Add(key.Key, key.Value);
                    }
                    result= conn.Query(sql,parameter);
                }                         
            }
            return result;
        }
        public static  async Task< IEnumerable<dynamic>> ExecuteSqlAsync<TEntity>(this BaseRepository<TEntity> baseRepository ,string sqlMapKey = "", Dictionary<string, object> parameter =null) where TEntity : class,new()
        {
            var sql = baseRepository.sqlMap.GetSqlStatment(sqlMapKey);           
            using (var conn = new MySqlConnection(baseRepository.sqlMap.SqlConnStr))
            {
                if (parameter == null)
                {

                    return await conn.QueryAsync(sql);
                }
                else
                {
                    var paramets = new DynamicParameters();
                    foreach (var key in parameter)
                    {
                        paramets.Add(key.Key, key.Value);
                    }
                    return await conn.QueryAsync(sql, parameter);
                }
            }
          
           
        }
    }
}
