﻿using Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationTkn
{
    public class LinkingCancellations : ConsoleLogger
    {
        public async Task WithoutLinking()
        {
            using var cts = new CancellationTokenSource();
            var childTask = WithoutLinkingChildTask(cts.Token);

            await childTask;
            Log("Completed!!!");
        }

        public async Task WithoutLinkingChildTask(CancellationToken cancellationToken)
        {
            using var myOwnCts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
            while (true)
            {
                if (cancellationToken.IsCancellationRequested || myOwnCts.Token.IsCancellationRequested)
                {
                    Log($"Token cancellation requested. Exiting {nameof(WithoutLinkingChildTask)}");
                    return;
                }

                await Task.Delay(1000);
                Log($"{nameof(WithoutLinkingChildTask)} looping");
            }
        }

        public async Task WithLinking()
        {
            using var cts = new CancellationTokenSource();
            var childTask = WithLinkingChildTask(cts.Token);

            await childTask;
            Log("Completed!!!");
        }

        public async Task WithLinkingChildTask(CancellationToken cancellationToken)
        {
            using var myOwnCts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
            //make sure CancellationTokenRegistration is disposed. Otherwise cancellation of cancellationToken will throw a object disposed exception.
            using CancellationTokenRegistration tokenRegistration = cancellationToken.Register(myOwnCts.Cancel);

            while (true)
            {
                if (cancellationToken.IsCancellationRequested || myOwnCts.Token.IsCancellationRequested)
                {
                    Log($"Token cancellation requested. Exiting {nameof(WithoutLinkingChildTask)}");
                    return;
                }

                await Task.Delay(1000);
                Log($"{nameof(WithLinkingChildTask)} looping");
            }
        }
    }
}
