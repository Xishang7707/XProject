using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Applications
{
    public abstract class Application
    {
        protected ICommandBus CommandBus { get; }
        public Application(ICommandBus commandBus) => CommandBus = commandBus;
    }
}
