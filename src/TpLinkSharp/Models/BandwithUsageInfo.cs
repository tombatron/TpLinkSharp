namespace TpLinkSharp.Models
{
    public class BandwithUsageInfo
    {
        public long Bytes { get; }
        public long Packets { get; }

        private BandwithUsageInfo(long bytes, long packets)
        {
            Bytes = bytes;
            Packets = packets;
        }

        public static BandwithUsageInfo Create(string bytes, string packets)
        {
            return new BandwithUsageInfo(long.Parse(bytes), long.Parse(packets));
        }
    }
}