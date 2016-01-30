using System.Collections.Generic;

namespace Buls.Interfaces
{
    /// <summary>
    /// Defines properties that hold the data of an url split by specific type.
    /// </summary>
    public interface IRoute
    {
        /// <summary>
        /// Gets the controller name contained in the url.
        /// The controller name is usually a building block in a MVC architecture.
        /// </summary>
        string ControllerName { get; }

        /// <summary>
        /// Gets the action name contained in the url.
        /// The action name is usually a building block in a MVC architecture.
        /// </summary>
        string ActionName { get; }
        
        /// <summary>
        /// Represents a collection of keys and values that holds the data parameters of an url.
        /// E.g. password, username or other models containing information about the real-world object. 
        /// </summary>
        IDictionary<string, string> Parameters { get; }
    }
}
