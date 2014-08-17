namespace EventStore.AWS.Tests
{
    using System;

    public class OrderDelivered
    {
        public Guid ConversationId { get; set; }

        public long OrderId { get; set; }
    }
}