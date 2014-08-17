using System.Security;
using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SQS;
using log4net.Config;
using Topshelf;

namespace EventStore.AWS.SNSClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var snsClient = new AmazonSimpleNotificationServiceClient(RegionEndpoint.EUWest1);
            var subscriberService = new TopicSubscriberService(snsClient);
            var sqsClient = new AmazonSQSClient(RegionEndpoint.EUWest1);
            ISettings settings = new Settings();
            XmlConfigurator.Configure();

            var service = new EventStoreAuditService(subscriberService, sqsClient, settings);
            service.PollQueues();
        }
    }
}