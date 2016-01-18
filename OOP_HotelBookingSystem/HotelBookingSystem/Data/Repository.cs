using HotelBookingSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingSystem.Data
{
    public class Repository<T> : IRepository<T> where T : IDbEntity
    {
        private int nextAddId = 1;
        private Dictionary<int, T> items;

        public Repository()
        {
            //this.items = new Dictionary<int, T>(new DbEqualityComparer());
            this.items = new Dictionary<int, T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.items
                .OrderBy(item => item.Key)
                .Select(item => item.Value);
        }

        public virtual T Get(int id)
        {
            T item = default(T);
            try
            {
                item = this.items[id];
            }
            catch (KeyNotFoundException knfEx)
            {
                throw new KeyNotFoundException(knfEx.Message);
            }

            return item;
        }

        public virtual void Add(T item)
        {
            item.Id = this.nextAddId;
            this.items.Add(this.nextAddId, item);
            this.nextAddId++;
        }

        public virtual bool Update(int id, T newItem)
        {
            var item = this.Get(id);
            if (item == null)
            {
                throw new ArgumentException(string.Format("No item with id {0} in database", id));
            }

            item = newItem;
            return true;
        }

        public virtual bool Delete(int id)
        {
            return this.items.Remove(id);
        }
    }
}