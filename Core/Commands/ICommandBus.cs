using Core.Commands.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands
{
    public interface ICommandBus
    {
        Task<TResult> Send<TCommand, TResult>(TCommand command)
            where TCommand : Command<TResult>
            where TResult : CommandResult, new();
    }
}
