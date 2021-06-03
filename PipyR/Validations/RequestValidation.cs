using FluentValidation;

namespace PipyR
{
    public class RequestValidation<TRequest, TResponse> : AbstractValidator<TRequest> where TRequest : Request<TResponse>
    {
        public RequestValidation()
        {
        }
    }
}