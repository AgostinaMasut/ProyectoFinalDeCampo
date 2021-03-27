using LolaApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LolaApp.Services.Abstractions
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        T Create( T entity);
        T Update( T entity);
        void Delete( T entity);
        T GetById(int id);
        T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        IEnumerable<T> FindAll();               
        IEnumerable<T> FindBy(Expression<Func<T, bool>> expression);        
        IEnumerable<T> FindBy(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] navigationProperties);
        IEnumerable<T> SqlQuery(string sql, params object[] parameters);
        void UpdateArray(IEnumerable<T> items);
        void DeleteArray(IEnumerable<T> items);
        void InsertArray(IEnumerable<T> items);
        T FirstOrDefault(Expression<Func<T, bool>> @where);
        T FirstOrDefault(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] navigationProperties);
        T Upsert(T entity, Expression<Func<T, bool>> @where);
        T Upsert(T entity, Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] navigationProperties);
        T Upsert(T entity);
        bool Any(Expression<Func<T, bool>> @where);
        bool Any(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] navigationProperties);
    }
}
