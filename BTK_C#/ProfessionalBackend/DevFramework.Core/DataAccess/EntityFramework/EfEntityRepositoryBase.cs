﻿using System.Data.Entity;
using System.Linq.Expressions;
using DevFramework.Core.Entities;

namespace DevFramework.Core.DataAccess.EntityFramework;

public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity> 
    where TEntity :class,IEntity, new()
    where TContext : DbContext, new()
{
    public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
    {
        using (var context = new TContext())
        {
            return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
        }
    }

    public TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
        using (var context = new TContext())
        {
            return context.Set<TEntity>().SingleOrDefault(filter);
        }
    }

    public TEntity Add(TEntity entity)
    {
        using (var context = new TContext())
        {
            var addedEntry = context.Entry(entity);
            addedEntry.State = EntityState.Added;
            context.SaveChanges();
            return entity;
        }
    }

    public TEntity Update(TEntity entity)
    {
        using (var context = new TContext())
        {
            var updatedEntry = context.Entry(entity);
            updatedEntry.State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }
    }

    public void Delete(TEntity entity)
    {
        using (var context = new TContext())
        {
            var deletedEntry = context.Entry(entity);
            deletedEntry.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}