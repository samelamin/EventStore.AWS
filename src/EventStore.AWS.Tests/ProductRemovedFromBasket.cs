using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.AWS.Tests
{
    public class ProductRemovedFromBasket
    {
        public Guid ConversationId { get; set; }
        public long CustomerId { get; set; }
        public string Product { get; set; }
    }
}
