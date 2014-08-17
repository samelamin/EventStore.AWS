using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.AWS
{
    public class EventReadResult
    {
        /// <summary>
        /// The <see cref="EventReadStatus"/> representing the status of this read attempt
        /// </summary>
        public readonly EventReadStatus Status;

        /// <summary>
        /// The name of the stream read
        /// </summary>
        public readonly string Stream;

        /// <summary>
        /// The event number of the requested event.
        /// </summary>
        public readonly int SequenceNumber;

        /// <summary>
        /// The event read represented as an <see cref="EventInfo"/>
        /// </summary>
        public readonly EventInfo EventInfo;

        public EventReadResult(EventReadStatus status, string stream, int sequenceNumber, EventInfo eventInfo)
        {
            Status = status;
            Stream = stream;
            SequenceNumber = sequenceNumber;
            EventInfo = eventInfo;
        }
    }
}
