namespace VSCodeStreamDeck.Messages
{
    public class ChangeCurrentClientMessage
    {
        public const string Id = "change-current-client";

        public string SessionId { get; set; }
    }
}
