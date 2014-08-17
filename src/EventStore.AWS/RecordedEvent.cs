using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.AWS
{
    using Newtonsoft.Json.Linq;

    public struct RecordedEvent
    {
        public string EventStreamId { get; set; }
        public long EventNumber { get; set; }
        public string EventType { get; set; }
        public JToken Data { get; set; }

        public T GetObject<T>() where T : class
        {
            if (Data == null)
            {
                return null;
            }

            return Data.ToObject<T>();
        }
    }
}
