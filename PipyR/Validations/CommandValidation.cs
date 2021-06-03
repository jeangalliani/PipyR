namespace PipyR
{
    public class CommandValidation<TRequest, TResponse> : RequestValidation<TRequest, TResponse> where TRequest : Command<TResponse>
    {
    }
}