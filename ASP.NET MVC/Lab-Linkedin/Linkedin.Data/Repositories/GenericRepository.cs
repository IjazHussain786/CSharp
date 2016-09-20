using System.Data.Entity;
using System.Linq;

namespace Linkedin.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private DbContext context;
        private IDbSet<T> set;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IDbSet<T> Set
        {
            get
            {
                return this.set;
            }
        }

        public void Add(T entity)
        {
            this.ChangeSate(entity, EntityState.Added);
        }

        public T Delete(object id)
        {
            var entity = this.Find(id);
            this.Delete(entity);

            return entity;
        }

        public void Delete(T entity)
        {
            this.ChangeSate(entity, EntityState.Deleted);
        }

        public T Find(object id)
        {
            return this.set.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return this.set;
        }

        public void Update(T entity)
        {
            this.ChangeSate(entity, EntityState.Modified);
        }

        private void ChangeSate(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}
