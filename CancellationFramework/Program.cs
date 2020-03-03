using System;

namespace CancellationTkn
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //var job = new InvokingCancellations();
                //job.ByCancelMethod().Wait();
                //job.ByTimeoutPeriodInConstructor().Wait();
                //job.ByTimeoutPeriodUsingCancelAfter().Wait();

                //var job = new RespondingToCancellations();
                //job.ByPolling().Wait();
                //job.ByRegisteringAction().Wait();

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

                //var job = new TaskContinuation();
                //job.Execute().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception from main thread : {ex}");
            }
            Console.ReadLine();
        }
    }
}




