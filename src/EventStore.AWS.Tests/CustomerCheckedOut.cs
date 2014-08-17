using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.AWS.Tests
{

    public class CustomerCheckedOut
    {
        public Guid ConversationId { get; set; }

        public long CustomerId { get; set; }

        public long OrderId { get; set; }

        public decimal Amount { get; set; }

        public string Resturant { get; set; }

        public List<string> ProductList { get; set; }
    }
}
