using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Commands.Models
{
    public class CommandResult
    {
        public bool IsSuccess { get; protected set; }
        public string Message { get; protected set; }

        public CommandResult() { }
        public CommandResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public static T CreateInstance<T>(bool isSuccess, string message) where T : CommandResult, new()
        {
            return new T
            {
                IsSuccess = isSuccess,
                Message = message
            };
        }
    }
}
