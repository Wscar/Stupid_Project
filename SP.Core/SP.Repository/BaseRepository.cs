using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SP.Infrastructure;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SP.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private readonly SPDbcontext dbcontext;
        public BaseRepository(SPDbcontext _dbcontext)
        {
            dbcontext = _dbcontext;
           
        }
        public int Delete(Expression<Func<TEntity, bool>> experssionCondition)
        {
            throw new NotImplementedException();
        }

        public int Delete(TEntity entity)
        {
            dbcontext.Set<TEntity>().Remove(entity);
           int result=  dbcontext.SaveChanges();
            return result;
        }

        public Task<int> DeleteAsync(Expression<Func<TEntity, bool>> experssionCondition)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
           return  dbcontext.Set<TEntity>().FirstOrDefault(expression);
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return dbcontext.Set<TEntity>().FirstOrDefaultAsync(expression);
        }

        public IEnumerable<TEntity> GetList()
        {

            var allData = from t in dbcontext.Set<TEntity>() select t;
            return allData.ToList();
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> whereCondition)
        {
           return dbcontext.Set<TEntity>().Where(whereCondition);
        }

        public Task<IEnumerable<TEntity>> GetListAsync()
        {
           var result=  Task.Run(() =>
            {
                var allData = from t in dbcontext.Set<TEntity>() select t;
                return allData.ToList() as IEnumerable<TEntity>;
            }) ;
            return result;
        }

        public Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> whereCondition)
        {
           return Task.Run(() =>
            {

                return dbcontext.Set<TEntity>().Where(whereCondition).ToList() as IEnumerable<TEntity>;
            });
        }

        public TEntity Insert(TEntity entity)
        {
           var result= dbcontext.Set<TEntity>().Add(entity);
            dbcontext.SaveChanges();
            return result.Entity;
        }

        public Task<TEntity> InsertAsync(TEntity entity)
        {

          var result=  dbcontext.Set<TEntity>().AddAsync(entity).Result.Entity;
            dbcontext.SaveChangesAsync();
            return Task.FromResult<TEntity>(result);
        }

        public int Update(Expression<Func<TEntity, bool>> expressionCondition)
        {
            throw new NotImplementedException();
        }

        public int Update(TEntity entity)
        {
            var result = dbcontext.Set<TEntity>().Update(entity);
            return dbcontext.SaveChanges();
          
        }

        public Task<int> UpdateAsync(Expression<Func<TEntity, bool>> expressionCondition)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(TEntity entity)
        {
            dbcontext.Set<TEntity>().AddAsync(entity);
           return  dbcontext.SaveChangesAsync();          
        }
    }
}
