using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace SampleMicroService.Application.Common.Behaviours
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;

        public PerformanceBehaviour(
            ILogger<TRequest> logger
            )
        {
            _timer = new Stopwatch();

            _logger = logger;
        }
        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next
            )
        {
            _timer.Start();

            var response = await next(); //istek işleniyor.

            _timer.Stop();

            //500 ms den fazla sürmüş ise; logla.
            var elapsedMilliseconds = _timer.ElapsedMilliseconds;
            if (elapsedMilliseconds > 500)
            {
                var requestName = typeof(TRequest).Name;

                _logger.LogWarning(
                    "SampleMicroService Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}",
                    requestName,
                    elapsedMilliseconds,
                    request
                    );
            }

            return response;
        }
    }
}
