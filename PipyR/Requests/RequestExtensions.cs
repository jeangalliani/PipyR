using System;

namespace PipyR
{
    public static class RequestExtension
    {
        public static RequestProperties Properties<TResponse>(this Request<TResponse> @request) => @request.RequestProperties;
        public static long Duration<TResponse>(this Request<TResponse> @request) => @request.RequestProperties.Duration;
        public static DateTime Timestamp<TResponse>(this Request<TResponse> @request) => @request.RequestProperties.Timestamp;
    }
}