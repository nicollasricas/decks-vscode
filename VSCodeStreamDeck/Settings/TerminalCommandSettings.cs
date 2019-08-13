namespace VSCodeStreamDeck.Settings
{
    public class TerminalCommandSettings : KeySettings
    {
        public string Command { get; set; }

        public string BeforeCommand { get; set; }

        public bool CreateTerminal { get; set; }
    }
}
