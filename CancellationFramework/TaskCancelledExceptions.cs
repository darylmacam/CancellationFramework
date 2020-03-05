using Common;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationTkn
{
    public class TaskCancelledExceptions : ConsoleLogger
    {
        public async Task WithCancelledToken()
        {
            try
            {
                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
                cts.Cancel();
                await Task.Run(() => Log("Task started"), cts.Token);
                Log("Main tasks Completed");
            }
            catch (Exception ex)
            {
                Log($"{ex.GetType().FullName} thrown");
            }
        }

        public async Task UseTaskDelay()
        {
            try
            {
                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

                await Task.Delay(TimeSpan.FromSeconds(5));
                Log("Main tasks Completed");
            }
            catch (Exception ex)
            {
                Log($"{ex.GetType().FullName} thrown");
            }
        }


        public async Task UseHttpClient()
        {
            try
            {
                var client = new HttpClient();
                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(4));
                await client.GetAsync(@"http://slowwly.robertomurray.co.uk/delay/5000/url/http://www.google.co.uk", cts.Token);
            }
            catch (Exception ex)
            {
                Log($"{ex.GetType().Name} thrown");
            }
        }
    }


}
