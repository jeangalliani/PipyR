using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace PipyR
{
    public abstract class QueryHandler<TQuery, TResponse> : RequestHandler<TQuery, TResponse> where TQuery : Query<TResponse>
    {
        public QueryHandler(IMapper mapper) : base(mapper)
        {

        }

        public override abstract Task<TResponse> Handle(TQuery @query, CancellationToken cancellationToken);
    }
}