using Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository2.Implementations
{
    public class GenericRepository<TEntitiy> where TEntitiy : class
    {
        internal RestaurantSystemDBContext context;
        internal DbSet<TEntitiy> dbSet;

        // Constructor 
        public GenericRepository(RestaurantSystemDBContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntitiy>();
        }

        //Getting list of entities with filter and orderby
        public virtual IEnumerable<TEntitiy> Get(
            Expression<Func<TEntitiy, bool>> filter = null,
            Func<IQueryable<TEntitiy>, IOrderedQueryable<TEntitiy>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntitiy> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual List<TEntitiy> GetByQuery(Expression<Func<TEntitiy, bool>> filter = null, Func<IQueryable<TEntitiy>, IOrderedQueryable<TEntitiy>> orderBy = null, params Expression<Func<TEntitiy, object>>[] includes)
        {
            IQueryable<TEntitiy> query = dbSet;

            foreach (Expression<Func<TEntitiy, object>> include in includes)
            {
                query = query.Include(include);
            }

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        // Get entity by id
        public virtual TEntitiy GetByID(object id)
        {
            return dbSet.Find(id);
        }

        // insert entity 
        public virtual void Insert(TEntitiy entity)
        {
            dbSet.Add(entity);
        }

        // delete entity with id
        public virtual void Delete(object id)
        {
            TEntitiy entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        // delete entity with whole object
        public virtual void Delete(TEntitiy entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        // update entity
        public virtual void Update(TEntitiy entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

    }
}