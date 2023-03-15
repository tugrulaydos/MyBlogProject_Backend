using Infrastructure.DataAccess.Abstract;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Concrete
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity:class,IEntity,new()
        where TContext:DbContext, new()
    {
        public int Delete(TEntity entity)
        {
            using(TContext context = new TContext()) 
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                return context.SaveChanges();          
                
            }
            
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression, params string[] includeList)
        {
            using(TContext context = new TContext()) 
            {
                IQueryable<TEntity> dbSet = context.Set<TEntity>();
                if (expression != null)
                {
                    dbSet = dbSet.Where(expression);
                }

                if (includeList != null)
                {
                    foreach (var item in includeList) 
                    {
                        dbSet = dbSet.Include(item);
                    }
                }

                return dbSet.SingleOrDefault(expression);
               
            }
            
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null, params string[] includeList)
        {
            using(TContext context = new TContext()) 
            {
                IQueryable<TEntity> dbSet = context.Set<TEntity>();

                if (expression != null) 
                {
                   dbSet = dbSet.Where(expression);
                }

                if (includeList != null) 
                {
                    foreach(var item in includeList)
                    {
                        dbSet = dbSet.Include(item);
                    }
                }

                return dbSet.ToList();
            }
           
        }

        public TEntity Insert(TEntity entity)
        {
            using(TContext context = new TContext()) 
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return addedEntity.Entity;
            }
            
        }

        public int Update(TEntity entity)
        {
            using(TContext context = new TContext()) 
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                return context.SaveChanges();
            }
        }
    }
}
