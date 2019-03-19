using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SP.Infrastructure;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Dapper;
using MySql.Data.MySqlClient;
namespace SP.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private readonly SPDbcontext dbcontext;
        public readonly SqlMap sqlMap;
        public BaseRepository(SPDbcontext _dbcontext, SqlMap _sqlMap)
        {
            dbcontext = _dbcontext;
            sqlMap = _sqlMap;
           
        }
        public virtual int Delete(Expression<Func<TEntity, bool>> experssionCondition)
        {
            throw new NotImplementedException();
        }

        public virtual int Delete(TEntity entity)
        {
            dbcontext.Set<TEntity>().Remove(entity);
           int result=  dbcontext.SaveChanges();
            return result;
        }

        public virtual Task<int> DeleteAsync(Expression<Func<TEntity, bool>> experssionCondition)
        {
            throw new NotImplementedException();
        }

        public virtual Task<int> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
           return  dbcontext.Set<TEntity>().FirstOrDefault(expression);
        }

        public virtual Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return dbcontext.Set<TEntity>().FirstOrDefaultAsync(expression);
        }

        public virtual IEnumerable<TEntity> GetList()
        {

            var allData = from t in dbcontext.Set<TEntity>() select t;
            return allData.ToList();
        }

        public virtual IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> whereCondition)
        {
           return dbcontext.Set<TEntity>().Where(whereCondition);
        }

        public virtual Task<IEnumerable<TEntity>> GetListAsync()
        {
           var result=  Task.Run(() =>
            {
                var allData = from t in dbcontext.Set<TEntity>() select t;
                return allData.ToList() as IEnumerable<TEntity>;
            }) ;
            return result;
        }

        public virtual Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> whereCondition)
        {
           return Task.Run(() =>
            {

                return dbcontext.Set<TEntity>().Where(whereCondition).ToList() as IEnumerable<TEntity>;
            });
        }

        public virtual List<TEntity> GetPage<TKey>(Expression<Func<TEntity, bool>> experssionCondition, int pageIndex = 1, int pageSize = 20, Expression<Func<TEntity, TKey>> orderBy = null)
        {
            return  dbcontext.Set<TEntity>().Where(experssionCondition).Skip(pageSize * (pageIndex - 1)).Take(pageSize).OrderByDescending(orderBy).ToList();
        }

        public virtual Task<List<TEntity>> GetPageAsync<TKey>(Expression<Func<TEntity, bool>> experssionCondition, int pageIndex = 1, int pageSize = 20, Expression<Func<TEntity, TKey>> orderBy = null)
        {
            return Task.Run(() =>
            {
               return  dbcontext.Set<TEntity>().Where(experssionCondition).Skip(pageSize * (pageIndex - 1)).Take(pageSize).OrderByDescending(orderBy).ToList();
            });
        }

        public virtual TEntity Insert(TEntity entity)
        {
           var result= dbcontext.Set<TEntity>().Add(entity);
            dbcontext.SaveChanges();
            return result.Entity;
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {

            var result = await dbcontext.Set<TEntity>().AddAsync(entity);
            var affectedRowCount=  await dbcontext.SaveChangesAsync();
            if (affectedRowCount >= 0)
            {
                return result.Entity;
            }
            else
            {
                return null;
            }
           
        }

        public virtual int Update(Expression<Func<TEntity, bool>> expressionCondition)
        {
            throw new NotImplementedException();
        }

        public virtual int Update(TEntity entity)
        {
            var result = dbcontext.Set<TEntity>().Update(entity);
            return dbcontext.SaveChanges();
          
        }

        public virtual int Update(string mapName, Dictionary<string, object> parmas)
        {
            using(MySqlConnection conn=new MySqlConnection(sqlMap.SqlConnStr))
            {
                var paramets = new DynamicParameters();
                foreach(KeyValuePair<string,object> key in parmas)
                {
                    paramets.Add(key.Key, key.Value);
                }
                var result= conn.Execute(sqlMap.GetSqlStatment(mapName));
                return result;
            }
        }

        public virtual Task<int> UpdateAsync(Expression<Func<TEntity, bool>> expressionCondition)
        {
            return null;
        }

        public virtual Task<int> UpdateAsync(TEntity entity)
        {
            dbcontext.Set<TEntity>().AddAsync(entity);
           return  dbcontext.SaveChangesAsync();          
        }

        public virtual async Task<int> UpdateAsync(string mapName, Dictionary<string, object> parmas)
        {
            using (MySqlConnection conn = new MySqlConnection(sqlMap.SqlConnStr))
            {
                var paramets = new DynamicParameters();
                foreach (KeyValuePair<string, object> key in parmas)
                {
                    paramets.Add(key.Key, key.Value);
                }
                var sql = sqlMap.GetSqlStatment(mapName);
                var result = await conn.ExecuteAsync(sql,paramets);
                return result;
            }
        }
    }
}
