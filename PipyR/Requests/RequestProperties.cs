using System;

namespace PipyR
{
    public class RequestProperties
    {
        public DateTime Timestamp { get; private set; }
        public long Duration { get => DateTime.UtcNow.Subtract(Timestamp).Ticks / TimeSpan.TicksPerMillisecond; }
        public RequestProperties()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}