using Application.Applications;
using Application.Applications.Implements;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Boot
{
    public sealed class NativeInjectBoost
    {
        public static void Register(IServiceCollection services, params Type[] types)
        {
            RegisterConfig(services, types);
            RegisterApplication(services);
            RegisterDomain(services);
        }

        private static void RegisterApplication(IServiceCollection services)
        {
            services.AddScoped<IProjectApplication, ProjectApplication>();
            services.AddScoped<IServerApplication, ServerApplication>();
        }

        private static void RegisterConfig(IServiceCollection services, params Type[] types)
        {
            Infrastruct.Boot.NativeInjectBoost.Register(services, types);
        }

        private static void RegisterDomain(IServiceCollection services)
        {
            Domain.Project.Boot.NativeInjectBoost.Register(services);
            Domain.Server.Boot.NativeInjectBoost.Register(services);
            Xssh.Boot.NativeInjectBoost.Register(services);
        }
    }
}
