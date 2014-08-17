using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.AWS
{
    /// <summary>
    /// A structure representing a single event or an resolved link event.
    /// </summary>
    public class EventInfo : BasicEventInfo
    {
        public RecordedEvent Content { get; set; }
    }
}
