using Config.Net;

namespace VSStreamDeck
{
    public interface IProgramOptions
    {
        [Option(Alias = "host")]
        string Host { get; }

        [Option(Alias = "port")]
        int Port { get; }
    }
}
