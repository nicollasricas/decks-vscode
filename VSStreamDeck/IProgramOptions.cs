using Config.Net;

namespace VSCodeStreamDeck
{
    public interface IProgramOptions
    {
        [Option(Alias = "host")]
        string Host { get; }

        [Option(Alias = "port")]
        int Port { get; }
    }
}
