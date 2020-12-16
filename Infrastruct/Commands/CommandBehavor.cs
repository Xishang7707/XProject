using Core.Commands.Models;
using Core.Validator;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastruct.Commands
{
    public class CommandBehavor<TCommand, TResult> : IPipelineBehavior<TCommand, TResult>
        where TCommand : Command<TResult>
        where TResult : CommandResult, new()
    {
        private ICommandValidator<TCommand, TResult> CommandValidator { get; }
        public CommandBehavor(ICommandValidator<TCommand, TResult> commandValidator) => CommandValidator = commandValidator;

        public async Task<TResult> Handle(TCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<TResult> next)
        {
            TResult result;
            try
            {
                ValidateCommand(request);
                result = await next();
            }
            catch (Exception ex)
            {
                result = CommandResult.CreateInstance<TResult>(false, ex.Message);
            }
            return result;
        }

        private void ValidateCommand(TCommand command)
        {
            var result = CommandValidator.IsValid(command);
            if (!result.IsValid) throw new Exception(result.Errors.First().ErrorMessage);
        }
    }
}
