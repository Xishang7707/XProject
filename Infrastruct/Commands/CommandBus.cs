using Core.Commands;
using Core.Commands.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruct.Commands
{
    public class CommandBus : ICommandBus
    {
        public IMediator Mediator { get; }

        public CommandBus(IMediator mediator)
        {
            Mediator = mediator;
        }

        public Task<TResult> Send<TCommand, TResult>(TCommand command)
            where TCommand : Command<TResult>
            where TResult : CommandResult, new()
        {
            return Mediator.Send(command);
        }
    }
}
