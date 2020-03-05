using Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationTkn
{
    public class OperationCancelledExceptions : ConsoleLogger
    {
        public async Task UseCaseCompleted()
        {
            try
            {
                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
                var childTask = TwoSecondTask(cts.Token, loops: 2);

                await childTask;
                Log("Main tasks Completed");
            }
            catch (Exception ex)
            {
                Log($"{ex.GetType().Name} thrown");
            }
        }

        public async Task UseCaseCanceled()
        {
            try
            {
                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
                var childTask = TwoSecondTask(cts.Token, loops: 3);

                await childTask;
                Log("Main tasks Completed");
            }
            catch (Exception ex)
            {
                Log($"{ex.GetType().Name} thrown");
            }
        }

        private async Task TwoSecondTask(CancellationToken cancellationToken, int loops)
        {
            for (var i = 0; i < loops; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                    cancellationToken.ThrowIfCancellationRequested(); //equivalent to throw new OperationCanceledException()

                await Task.Delay(TimeSpan.FromSeconds(2));
                Log($"{nameof(TwoSecondTask)} looping");
            }

            Log($"{nameof(TwoSecondTask)} Completed");
        }

    }
}
