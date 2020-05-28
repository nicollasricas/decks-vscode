using System;
using System.IO;
using BarRaider.SdTools;
using Microsoft.Extensions.Configuration;

namespace StreamDeckVSC
{
    internal class Program
    {
        private static MessageServer messageServer;

        private static void Main(string[] args)
        {
            var configuration = new Configuration();

            var configurationRoot = new ConfigurationBuilder()
                .AddIniFile(Path.Combine(AppContext.BaseDirectory, "settings.ini"), true, false)
                .Build();

            configurationRoot.GetSection("general").Bind(configuration);

            StartMessageServer(configuration);

#if DEBUG
            //System.Console.ReadLine();
#endif

            ConnectPlugin(args);

            StopMessageServer();
        }

        private static void ConnectPlugin(string[] args) => SDWrapper.Run(args);

        private static void StartMessageServer(Configuration configuration)
        {
            messageServer = new MessageServer(configuration.Host, configuration.Port);
            messageServer.Start();
        }

        private static void StopMessageServer() => messageServer?.Dispose();
    }
}
