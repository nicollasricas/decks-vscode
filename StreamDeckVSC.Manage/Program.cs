using System;
using System.Diagnostics;

namespace StreamDeckVSC.Manage
{
    internal class Program
    {
        private static void Main(string[] args) => TryInstallExtension();

        private static void TryInstallExtension()
        {
            Console.WriteLine("Stream Deck for Visual Studio Code");
            Console.Write("\nInstalling extension...");

            try
            {
                var process = Process.Start(new ProcessStartInfo()
                {
                    FileName = "cmd.exe",
                    Arguments = "/c code --install-extension nicollasr.vscode-streamdeck",
                    CreateNoWindow = true,
                    UseShellExecute = false
                });

                process.WaitForExit();
            }
            catch
            {
            }
        }
    }
}
