using Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationTkn
{
    public class UsingContinueWith : ConsoleLogger
    {
        public async Task CanceledIsNotFaulted()
        {
            _ = CanceledIsNotFaultedChildTask().ContinueWith(e =>
             {
                 Log($"IsFaulted: {e.IsFaulted}");
                 if (e.IsFaulted)
                     Log($"Inner exception {e.Exception.InnerException}");

                 Log($"IsCanceled: {e.IsCanceled}");
             });

            await Task.Delay(TimeSpan.FromSeconds(10));
            Log($"{nameof(CanceledIsNotFaulted)} completed");
        }

        private async Task CanceledIsNotFaultedChildTask()
        {
            try
            {
                var cts = new CancellationTokenSource();
                cts.Cancel();
                await Task.Delay(1, cts.Token);
            }
            catch (Exception ex)
            {
                Log($" {ex.GetType().Name} exception on {nameof(CanceledIsNotFaultedChildTask)}");
                throw;
            }
        }

        public async Task ThrowOperationCanceledException()
        {
            _ = ThrowOperationCanceledExceptionChildTask().ContinueWith(e =>
            {
                Log($"IsFaulted: {e.IsFaulted}");
                if (e.IsFaulted)
                    Log($"Inner exception {e.Exception.InnerException}");

                Log($"IsCanceled: {e.IsCanceled}");
            });

            await Task.Delay(TimeSpan.FromSeconds(10));
            Log($"{nameof(ThrowOperationCanceledException)} completed");
        }

        private async Task ThrowOperationCanceledExceptionChildTask()
        {
            throw new OperationCanceledException();
        }
    }
}
