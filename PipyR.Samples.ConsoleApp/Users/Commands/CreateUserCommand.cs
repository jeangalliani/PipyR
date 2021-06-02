using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace PipyR.Samples.ConsoleApp.Users.Commands
{
    public class CreateUserCommand : Command<CreateUserResponse>
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public class Handler : CommandHandler<CreateUserCommand, CreateUserResponse>
        {
            public Handler(IMapper mapper) : base(mapper)
            {
            }

            public override async Task<CreateUserResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                System.Console.WriteLine(command.Duration());
                return new CreateUserResponse() { Success = true };
            }
        }
    }
}