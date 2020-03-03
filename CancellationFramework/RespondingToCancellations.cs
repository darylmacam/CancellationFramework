using Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationTkn
{
    public class RespondingToCancellations : ConsoleLogger
    {
        public async Task ByPolling()
        {
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            var childTask = ByPollingChildTask(cts.Token);

            await childTask;
            Log("Completed!!!");
        }

        private async Task ByPollingChildTask(CancellationToken cancellationToken)
        {
            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    Log($"Token cancellation requested. Exiting {nameof(ByPollingChildTask)}");
                    return;
                }

                await Task.Delay(1000);
                Log($"{nameof(ByPollingChildTask)} looping");
            }
        }

        public async Task ByRegisteringAction()
        {
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            cts.Token.Register(() => Log("This is main task reacting to cancellation"));

            var childTask = ByRegisteringActionChildTask(cts.Token);

            await childTask;
            Log("Completed!!!");
        }

        private async Task ByRegisteringActionChildTask(CancellationToken cancellationToken)
        {
            cancellationToken.Register(() => Log("This is child task reacting to cancellation"));

            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(1000);
                Log($"{nameof(ByPollingChildTask)} looping");
            }
        }
    }
}
