/*

    ██████▌ ██                   ███████
    ██   ██ ██  ██████  ██    ██ ██    █▌
    ██████  ██  █▌   ██  ██  █▀  ██████▌
    ██      ██  ██   ██   ████   ██   ██
    ██      ██  █████▀     █▌    ██    ██
                █▌       ███

      by Galliani
*/
using MediatR;

namespace PipyR
{
    public class PipyR : Mediator
    {
        public PipyR(ServiceFactory serviceFactory) : base(serviceFactory)
        { }
    }
}