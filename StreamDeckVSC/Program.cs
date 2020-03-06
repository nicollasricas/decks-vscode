using System;
using System.Diagnostics;
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
                .UseIniFile("settings.ini")
                .Build();

            if (!options.RequirementNotified)
            {
                InstallRequirements();

                options.RequirementNotified = true;
            }

            StartMessageServer(options);

#if DEBUG
            //System.Console.ReadLine();
#endif

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

        private static void InstallRequirements()
        {
            try
            {
                Process.Start(new ProcessStartInfo()
                {
                    FileName = "manage.exe",
                    CreateNoWindow = false,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                Logger.Instance.LogMessage(TracingLevel.ERROR, ex.ToString());
            }
        }
    }
}
