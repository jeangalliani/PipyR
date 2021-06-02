//    _____    _                   _____  
//   |  __ \  (_)                 |  __ \ 
//   | |__) |  _   _ __    _   _  | |__) |
//   |  ___/  | | | '_ \  | | | | |  _  / 
//   | |      | | | |_) | | |_| | | | \ \ 
//   |_|      |_| | .__/   \__, | |_|  \_\
//                | |       __/ |         
//                |_|      |___/          
//    by Galliani
using MediatR;

namespace PipyR
{
    public class PipyR : Mediator
    {
        public PipyR(ServiceFactory serviceFactory) : base(serviceFactory)
        { }
    }
}