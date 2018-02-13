using System.IO.Ports;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WebAPI
{
    public class Program
    {
        public static System.IO.Ports.SerialPort _port;

        public static void Main(string[] args)
        {
            _port = new SerialPort();
            _port.BaudRate = 115000;
            _port.DataBits = 8;
            _port.StopBits = StopBits.One;

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
