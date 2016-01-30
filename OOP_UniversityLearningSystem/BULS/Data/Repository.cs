using System;
using System.Collections.Generic;
using Buls.Interfaces;

namespace Buls.Data
{    
    public class Repository<T> : IRepository<T>
    {
        private List<T> items;

        public Repository()
        {
            this.items = new List<T>();
        }

        public int Count 
        { 
            get 
            { 
                return this.items.Count; 
            } 
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.items;
        }

        public virtual T Get(int id)
        {
            T item;
            try
            {
                item = this.items[id - 1];
            }
            catch (ArgumentOutOfRangeException)
            {
                item = default(T);
                throw new ArgumentException(string.Format("There is no course with ID {0}.", id));
            }

            return item;
        }

        public virtual void Add(T item)
        {
            this.items.Add(item);
        }
    }
}