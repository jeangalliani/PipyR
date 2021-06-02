using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PipyR
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : Request<TResponse>
    {
        private readonly IEnumerable<IValidator> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validationContext = new ValidationContext<TRequest>(request);

            var failures = _validators
                .Select(v => v.Validate(validationContext))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            //if (failures.Any())
            //    TODO: Fazer algo caso encontre falhas na validação

            return await next();
        }

    }
}