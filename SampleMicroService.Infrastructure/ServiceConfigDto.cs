using System;

namespace SampleMicroService.Infrastructure
{
    public class ServiceConfigDto
    {
        public Uri ServiceDiscoveryAddress { get; set; }
        public Uri ServiceAddress { get; set; }
        public string ServiceName { get; set; }
        public string ServiceId { get; set; }

        public int TcpCheckTimeOutAsMin { get; set; }
        public int TcpCheckIntervalAsSec { get; set; }
        public int HealtCheckTimeOutAsMin { get; set; }
        public int HealtCheckIntervalAsSec { get; set; }
    }
}
