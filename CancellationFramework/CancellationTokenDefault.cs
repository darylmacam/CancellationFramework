using Common;
using System;
using System.Threading;

namespace CancellationTkn
{
    public class CancellationTokenDefault : ConsoleLogger
    {
        public void Defaults()
        {
            var noneToken = CancellationToken.None;
            var newToken = new CancellationToken();
            var defaultToken = default(CancellationToken);
            var fromCtsToken = new CancellationTokenSource().Token;

            Log($"CancellationToken.None vs new CancellationToken(): {noneToken.Equals(newToken)}");
            Log($"CancellationToken.None vs default(CancellationToken): {noneToken.Equals(defaultToken)}");
            Log($"CancellationToken.None vs new CancellationTokenSource().Token: {noneToken.Equals(fromCtsToken)}");
            Log($"CancellationToken.None == dafault: {noneToken == default}");

        }

        // THIS WILL NOT COMPILE
        //public void OptionalParameter(CancellationToken cancellationToken = CancellationToken.None) { }

        // THIS WILL COMPILE
        public void OptionalParameter(CancellationToken cancellationToken = default) { }
    }
}
