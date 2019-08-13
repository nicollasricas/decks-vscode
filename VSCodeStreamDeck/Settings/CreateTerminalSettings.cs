namespace VSCodeStreamDeck.Settings
{
    public class CreateTerminalSettings : KeySettings
    {
        public bool PreserveFocus { get; set; } = true;

        public string Shell { get; set; } = "powershell";
    }
}
