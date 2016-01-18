using System.Collections.Generic;

namespace HotelBookingSystem.Interfaces
{
    /// <summary>
    /// Defines a set of methods for extracting and manipulating data in a database.
    /// The type of values in the database is generic.
    /// </summary>
    /// <typeparam name="T">The generic type of values in the database.</typeparam>
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T item);
        bool Update(int id, T newItem);
        bool Delete(int id);
    }
}
