using System;
using TpLinkSharp;

namespace TpLinkSharp.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var username = Environment.GetEnvironmentVariable("ROUTER_USERNAME");
            var password = Environment.GetEnvironmentVariable("ROUTER_PASSWORD");

            using(var client = new TpLinkClient("http://192.168.0.1"))
            {
                client.Connect(username, password);

                var commands = new TpLinkCommands(client);

                commands.GetCurrentStatus().GetAwaiter().GetResult();
            }

            Console.ReadLine();
        }
    }
}