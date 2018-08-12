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

            Console.WriteLine($"Username: {username} | Password: {password}");
        }
    }
}
