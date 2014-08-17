namespace EventStore.AWS.Tests
{
    using System;

    public class SampleOrder
    {
        public long OrderId { get; set; }

        public Guid ConversationId { get; set; }
    }
}