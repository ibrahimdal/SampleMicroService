using Consul;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace SampleMicroService.Infrastructure
{
    public static class StartUpExtentions
    {
        public static ServiceConfigDto GetServiceConfig(
            this IConfiguration configuration
            )
        {
            return new ServiceConfigDto
            {
                ServiceDiscoveryAddress = configuration.GetValue<Uri>("ServiceConfig:serviceDiscoveryAddress"),
                ServiceAddress = configuration.GetValue<Uri>("ServiceConfig:serviceAddress"),
                ServiceName = configuration.GetValue<string>("ServiceConfig:serviceName"),
                ServiceId = configuration.GetValue<string>("ServiceConfig:serviceId"),
                TcpCheckTimeOutAsMin = configuration.GetValue<int>("ServiceConfig:tcpCheckTimeOutAsMin"),
                TcpCheckIntervalAsSec = configuration.GetValue<int>("ServiceConfig:tcpCheckIntervalAsSec"),
                HealtCheckTimeOutAsMin = configuration.GetValue<int>("ServiceConfig:healtCheckTimeOutAsMin"),
                HealtCheckIntervalAsSec = configuration.GetValue<int>("ServiceConfig:healtCheckIntervalAsSec")
            };
        }

        public static void RegisterConsulServices(
            this IServiceCollection services,
            ServiceConfigDto serviceConfig
            )
        {
            var consulClient = new ConsulClient(config =>
            {
                config.Address = serviceConfig.ServiceDiscoveryAddress;
            }
             );

            services.AddSingleton(serviceConfig);
            services.AddSingleton<IConsulClient, ConsulClient>(p => consulClient);
            services.AddSingleton<IHostedService, ServiceDiscoveryHostedService>();
        }
    }
}
