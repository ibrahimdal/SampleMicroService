using Consul;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SampleMicroService.Infrastructure
{
    public class ServiceDiscoveryHostedService : IHostedService
    {
        private readonly IConsulClient _client;
        private readonly ServiceConfigDto _config;
        private string _registrationId;

        public ServiceDiscoveryHostedService(
            IConsulClient client,
            ServiceConfigDto serviceConfig
            )
        {
            _client = client;
            _config = serviceConfig;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _registrationId = $"{_config.ServiceName}-{_config.ServiceId}";

            var registration = new AgentServiceRegistration
            {
                ID = _registrationId,
                Name = _config.ServiceName,
                Address = _config.ServiceAddress.Host,
                Port = _config.ServiceAddress.Port,
                Checks = new AgentServiceCheck[]
                {
                    new AgentServiceCheck
                    {
                        DeregisterCriticalServiceAfter = TimeSpan.FromMinutes(_config.TcpCheckTimeOutAsMin),
                        Interval = TimeSpan.FromSeconds(_config.TcpCheckIntervalAsSec),
                        TCP = $"{_config.ServiceAddress.Host}:{_config.ServiceAddress.Port}"
                    },
                    new AgentServiceCheck
                    {
                        DeregisterCriticalServiceAfter = TimeSpan.FromMinutes(_config.HealtCheckTimeOutAsMin),
                        Interval = TimeSpan.FromSeconds(_config.HealtCheckIntervalAsSec),
                        HTTP = $"{_config.ServiceAddress.Scheme}://{_config.ServiceAddress.Host}:{_config.ServiceAddress.Port}/HealthCheck"
                    }
                }
            };

            await _client.Agent.ServiceDeregister(registration.ID, cancellationToken);
            await _client.Agent.ServiceRegister(registration, cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _client.Agent.ServiceDeregister(_registrationId, cancellationToken);
        }
    }
}
