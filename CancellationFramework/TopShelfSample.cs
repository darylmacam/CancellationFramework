using System;
using Topshelf;

namespace CancellationTkn
{
    public class AppService
    {
        public void Start() { }

        public bool Stop(HostControl hostControl)
        {
            hostControl.RequestAdditionalTime(TimeSpan.FromMinutes(10));
            return true;
        }
    }

    public class TopShelfSample
    {
        public void Execute()
        {
            HostFactory.Run(x =>
            {
                x.Service<AppService>(s =>
                {
                    s.WhenStarted(svc => svc.Start());
                    s.WhenStopped((svc, hostControl) => svc.Stop(hostControl));
                });
            });
        }
    }
}
