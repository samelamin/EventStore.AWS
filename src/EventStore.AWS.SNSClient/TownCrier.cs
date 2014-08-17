using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Timer = System.Timers.Timer;

namespace EventStore.AWS.SNSClient
{
    public class TownCrier
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(TownCrier));
        readonly Timer _timer;
        public TownCrier()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => _log.InfoFormat("It is {0} an all is well", DateTime.Now);
        }
        public void Start() { _timer.Start(); _log.Info("Crier is Started"); }
        public void Stop() { _timer.Stop(); _log.Info("Crier is Stopped"); }
    }
}
