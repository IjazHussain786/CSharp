using System;
using System.Collections.Generic;
using Huy_Phuong.Models;

namespace Huy_Phuong.Interfaces
{
    /// <summary>
    /// Defines a set of methods for storing IPerformance data types, as well as extracting/adding them 
    /// from/to the existing database.
    /// </summary>
    public interface IPerformanceDatabase
    {
        /// <summary>
        /// Adds a theatre to the Performance database.
        /// </summary>
        /// <param name="theatreName">The name of the theatre, where the performances take place.
        /// Each performance should have a theatre as a property.</param>
        /// <exception cref="TheatreNotFoundException">Thrown in case of duplicate theatre. 
        /// Holds a "Duplicate theatre" as error message.</exception>
        void AddTheatre(string theatreName);

        /// <summary>
        /// Extracts all theatres from the Performance database ordered by name.
        /// </summary>
        /// <returns>Returns a collection of all theatre names.</returns>
        IEnumerable<string> ListTheatres();

        /// <summary>
        /// Adds an object of type IPerformance to the Performance database.
        /// The performance cannot overlap with another performance in the same theatre.
        /// </summary>
        /// <param name="theatreName">The name of the theatre, where the performances take place.</param>
        /// <param name="performanceTitle">The name of the performance.</param>
        /// <param name="startDateTime">Starting date and time of the performance.</param>
        /// <param name="duration">Duration of the performance.</param>
        /// <param name="price">Ticket price of the performance.</param>
        ///<exception cref="TheatreNotFoundException">Thrown with message "Theatre does not exist"
        /// in case of non-existing theatre.</exception>
        /// <exception cref="TimeDurationOverlapException">Thrown with message "Time/duration overlap"
        /// in case of the time interval overlaps with another performance time interval
        /// in the same theatre.</exception>
        void AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price);

        /// <summary>
        /// Extracts all performances from the Performance database ordered by theatre first 
        /// and by starting date and time as second condition.
        /// </summary>
        /// <returns>Returns a collection of all objects of type IPerformance.</returns>
        IEnumerable<IPerformance> ListAllPerformances();

        /// <summary>
        /// Lists all performances from specified theatre ordered by performance date and time.
        /// </summary>
        /// <param name="theatreName">The name of the theatre</param>
        /// <returns>A sequence of all performances for the specified theatre</returns>
        /// <exception cref="TheatreNotFoundException">Thrown with message "Theatre does not exist"
        /// in case of non-existing theatre.</exception>
        IEnumerable<IPerformance> ListPerformances(string theatreName);
    }
}
