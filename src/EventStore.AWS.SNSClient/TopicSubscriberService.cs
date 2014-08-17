using System.Collections.Generic;
using System.Linq;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace EventStore.AWS.SNSClient
{
    public class TopicSubscriberService
    {
        private readonly IAmazonSimpleNotificationService _client;

        public TopicSubscriberService(IAmazonSimpleNotificationService client)
        {
            _client = client;
        }

        public void SubscribeToAllTopics()
        {
            var topics = GetTopicsArns();

            foreach (var topic in topics)
            {
                _client.Subscribe(new SubscribeRequest(topic, "sqs", "arn:aws:sqs:eu-west-1:928682934851:EventStoreAudit"));
            }
        }

        private IEnumerable<string> GetTopicsArns()
        {
            var topics = new List<Topic>();

            string nextToken = null;
            do
            {
                ListTopicsResponse response = _client.ListTopics(new ListTopicsRequest(nextToken));
                topics.AddRange(response.Topics);
                nextToken = response.NextToken;
            } while (nextToken != null);

            return topics.Select(x => x.TopicArn);
        }
    }
}