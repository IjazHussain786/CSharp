using System.Collections.Generic;

namespace Buls.Interfaces
{
    /// <summary>
    /// Defines a set of methods for extracting and manipulating data in a repository(database).
    /// The type of values in the repository is generic.
    /// </summary>
    /// <typeparam name="T">The generic type of values in the repository.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Extracts all items contained in the repository.
        /// </summary>
        /// <returns>The extracted items are returned as a collection, 
        /// which supports a simple iteration.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets the number of elements contained in the repository.
        /// </summary>
        int Count { get; }
        
        T Get(int id);
        
        /// <summary>
        /// Adds an object to the end of the repository.
        /// </summary>
        /// <param name="item">The generic type item which is to be added</param>
        void Add(T item);
    }
}
