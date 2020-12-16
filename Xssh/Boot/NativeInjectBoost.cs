using Core.Commands.Models;
using Core.Validator;
using Domain.Repositorys;
using Domain.Repositorys.Implements;
using Domain.Server.Commands;
using Domain.Shell.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Xssh.Shell.Handlers;
using Xssh.Shell.Servers;
using Xssh.Shell.Servers.Implements;

namespace Xssh.Boot
{
    public sealed class NativeInjectBoost
    {
        public static void Register(IServiceCollection services)
        {
            RegisterHandler(services);
            RegisterValidator(services);
            RegisterServer(services);
        }

        private static void RegisterConfig(IServiceCollection services)
        {
            services.AddSignalR();
        }

        private static void RegisterHandler(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<PasswordOpenShellCommand, CommandDataResult<string>>, ShellHandler>();
        }

        private static void RegisterValidator(IServiceCollection services)
        {
            //services.AddScoped<ICommandValidator<AddServerCommand, CommandResult>, AddServerValidation>();
        }

        private static void RegisterServer(IServiceCollection services)
        {
            services.AddSingleton<IShellTerminalServer, ShellTerminalServer>();
        }
    }
}
