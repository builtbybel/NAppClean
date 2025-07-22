using NativeAppCleanup;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Settings.System
{
    internal class WingetUpgradeAll : FeatureBase
    {
        public override string GetFeatureDetails()
        {
            return "winget upgrade --include-unknown";
        }

        public override string ID()
        {
            return "Winget App Updates";
        }
        public override string SupportedOS() => "Windows 10, Windows 11";

        public override string Info()
        {
            return "Automatically searches for available app updates using the Windows package manager 'winget' and installs them in a new Windows Terminal window. It runs 'winget upgrade --include-unknown' to list all available updates, including manually installed apps, and then 'winget upgrade --all --include-unknown' to install them. No manual interaction is required.";
        }

        public override async Task<bool> CheckFeature()
        {
            Logger.Log("📦 Checking all available updates via winget...", LogLevel.Warning);
            Logger.Log("This may take a while, please be patient.", LogLevel.Warning);

            try
            {
                string output = await ExecuteCommand("winget upgrade --include-unknown");

                Logger.Log("Winget upgrade check:\n" + output, LogLevel.Info);

                return output.ToLower().Contains("available");
            }
            catch (Exception ex)
            {
                Logger.Log("Winget check failed: " + ex.Message, LogLevel.Error);
                return false;
            }
        }

        public override Task<bool> DoFeature()
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    LaunchInTerminal("winget upgrade --all --include-unknown");
                    return true;
                }
                catch (Exception ex)
                {
                    Logger.Log("Failed to run winget upgrade: " + ex.Message, LogLevel.Error);
                    return false;
                }
            });
        }

        public override bool UndoFeature()
        {
            Logger.Log("Winget upgrades cannot be undone.", LogLevel.Warning);
            return false;
        }

        private void LaunchInTerminal(string command)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "wt.exe",
                Arguments = "-w 0 nt -p \"Windows PowerShell\" powershell -NoExit -Command \"" + command + "\"",
                UseShellExecute = true
            };

            Process.Start(startInfo);
        }

        private Task<string> ExecuteCommand(string command)
        {
            var tcs = new TaskCompletionSource<string>();

            try
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c " + command,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                var process = new Process();
                process.StartInfo = startInfo;

                string output = "";

                process.OutputDataReceived += (sender, args) =>
                {
                    if (args.Data != null)
                        output += args.Data + Environment.NewLine;
                };

                process.EnableRaisingEvents = true;
                process.Exited += (sender, args) =>
                {
                    tcs.TrySetResult(output);
                    process.Dispose();
                };

                process.Start();
                process.BeginOutputReadLine();
            }
            catch (Exception ex)
            {
                tcs.TrySetException(ex);
            }

            return tcs.Task;
        }
    }
}