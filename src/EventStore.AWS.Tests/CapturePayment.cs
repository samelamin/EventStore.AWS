namespace EventStore.AWS.Tests
{
    using System;

    public class CapturePayment
    {
        public Guid ConversationId { get; set; }

        public long OrderId { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }
    }
}