using BarRaider.SdTools;
using Config.Net;

namespace VSStreamDeck
{
    internal class Program
    {
        private static MessageServer messageServer;

        private static void Main(string[] args)
        {
            var options = new ConfigurationBuilder<IProgramOptions>()
                .UseJsonConfig()
                .Build();

            StartMessageServer(options);

            //#if DEBUG
            //Console.ReadKey(true);
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
    }
}
