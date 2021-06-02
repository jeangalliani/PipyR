using MediatR;

namespace PipyR
{
    public class Request<TResponse> : IRequest<TResponse>
    {
        internal RequestProperties RequestProperties { get; }
        public Request()
        {
            RequestProperties = new RequestProperties();
        }
    }
}