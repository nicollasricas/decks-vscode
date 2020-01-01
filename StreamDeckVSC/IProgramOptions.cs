using Config.Net;

namespace StreamDeckVSC
{
    public interface IProgramOptions
    {
        [Option(Alias = "general.host", DefaultValue = "127.0.0.1")]
        string Host { get; }

        [Option(Alias = "general.port", DefaultValue = 48969)]
        int Port { get; }

        [Option(Alias = "general.requirementNotified")]
        bool RequirementNotified { get; set; }
    }
}