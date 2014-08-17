namespace EventStore.AWS.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    using NUnit.Framework;

    [TestFixture]
    public class ClientTestsSetUp
    {
        protected const string ProductAddedToBasketStreamName = "ProductAddedToBasket";

        protected const string ProductRemovedFromBasketStreamName = "ProductRemovedFromBasket";

        protected const string CustomerCheckedOutStreamName = "CustomerCheckedOut";

        protected const string OrderCreatedStreamName = "OrderCreated";

        protected const string CapturePaymentStreamName = "CapturePayment";

        protected const string PaymentCapturedStreamName = "PaymentCaptured";

        protected const string OrderDeliveredStreamName = "OrderDelivered";

        protected IEventStoreHttpConnection Connection;

        [SetUp]
        public void Setup()
        {

            Connection = EventStoreHttpConnection.Create(ConnectionSettings.Default, "http://10.212.101.125:1113"); 
            //Connection = EventStoreHttpConnection.Create(ConnectionSettings.Default, "http://127.0.0.1:1113"); 
        }

        protected void LoadFakeEvents()
        {
            List<SampleOrder> sampleOrders = new List<SampleOrder>();

            Random rand = new Random(Int32.MinValue);

            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });
            sampleOrders.Add(new SampleOrder() { ConversationId = Guid.NewGuid(), OrderId = rand.Next() });

            InsertAddedToBasket(sampleOrders, "Pizza");
            System.Threading.Thread.Sleep(1000);

            InsertAddedToBasket(sampleOrders, "Burger");
            System.Threading.Thread.Sleep(1000);

            InsertAddedToBasket(sampleOrders, "Chips");
            System.Threading.Thread.Sleep(1000);

            InsertAddedToBasket(sampleOrders, "Curry");
            System.Threading.Thread.Sleep(1000);

            InsertRemovedToBasket(sampleOrders, "Curry");
            System.Threading.Thread.Sleep(1000);

            InsertCustomerCheckedOut(sampleOrders);
            System.Threading.Thread.Sleep(1000);

            InsertOrderCreated(sampleOrders);
            System.Threading.Thread.Sleep(1000);

            InsertCapturePayment(sampleOrders);
            System.Threading.Thread.Sleep(1000);

            InsertPaymentCaptured(sampleOrders);
            System.Threading.Thread.Sleep(1000);

            InsertOrderDelivered(sampleOrders);
        }

        async Task InsertAddedToBasket(IEnumerable<SampleOrder> sampleOrders, string product)
        {
            foreach (SampleOrder sampleOrder in sampleOrders)
            {
                ProductAddedToBasked d = new ProductAddedToBasked
                {
                    ConversationId = sampleOrder.ConversationId,
                    CustomerId = sampleOrder.OrderId + 1000,
                    Product = product,
                };

                NewEventData @event = NewEventData.Create(d);

                await Connection.AppendToStreamAsync(ProductAddedToBasketStreamName, ExpectedVersion.Any, @event);
            }
        }

        async Task InsertRemovedToBasket(IEnumerable<SampleOrder> sampleOrders, string product)
        {
            foreach (SampleOrder sampleOrder in sampleOrders)
            {
                ProductRemovedFromBasket d = new ProductRemovedFromBasket
                {
                    ConversationId = sampleOrder.ConversationId,
                    CustomerId = sampleOrder.OrderId + 1000,
                    Product = product,
                };

                NewEventData @event = NewEventData.Create(d);

                await Connection.AppendToStreamAsync(ProductRemovedFromBasketStreamName, ExpectedVersion.Any, @event);
            }
        }

        async Task InsertCustomerCheckedOut(IEnumerable<SampleOrder> sampleOrders)
        {
            List<string> products = new List<string>();
            products.Add("Burger");
            products.Add("Pizza");
            products.Add("Drinks");

            foreach (SampleOrder sampleOrder in sampleOrders)
            {
                CustomerCheckedOut d = new CustomerCheckedOut
                {
                    ConversationId = sampleOrder.ConversationId,
                    Amount = 25m,
                    ProductList = products,
                    CustomerId = sampleOrder.OrderId + 1000,
                    OrderId = sampleOrder.OrderId
                };

                NewEventData @event = NewEventData.Create(d);

                await Connection.AppendToStreamAsync(CustomerCheckedOutStreamName, ExpectedVersion.Any, @event);
            }
        }

        async Task InsertOrderCreated(IEnumerable<SampleOrder> sampleOrders)
        {
            List<string> products = new List<string>();
            products.Add("Burger");
            products.Add("Pizza");
            products.Add("Drinks");

            foreach (SampleOrder sampleOrder in sampleOrders)
            {
                OrderCreated d = new OrderCreated
                {
                    ConversationId = sampleOrder.ConversationId,
                    Amount = 25m,
                    ProductList = products,
                    CustomerId = sampleOrder.OrderId + 1000,
                    OrderId = sampleOrder.OrderId
                };

                NewEventData @event = NewEventData.Create(d);

                await Connection.AppendToStreamAsync(OrderCreatedStreamName, ExpectedVersion.Any, @event);
            }
        }

        async Task InsertCapturePayment(IEnumerable<SampleOrder> sampleOrders)
        {
            foreach (SampleOrder sampleOrder in sampleOrders)
            {
                CapturePayment d = new CapturePayment
                {
                    ConversationId = sampleOrder.ConversationId,
                    Amount = 25m,
                    OrderId = sampleOrder.OrderId,
                    Currency = "GBP"
                };

                NewEventData @event = NewEventData.Create(d);

                await Connection.AppendToStreamAsync(CapturePaymentStreamName, ExpectedVersion.Any, @event);
            }
        }

        async Task InsertPaymentCaptured(IEnumerable<SampleOrder> sampleOrders)
        {
            foreach (SampleOrder sampleOrder in sampleOrders)
            {
                PaymentCaptured d = new PaymentCaptured
                {
                    ConversationId = sampleOrder.ConversationId,
                    Amount = 25m,
                    OrderId = sampleOrder.OrderId,
                    Currency = "GBP"
                };

                NewEventData @event = NewEventData.Create(d);

                await Connection.AppendToStreamAsync(PaymentCapturedStreamName, ExpectedVersion.Any, @event);
            }
        }

        async Task InsertOrderDelivered(IEnumerable<SampleOrder> sampleOrders)
        {
            foreach (SampleOrder sampleOrder in sampleOrders)
            {
                OrderDelivered d = new OrderDelivered
                {
                    ConversationId = sampleOrder.ConversationId,
                    OrderId = sampleOrder.OrderId,
                };

                NewEventData @event = NewEventData.Create(d);

                await Connection.AppendToStreamAsync(OrderDeliveredStreamName, ExpectedVersion.Any, @event);
            }
        }

        async Task InsertRefundOrder(long orderId, decimal amount, Guid conversationId)
        {
            RefundOrder refundOrder = new RefundOrder();
            refundOrder.OrderId = orderId;
            refundOrder.Amount = amount;
            refundOrder.ConversationId = conversationId;

            NewEventData @event = NewEventData.Create(refundOrder);

            await Connection.AppendToStreamAsync(OrderDeliveredStreamName, ExpectedVersion.Any, @event);
        }

        //[Test]
        //public async void ListForwards()
        //{
        //    StreamEventsSlice @event = await Connection.ReadStreamEventsForwardAsync(OrderCreatedStreamName, 10, 5);
        //}
    }
}