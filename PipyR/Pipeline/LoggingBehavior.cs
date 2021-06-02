using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace PipyR
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : Request<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger) => _logger = logger;

        public async Task<TResponse> Handle(TRequest @request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //_logger.LogDebug($"{@request.DefaultProperties.Name} in execution");
            //((Request)(IRequest)request).Start();
            _logger.LogDebug($"{typeof(TRequest).Name} in execution");
            var response = await next();
            //((Request)(IRequest)request).Success();
            _logger.LogDebug($"{typeof(TRequest).Name} executed in {request.RequestProperties.Duration}ms");
            return response;
        }
    }
}