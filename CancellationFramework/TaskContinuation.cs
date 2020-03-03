using Common;
using System;
using System.Threading.Tasks;

namespace CancellationTkn
{
    public class TaskContinuation : ConsoleLogger
    {
        public async Task Execute()
        {
            await Task.Run(() => throw new OperationCanceledException())
                 .ContinueWith(e =>
                 {
                     Console.WriteLine($"IsFaulted : {e.IsCanceled}");
                     Console.WriteLine($"IsFaulted : {e.IsFaulted}");
                 });

            Log($"{nameof(Execute)} completed");
        }
    }
}
