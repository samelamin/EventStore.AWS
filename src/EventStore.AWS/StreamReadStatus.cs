using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.AWS
{
    public enum StreamReadStatus
    {
        /// <summary>
        /// The read was successful.
        /// </summary>
        Success,
        /// <summary>
        /// The stream was not found.
        /// </summary>
        StreamNotFound,
        /// <summary>
        /// The stream has previously existed but is deleted.
        /// </summary>
        StreamDeleted
    }
}
