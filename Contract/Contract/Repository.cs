using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Contract
{
    public abstract class Repository<TContext, T, TKey>
       where TContext : DbContext
        where T : class, new()
    {
        protected TContext Context { get; private set; }

        protected abstract DbSet<T> DbSet { get; }

        public Repository(TContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            Context = context;
        }

        #region Creation

        public void Add(T entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();
        }

        public void AddRange(List<T> entities)
        {
            DbSet.AddRange(entities);
            Context.SaveChanges();
        }

        #endregion

        #region Retrieval

        public T Get(TKey id)
        {
            return DbSet.Find(id);
        }

        public List<T> GetAll()
        {
            return DbSet.ToList();
        }

        #endregion

        #region Update

        public void Update(T entity)
        {
            Context.SaveChanges();
        }

        #endregion

        #region Deletion

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
            Context.SaveChanges();
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            var targets = FindAll(expression);
            if (targets.Count > 0)
            {
                DbSet.RemoveRange(targets);
                Context.SaveChanges();
            }
        }

        #endregion

        #region Search

        public T Find(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            return FindAll(expression).FirstOrDefault();
        }

        public List<T> FindAll(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            var query = DbSet.Where(expression);
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query.Include(include);
                }
            }
            return query.ToList();
        }



        #endregion

        #region Aggregation

        public int Count()
        {
            return DbSet.Count();
        }

        public int Count(Expression<Func<T, bool>> expression)
        {
            return DbSet.Count(expression);
        }

        #endregion
     
    }
}
