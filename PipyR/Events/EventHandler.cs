using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace PipyR
{
    public abstract class EventHandler<TEvent> : INotificationHandler<TEvent> where TEvent : Event
    {
        public abstract Task Handle(TEvent @event, CancellationToken cancellationToken);
    }
}