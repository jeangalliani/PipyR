using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace PipyR
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : Request<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {

            //TODO: Definir implementação de autorização

            return await next();
        }
    }
}