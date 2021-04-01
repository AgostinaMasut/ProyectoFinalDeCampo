using LolaApp.Core;
using LolaApp.Core.Attributes;
using LolaApp.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LolaApp.DataAccess.Concrete
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        private readonly DbSet<T> _entities;
        protected readonly DbContext _repositoryContext;

        protected RepositoryBase(DbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _entities = _repositoryContext.Set<T>();
        }

        public IEnumerable<T> FindAll()
        {
            return _entities.AsNoTracking();
        }


        public T Create(T entity)
        {
            _entities.Add(entity);
            _repositoryContext.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
             
            var entry = _repositoryContext.Entry(entity);
            if (entry.State == EntityState.Unchanged)
            {

                return entity;
            }

            if (entry.State == EntityState.Detached)
            {
                //entry = _repositoryContext.Entry(_repositoryContext.Set<T>._Attach(entity));
                entry.State = EntityState.Modified;
            }
            _repositoryContext.SaveChanges();
            return entity;
        }

        public virtual void Delete(T entity)
        {
            _entities.Remove(entity);
            _repositoryContext.SaveChanges();
        }

        public T GetById(int id)
        {
            return _entities.Find(id);
        }

        public T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            return FindBy(@where, navigationProperties).FirstOrDefault();
        }

        public IEnumerable<T> SqlQuery(string sql, params object[] parameters)
        {            
            var result = _entities.SqlQuery(sql, parameters).AsNoTracking().AsEnumerable();
            return result;
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> expression)
        {
            return _entities.Where(expression).AsNoTracking();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] navigationProperties)
        {
            return navigationProperties.Aggregate(_entities.Where(where), (current, property) => current.Include(property)).AsNoTracking();
        }

        public void UpdateArray(IEnumerable<T> items)
        {
            _entities.RemoveRange(items);
            _repositoryContext.SaveChanges();
        }

        public void DeleteArray(IEnumerable<T> items)
        {
            _entities.RemoveRange(items);
            _repositoryContext.SaveChanges();
        }

        public void InsertArray(IEnumerable<T> items)
        {
            _entities.AddRange(items);
            _repositoryContext.SaveChanges();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> @where)
        {
            return FindBy(@where).FirstOrDefault();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] navigationProperties)
        {
            return FindBy(@where, navigationProperties).FirstOrDefault();
        }


        public virtual T Upsert(T entity, Expression<Func<T, bool>> @where)
        {
            var oldEntity = FirstOrDefault(@where);
            if (oldEntity != default(T))
            {
                var pi = GetPKValue(oldEntity, out dynamic pkValue);
                if (pi != null && pkValue != null)
                {
                    pi.SetValue(entity, pkValue);
                    return Update(entity);
                }

            }
            return InternalUpsertByPK(entity);
        }

        public virtual T Upsert(T entity, Expression<Func<T, bool>> @where, params Expression<Func<T, object>>[] navigationProperties)
        {
            var oldEntity = FirstOrDefault(@where, navigationProperties);
            if (oldEntity != default(T))
            {
                var pi = GetPKValue(oldEntity, out dynamic pkValue);
                if (pi != null && pkValue != null)
                {
                    pi.SetValue(entity, pkValue);
                    return Update(entity);
                }

            }
            return InternalUpsertByPK(entity);
        }


        public virtual T Upsert(T entity)
        {
            var props = entity.GetType().GetProperties().Where(x => x.GetCustomAttribute<UpsertItemAttribute>(true) != null).ToArray();
            if (props.Any())
            {
                var tableAtt = entity.GetType().GetCustomAttributes(typeof(TableAttribute)).FirstOrDefault() as TableAttribute;

                var sqlStatement = $"Select TOP 1 * from {tableAtt?.Name ?? typeof(T).Name} where ";
                var popLength = props.Count();
                for (var i = 0; i < popLength; i++)
                {
                    string name;
                    var ca = props[i].GetCustomAttributes(typeof(ColumnAttribute));
                    if (ca.Any())
                    {
                        ColumnAttribute attribute = ca.FirstOrDefault() as ColumnAttribute;
                        name = attribute.Name;

                    }
                    else
                    {
                        name = props[i].Name;
                    }
                    sqlStatement += $" [{name}] = @p{i} AND";
                }

                sqlStatement = sqlStatement.Substring(0,sqlStatement.Length-3);
                var valuesArray = props.Select(x => x.GetValue(entity)).ToArray();
                var resultSet = SqlQuery(sqlStatement, valuesArray).ToArray();
                if (resultSet.Any())
                {
                    var pi = GetPKValue(entity, out dynamic pkValue);
                    if (pi != null && pkValue != null)
                    {
                        if (pkValue == 0)
                        {
                            pi = GetPKValue(resultSet.FirstOrDefault(), out pkValue);
                            if (pi != null && pkValue != null)
                            {
                                pi.SetValue(entity, pkValue);
                            }
                        }
                        return Update(entity);
                    }
                }
            }

            return Create(entity);
        }

        private T InternalUpsertByPK(T entity)
        {
            var newEntity = InternalCreateIfPkIsNull(entity);
            return newEntity ?? Update(entity);
        }

        private T InternalCreateIfPkIsNull(T entity)
        {
            GetPKValue(entity, out dynamic value);
            if (value == null || value == 0)
            {
                var props = entity.GetType().GetProperties().Where(x => x.GetCustomAttribute<ForeignKeyAttribute>(true) != null).ToArray();
                foreach (var propertyInfo in props)
                {
                    propertyInfo.SetValue(entity, null);
                }
                return Create(entity);
            }
            return null;
        }

        private PropertyInfo GetPKValue(T entity, out dynamic pkValue)
        {
            var prop = entity.GetType().GetProperties().FirstOrDefault(x => x.GetCustomAttribute<KeyAttribute>(true) != null);
            if (prop == null)
            {
                pkValue = null;
                return null;
            }
            pkValue = prop.GetValue(entity);
            return prop;
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            return _entities.Any(where);
        }

        public bool Any(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            return FindBy(where, navigationProperties).Any();
        }
    }
}
