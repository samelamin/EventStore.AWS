namespace EventStore.AWS.Tests
{

    using NUnit.Framework;

    public class ClientTests : ClientTestsSetUp
    {
        [SetUp]
        public void Setup()
        {
            LoadFakeEvents();
        }

        [Test]
        public async void Retrieve()
        {
            EventReadResult event1 = await Connection.ReadEventAsync(OrderCreatedStreamName, 4);

            EventReadResult event2 = await Connection.ReadEventAsync(OrderCreatedStreamName, 6);
        }

        [Test]
        public async void RefndOrder()
        {
            //InsertRefundOrder(1559595546, 25m, new Guid("acdff778-e335-4bd0-a9e9-e681ac0c47bf"));
        }
    }
}