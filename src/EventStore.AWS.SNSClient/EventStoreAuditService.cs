using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Amazon.SQS;
using Amazon.SQS.Model;
using log4net;
using Newtonsoft.Json.Linq;
using Timer = System.Timers.Timer;

namespace EventStore.AWS.SNSClient
{
    public class EventStoreAuditService
    {
        private readonly IEventStoreHttpConnection _eventStore;
        private readonly string _eventStoreQueueUrl;
        private readonly AmazonSQSClient _sqsClient;
        private readonly TopicSubscriberService _subscriberService;
        private readonly Timer _timer;

        public EventStoreAuditService(TopicSubscriberService subscriberService, AmazonSQSClient sqsClient, ISettings settings)
        {
            _subscriberService = subscriberService;
            _eventStore = EventStoreHttpConnection.Create(ConnectionSettings.Default, 
                string.Format("http://{0}:{1}", settings.Address, settings.HttpPort));
            
            _sqsClient = sqsClient;
            _eventStoreQueueUrl = settings.QueueUrl;

            _timer = new Timer
            {
                AutoReset = true,
                Interval = settings.TimeSpanPolling.TotalMilliseconds
            };

            _timer.Elapsed += SubscriptionTimeoutElapsed;
            _timer.Start();
        }

        private void SubscriptionTimeoutElapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            _subscriberService.SubscribeToAllTopics();
            _timer.Start();
        }

        public void PollQueues()
        {
            while (true)
            {
                _subscriberService.SubscribeToAllTopics();

                var rmr = new ReceiveMessageRequest {QueueUrl = _eventStoreQueueUrl, MaxNumberOfMessages = 10,};
                ReceiveMessageResponse response = _sqsClient.ReceiveMessage(rmr);
                foreach (Message message in response.ReceiveMessageResult.Messages)
                {
                    dynamic token = JObject.Parse(message.Body);
                    SaveToEventStore(token);
                    _sqsClient.DeleteMessage(new DeleteMessageRequest {QueueUrl = _eventStoreQueueUrl, ReceiptHandle = message.ReceiptHandle});
                }
            }
        }

        private async Task SaveToEventStore(dynamic token)
        {
            dynamic messageDetails = JObject.Parse(token.Message.ToString());
            NewEventData @event = NewEventData.Create(messageDetails);
            await _eventStore.AppendToStreamAsync(token.Subject.ToString(), ExpectedVersion.Any, @event);
        }
    }
}