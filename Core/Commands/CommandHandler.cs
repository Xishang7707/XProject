using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands
{
    public abstract class CommandHandler
    {
        protected ICommandBus CommandBus { get; }
        protected IServiceScopeFactory ServiceScopeFactory { get; }
        public CommandHandler(IServiceScopeFactory serviceScopeFactory, ICommandBus commandBus)
        {
            ServiceScopeFactory = serviceScopeFactory;
            CommandBus = commandBus;
        }

        protected static void Assert(bool b, string m)
        {
            if (!b) throw new Exception(m);
        }
    }
}
