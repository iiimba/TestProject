using System.Collections.Generic;
using System.Linq;

namespace DataApp.Models
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(long id);

        IEnumerable<T> GetAll();

        void Create(T newObject);

        void Update(T changedObject);

        void Delete(long id);
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DataContext context;

        public GenericRepository(DataContext context)
        {
            this.context = context;
        }

        public virtual T Get(long id)
        {
            var obj = this.context.Set<T>().Find(id);
            return obj;
        }

        public virtual IEnumerable<T> GetAll()
        {
            var objects = this.context.Set<T>().ToList();
            return objects;
        }

        public virtual void Create(T newObject)
        {
            this.context.Add(newObject);
            this.context.SaveChanges();
        }

        public virtual void Update(T changedObject)
        {
            this.context.Update(changedObject);
            this.context.SaveChanges();
        }

        public virtual void Delete(long id)
        {
            this.context.Remove(this.Get(id));
            this.context.SaveChanges();
        }
    }
}
