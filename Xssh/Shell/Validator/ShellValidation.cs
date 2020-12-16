using Core.Commands.Models;
using Core.Validator;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xssh.Shell.Validator
{
    public abstract class ShellValidation<TCommand, TResult> : CommandValidator<TCommand, TResult, SV_Server>
       where TCommand : Command<TResult>
       where TResult : CommandResult, new()
    {
    }
}
