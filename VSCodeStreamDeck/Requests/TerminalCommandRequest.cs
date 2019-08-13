namespace VSCodeStreamDeck.Requests
{
    class TerminalCommandRequest : Request
    {
        public override string Id => SanitizeId(nameof(TerminalCommandRequest));
    }
}
