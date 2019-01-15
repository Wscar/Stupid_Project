using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
namespace SP.Repository
{
   public interface IBaseRepository<T> where T:class
    {
        #region  异步方法
        /// <summary>
        /// 通过主键来获取实体对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<T> GetAsync(Expression<Func<T,bool>> expression);

        /// <summary>
        /// 获取所有实体对象
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetListAsync();

        /// <summary>
        /// 执行条件查询,(支支持等于,大于小于)
        /// </summary>
        /// <param name="whereCondition"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> whereCondition);

        /// <summary>
        /// 插入一条数据，并返回主键值
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> InsertAsync(T entity);

        /// <summary>
        ///  更新一条数据
        /// </summary>
        /// <param name="expressionCondition">where条件</param>
        /// <returns>受影响的行数</returns>
        Task<int> UpdateAsync(Expression<Func<T, bool>> expressionCondition);
        /// <summary>
        ///  更新一条数据
        /// </summary>
        /// <param name="expressionCondition">where条件</param>
        /// <returns>受影响的行数</returns>
        Task<int> UpdateAsync(T entity);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="experssionCondition">where条件</param>
        /// <returns>收影响的行数</returns>
        Task<int> DeleteAsync(Expression<Func<T, bool>> experssionCondition);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="experssionCondition">where条件</param>
        /// <returns>收影响的行数</returns>
        Task<int> DeleteAsync(T entity);
        Task<List<T>> GetPageAsync<TKey>(Expression<Func<T, bool>> experssionCondition, int pageIndex = 1, int pageSize = 20, Expression<Func<T, TKey>> orderBy=null);

        #endregion



        #region 同步方法
        /// <summary>
        /// 通过主键来获取实体对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get(Expression<Func<T,bool>> expression);

        /// <summary>
        /// 获取所有实体对象
        /// </summary>
        /// <returns></returns>
       IEnumerable<T> GetList();

        /// <summary>
        /// 执行条件查询,(支支持等于,大于小于)
        /// </summary>
        /// <param name="whereCondition"></param>
        /// <returns></returns>
        IEnumerable<T> GetList(Expression<Func<T, bool>> whereCondition);

        /// <summary>
        /// 插入一条数据，并返回主键值
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
         T Insert(T entity);

        /// <summary>
        ///  更新一条数据
        /// </summary>
        /// <param name="expressionCondition">where条件</param>
        /// <returns>受影响的行数</returns>
        int Update(Expression<Func<T, bool>> expressionCondition);


        /// <summary>
        ///  更新一条数据
        /// </summary>
        /// <param name="expressionCondition">where条件</param>
        /// <returns>受影响的行数</returns>
        int Update(T entity);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="experssionCondition">where条件</param>
        /// <returns>收影响的行数</returns>
        int Delete(Expression<Func<T, bool>> experssionCondition);
       
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="experssionCondition">where条件</param>
        /// <returns>收影响的行数</returns>
        int Delete(T entity);
        List<T> GetPage<TKey>(Expression<Func<T, bool>> experssionCondition, int pageIndex = 1, int pageSize = 20, Expression<Func<T, TKey>> orderBy = null);
        #endregion
    }
}
