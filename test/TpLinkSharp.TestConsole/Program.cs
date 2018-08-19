using System;
using System.Threading;

namespace TpLinkSharp.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press `ESC` to exit...");

            var username = Environment.GetEnvironmentVariable("ROUTER_USERNAME");
            var password = Environment.GetEnvironmentVariable("ROUTER_PASSWORD");

            var previousReceivedBytes = default(long);
            var previousSentBytes = default(long);

            using (var client = new TpLinkClient("http://192.168.0.1"))
            {
                client.Connect(username, password);

                var commands = new TpLinkCommands(client);

                do
                {
                    while (!Console.KeyAvailable)
                    {
                        var status = commands.GetCurrentStatus().GetAwaiter().GetResult();

                        if (previousReceivedBytes == default(int) && previousSentBytes == default(int))
                        {
                            previousReceivedBytes = status.TrafficStatistics.Received.Bytes;
                            previousSentBytes = status.TrafficStatistics.Sent.Bytes;
                        }
                        else
                        {
                            var currentReceivedBytes = status.TrafficStatistics.Received.Bytes;
                            var currentSentBytes = status.TrafficStatistics.Sent.Bytes;

                            var receiveRate = (((currentReceivedBytes - previousReceivedBytes) / 2) * 8) / 1000000f;
                            var sendRate = (((currentSentBytes - previousSentBytes) / 2) * 8) / 1000000f;

                            Console.WriteLine($"\rReceive Rate: {receiveRate.ToString("0.000")}Mbps | Sent Rate: {sendRate.ToString("0.000")}Mbps");

                            previousReceivedBytes = currentReceivedBytes;
                            previousSentBytes = currentSentBytes;
                        }

                        Thread.Sleep(2000);
                    }
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
        }
    }
}