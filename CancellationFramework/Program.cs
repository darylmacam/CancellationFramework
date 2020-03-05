using System;

namespace CancellationTkn
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var ic = new InvokingCancellations();
                ic.UseCancelMethod().Wait();
                ic.UseCancelAfter().Wait();
                ic.UseTimeoutPeriod().Wait();

                var rtc = new RespondingToCancellations();
                rtc.ByPolling().Wait();
                rtc.ByRegisteringAction().Wait();

                var lc= new LinkingCancellations();
                lc.WithoutLinking().Wait();
                lc.WithLinking().Wait();

                var oce = new OperationCancelledExceptions();
                oce.UseCaseCanceled().Wait();
                oce.UseCaseCompleted().Wait();

                var tce = new TaskCancelledExceptions();
                tce.WithCancelledToken().Wait();
                tce.UseTaskDelay().Wait();
                tce.UseHttpClient().Wait();

                var ctd = new CancellationTokenDefault();
                ctd.Defaults();
                ctd.OptionalParameter();

                var tcJob = new TaskContinuation();
                tcJob.Execute().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception from main thread : {ex}");
            }
            Console.ReadLine();
        }
    }
}




