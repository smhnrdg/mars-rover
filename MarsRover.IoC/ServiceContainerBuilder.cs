using MarsRover.Business.Services;
using MarsRover.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover.IoC
{
    public static class ServiceContainerBuilder
    {
        public static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IRover, Rover>();
            services.AddTransient<IPlateau, Plateau>();
            services.AddTransient<IRoverCommander, RoverCommander>();

            return services;
        }
    }
}
