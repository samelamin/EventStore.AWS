namespace EventStore.AWS.Tests
{
    using System;
    using System.Collections.Generic;

    public class OrderCreated
    {
        public Guid ConversationId { get; set; }

        public long CustomerId { get; set; }

        public long OrderId { get; set; }

        public decimal Amount { get; set; }

        public string Resturant { get; set; }

        public List<string> ProductList { get; set; }
    }
}