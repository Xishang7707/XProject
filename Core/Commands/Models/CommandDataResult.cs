using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands.Models
{
    public class CommandDataResult<TModel> : CommandResult
    {
        public TModel Model { get; set; }

        public CommandDataResult() { }
        public CommandDataResult(bool isSuccess, string message, TModel model = default) : base(isSuccess, message) => Model = model;

    }
}
