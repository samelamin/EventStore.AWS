using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.AWS.Tests
{
    public class RefundOrder
    {
        public Guid ConversationId { get; set; }
        public long OrderId { get; set; }
        public decimal Amount { get; set; }
    }
}
