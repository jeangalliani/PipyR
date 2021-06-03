namespace PipyR
{
    public class QueryValidation<TRequest, TResponse> : RequestValidation<TRequest, TResponse> where TRequest : Query<TResponse>
    {
    }
}