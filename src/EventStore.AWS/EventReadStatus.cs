using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.AWS
{
    public enum EventReadStatus
    {
        /// <summary>
        /// The read operation was successful.
        /// </summary>
        Success = 0,
        /// <summary>
        /// The event was not found.
        /// </summary>
        NotFound = 1,
        /// <summary>
        /// The stream previously existed but was deleted.
        /// </summary>
        StreamDeleted = 3,
    }
}
