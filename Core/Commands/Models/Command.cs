using MediatR;
using System;

namespace Core.Commands.Models
{
    public abstract class Command<TResult> : IRequest<TResult>
        where TResult : CommandResult, new()
    {
        public string CommandId { get; }
        public DateTime CommandTime { get; }

        public Command(string commandId)
        {
            CommandId = commandId;
            CommandTime = DateTime.Now;
        }
    }
}
