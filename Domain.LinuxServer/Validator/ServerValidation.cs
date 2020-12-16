using Core.Commands.Models;
using Core.Validator;
using Domain.Models;
using FluentValidation;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Domain.Server.Validator
{
    public abstract class ServerValidation<TCommand, TResult> : CommandValidator<TCommand, TResult, SV_Server>
       where TCommand : Command<TResult>
       where TResult : CommandResult, new()
    {
        protected void ValidateId()
        {
            RuleFor(r => r.Id)
                .NotEmpty().WithMessage("服务器id无效");
        }

        protected void ValidateName()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("服务器名称不能为空")
                .MaximumLength(30).WithMessage("服务器名称最多30个字符");
        }

        protected void ValidateHost()
        {
            RuleFor(r => r.Host)
                .NotEmpty().WithMessage("主机不能为空")
                .Must(s => !(
                s == null
                || !Regex.IsMatch(s, @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$")
                || !Regex.IsMatch(s, @"^(([a-zA-Z0-9]|[a-zA-Z0-9][a-zA-Z0-9\-]*[a-zA-Z0-9])\.)*([A-Za-z0-9]|[A-Za-z0-9][A-Za-z0-9\-]*[A-Za-z0-9])$")
                )).WithMessage("无效的主机");
        }

        protected void ValidatePort()
        {
            RuleFor(r => r.Port)
                .NotEmpty().WithMessage("端口不能为空")
                .InclusiveBetween(1, 65535).WithMessage("端口无效");
        }

        protected void ValidateUser()
        {
            RuleFor(r => r.User)
                .NotEmpty().WithMessage("用户名不能为空")
                .MaximumLength(128).WithMessage("用户名最长128个字符");
        }

        protected void ValidatePassword()
        {
            RuleFor(r => r.Password)
                .NotEmpty().WithMessage("密码不能为空")
                .MaximumLength(128).WithMessage("密码最长128个字符");
        }

        protected void ValidatePrivateKey()
        {
            RuleFor(r => r.PrivateKey)
                .NotEmpty().WithMessage("私钥不能为空")
                .MaximumLength(128).WithMessage("私钥最长4096个字符");
        }

        protected void ValidateLoginType()
        {
            RuleFor(r => r.LoginType)
                .NotEmpty().WithMessage("登陆类型不能为空")
                .Must(s => new int[] { 0, 1, 2 }.Contains(s)).WithMessage("登陆类型无效");
        }
    }
}
