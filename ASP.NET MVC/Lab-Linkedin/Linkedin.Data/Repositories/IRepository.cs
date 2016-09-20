using System.Linq;

namespace Linkedin.Data.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        T Find(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T Delete(object id);
    }
}
