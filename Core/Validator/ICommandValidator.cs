using Core.Commands.Models;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validator
{
    public interface ICommandValidator<TCommand, TResult>
        where TCommand : Command<TResult>
        where TResult : CommandResult, new()
    {
        ValidationResult IsValid(TCommand command);
    }
}
