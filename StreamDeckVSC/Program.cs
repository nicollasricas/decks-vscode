using System;
using System.Diagnostics;
using System.Threading.Tasks;
using BarRaider.SdTools;
using Config.Net;

namespace StreamDeckVSC
{
    internal class Program
    {
        private static MessageServer messageServer;

        private static void Main(string[] args)
        {
            var options = new ConfigurationBuilder<IProgramOptions>()
                .UseJsonConfig()
                .Build();

            //InstallExtensionIfNot();

            StartMessageServer(options);

            //#if DEBUG
            //System.Console.ReadLine();
            //#endif

            ConnectPlugin(args);

            StopMessageServer();
        }

        private static void ConnectPlugin(string[] args) => SDWrapper.Run(args);

        private static void StartMessageServer(IProgramOptions options)
        {
            messageServer = new MessageServer(options.Host, options.Port);
            messageServer.Start();
        }

        private static void StopMessageServer() => messageServer?.Dispose();

        private static void InstallExtensionIfNot()
        {
            Task.Run(() =>
            {
                if(IsExtensionInstalled())
                {
                    InstallExtension();
                }
            });
        }

        private static bool IsExtensionInstalled() => true;

        private static void InstallExtension()
        {
        }
    }
}
