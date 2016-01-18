using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Data
{
    /// <summary>
    /// Defines customized equality comparison for collections that include database entities.
    /// </summary>
    internal class DbEqualityComparer : IEqualityComparer<int>
    {
        /// <summary>
        /// Compares two database entities by their ID values.
        /// </summary>
        public bool Equals(int dbIDItem1, int dbIDItem2)
        {
            bool areItemsEqual = (dbIDItem1 == dbIDItem2);
            return areItemsEqual;
        }

        public int GetHashCode(int obj)
        {
            return obj % 10;
        }
    }
}
