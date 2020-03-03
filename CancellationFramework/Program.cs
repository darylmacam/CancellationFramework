using System;

namespace CancellationTkn
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // --- Invoking cancellations ---
                //var job = new InvokingCancellations();
                //job.ByCancelMethod().Wait();
                //job.ByTimeoutPeriodInConstructor().Wait();
                //job.ByTimeoutPeriodUsingCancelAfter().Wait();

                // --- reacting to cancellations ---
                //var job = new ReactingOnCancellations();
                //job.ByPolling().Wait();
                //job.ByRegisteringAction().Wait();


                //OperationCancelledExceptions
                //var job = new OperationCancelledExceptions();
                //job.Basic().Wait();
                //job.UseCaseCompleted().Wait();
                //job.UsingLibrary().Wait();


                //var job = new LinkingCancellations();
                //job.WithoutLinking().Wait() ;
                //job.WithLinking().Wait();

                //var job = new OperationCancelledExceptions();
                //job.Basic().Wait();
                //job.UseCaseCompleted().Wait();
                //job.UsingLibrary().Wait();

                //var job = new TaskVsOperationCancelledException();
                //job.TryTaskCancelledException().Wait();
                //job.TryOperationCancelledException().Wait();

                //new TopShelfSample().Execute();

                //var job = new CancellationTokenDefault();
                //job.Defaults();
                //job.OptionalParameter();

                var job = new UsingContinueWith();
                //job.CanceledIsNotFaulted().Wait();
                job.ThrowOperationCanceledException().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception from main thread : {ex}");
            }
            Console.ReadLine();
        }
    }
}




