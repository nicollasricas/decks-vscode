namespace VSStreamDeck.Messages
{
    public class ChangeActiveSessionMessage
    {
        public string SessionId { get; set; }
    }

    public class ActiveSessionChangedMessage
    {
        public string SessionId { get; set; }
    }
}
