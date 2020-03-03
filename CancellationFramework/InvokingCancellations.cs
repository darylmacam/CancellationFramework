using Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationTkn
{
    public class InvokingCancellations : ConsoleLogger
    {
        public async Task UseCancelMethod()
        {
            using var cts = new CancellationTokenSource();
            var childTask = ChildTask(cts.Token);

            Log("Press any key to cancel");
            Console.ReadLine();
            cts.Cancel();

            await childTask;
            Log("Completed!!!");
        }

        public async Task UseTimeoutPeriod()
        {
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            var childTask = ChildTask(cts.Token);

            await childTask;
            Log("Completed!!!");
        }

        public async Task UseCancelAfter()
        {
            using var cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(5));
            var childTask = ChildTask(cts.Token);

            await childTask;
            Log("Completed!!!");
        }

        private async Task ChildTask(CancellationToken cancellationToken)
        {
            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    Log($"Token cancellation requested. Exiting {nameof(ChildTask)}");
                    return;
                }

                await Task.Delay(1000);
                Log($"{nameof(ChildTask)} looping");
            }
        }
    }
}
