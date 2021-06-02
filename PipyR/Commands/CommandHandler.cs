using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace PipyR
{
    public abstract class CommandHandler<TCommand, TResponse> : RequestHandler<TCommand, TResponse> where TCommand : Command<TResponse>
    {
        protected CommandHandler(IMapper mapper) : base(mapper)
        {
        }

        override public abstract Task<TResponse> Handle(TCommand @command, CancellationToken cancellationToken);
    }
}