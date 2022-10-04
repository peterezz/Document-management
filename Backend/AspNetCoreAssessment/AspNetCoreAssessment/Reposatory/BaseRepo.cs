using AspNetCoreAssessment.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AspNetCoreAssessment.Reposatory
{
    public class BaseRepo<TEntity> where TEntity : class 
    {
        private readonly AspnetcoreassessmentContext context;
        protected DbSet<TEntity> DbSet;
        public BaseRepo(AspnetcoreassessmentContext context)
        {
            this.context = context;
            DbSet = context.Set<TEntity>();

        }
        public IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> entities = DbSet;
            return entities;
        }
        public virtual TEntity GetOne(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetMany(where, includeProperties).FirstOrDefault();
        }
        public virtual IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = where == null
                ? DbSet
                : DbSet.Where(where);
            var entities = includeProperties.Aggregate(query, (current, includeProperty) =>
                current.Include(includeProperty));


            return entities;
        }
        public TEntity Get<TKey>(TKey id)
        {
            return DbSet.Find(id);
        }
        public void Add(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Add(entity);

                Save();
            }
            catch (Exception e)
            {
                var s = e.Message;
                throw;
            }

        }
        public void Delete(int Id)
        {

            context.Remove(DbSet.Find(Id));

            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }
        public void Edit(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            Save();
        }
    }
    
    
}
