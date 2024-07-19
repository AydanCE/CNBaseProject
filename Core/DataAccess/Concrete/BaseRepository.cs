using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete
{
    public class BaseRepository<TEntity, TContext> : IBaseReposiroty<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addEntity = context.Entry(entity);//sql deki table ile elaqe
                addEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using(TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using(TContext context = new TContext())
            {
                return filter != null ? context.Set<TEntity>().Where(filter).ToList() : context.Set<TEntity>().ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using(TContext context = new TContext())
            {
                var modifyEntity = context.Entry(entity);
                modifyEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
