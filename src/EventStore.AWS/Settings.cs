using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.AWS
{
    public class Settings : ISettings
    {
        public string Address { get { return ConfigurationManager.AppSettings["EventStoreAddress"]; } }
        public string HttpPort { get { return ConfigurationManager.AppSettings["HttpPorts"]; } }
        public string QueueUrl { get { return ConfigurationManager.AppSettings["EventStoreQueueUrl"]; } }
        public TimeSpan TimeSpanPolling { get { return TimeSpan.Parse(ConfigurationManager.AppSettings["TimeSpanPolling"]); } }
    }

    public interface ISettings
    {
        string Address { get; }
        string HttpPort { get; }
        string QueueUrl { get; }
        TimeSpan TimeSpanPolling { get; }
    }
}
