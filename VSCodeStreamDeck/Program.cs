using System;
using System.IO;
using BarRaider.SdTools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VSCodeStreamDeck
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = LoadOptions();

            StartMessageServer(options);

//#if DEBUG
//            Console.ReadKey(true);
//#endif

            ConnectPlugin(args);
        }

        private static void ConnectPlugin(string[] args) => SDWrapper.Run(args);

        private static ProgramOptions LoadOptions()
        {
            var settingsPath = "./settings.json";

            if (File.Exists(settingsPath))
            {
                return JsonConvert.DeserializeObject<ProgramOptions>(File.ReadAllText(settingsPath));
            }
            else
            {
                var options = new ProgramOptions();

                File.WriteAllText(settingsPath, JsonConvert.SerializeObject(options, Formatting.Indented));

                return options;
            }
        }

        private static void StartMessageServer(ProgramOptions options) => new VSServer(options.Host, options.Port).Start();
    }
}
