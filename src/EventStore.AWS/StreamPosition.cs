using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.AWS
{
    /// <summary>
    /// Constants for stream positions
    /// </summary>
    public static class StreamPosition
    {
        /// <summary>
        /// The first event in a stream
        /// </summary>
        public const int Start = 0;

        /// <summary>
        /// The last event in the stream.
        /// </summary>
        public const int End = -1;
    }
}
