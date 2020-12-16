using Core.Commands.Models;
using Core.Models;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validator
{
    public abstract class CommandValidator<TCommand, TResult, TEntity> : AbstractValidator<TEntity>, ICommandValidator<TCommand, TResult>
       where TCommand : Command<TResult>
       where TResult : CommandResult, new()
       where TEntity : Entity, new()
    {
        public abstract ValidationResult IsValid(TCommand command);

        protected ValidationResult Valid(TEntity entity)
        {
            return Validate(entity);
        }
    }
}
