using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace PipyR
{
    public abstract class RequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : Request<TResponse>
    {
        protected readonly IMapper _mapper;
        public RequestHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public abstract Task<TResponse> Handle(TRequest @request, CancellationToken cancellationToken);
    }
}