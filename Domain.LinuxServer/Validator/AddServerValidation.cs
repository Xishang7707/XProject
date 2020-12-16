using Core.Commands.Models;
using Domain.Server.Commands;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Server.Validator
{
    public class AddServerValidation : ServerValidation<AddServerCommand, CommandResult>
    {
        public override ValidationResult IsValid(AddServerCommand request)
        {
            ValidateName();
            ValidateHost();
            ValidatePort();
            ValidateUser();
            ValidateLoginType();
            if (request.AddServerInfo.LoginType != 2)
                ValidatePassword();
            else
                ValidatePrivateKey();

            return Valid(new Domain.Models.SV_Server
            {
                Id = request.CommandId,
                Name = request.AddServerInfo.Name,
                Host = request.AddServerInfo.Host,
                Port = request.AddServerInfo.Port,
                User = request.AddServerInfo.User,
                Password = request.AddServerInfo.Password,
                PrivateKey = request.AddServerInfo.PrivateKey,
                LoginType = request.AddServerInfo.LoginType
            });
        }
    }
}
