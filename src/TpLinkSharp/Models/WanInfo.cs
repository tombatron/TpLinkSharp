namespace TpLinkSharp.Models
{
    public class WanInfo
    {
        public string MacAddress { get; }
        public string IpAddress { get; }
        public string SubnetMask { get; }
        public string DefaultGateway { get; }
        public string[] DnsServer { get; }
    }
}