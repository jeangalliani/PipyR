using Microsoft.Extensions.DependencyInjection;
using PipyR.DependencyInjection;
using PipyR.Samples.ConsoleApp.Users.Commands;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace PipyR.Samples.ConsoleApp
{
    class Program
    {
        private static PipyR _pipyr;

        public static async Task Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddPipyR(Assembly.GetExecutingAssembly())
                .AddLogging()
                .BuildServiceProvider();

            _pipyr = serviceProvider.GetService<PipyR>();

            var response = await _pipyr.Send(new CreateUserCommand()).ConfigureAwait(false);
            Console.WriteLine(response);

            Console.ReadKey();
        }
    }
}
