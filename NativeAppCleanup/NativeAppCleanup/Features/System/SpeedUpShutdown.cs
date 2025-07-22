using Microsoft.Win32;
using NativeAppCleanup;
using System;
using System.Threading.Tasks;

namespace Settings.System
{
    internal class SpeedUpShutdown : FeatureBase
    {
        private const string keyName = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control";
        private const string valueName = "WaitToKillServiceTimeout";
        private const string recommendedValue = "1000"; // Set to 1000 ms (1 second)

        public override string GetFeatureDetails()
        {
            return $"{keyName} | Value: {valueName} | Recommended Value: {recommendedValue} ms";
        }

        public override string ID()
        {
            return "Speed Up Shutdown Time";
        }

        public override string Info()
        {
            return "This feature reduces the WaitToKillServiceTimeout value, which speeds up the shutdown process by reducing the time Windows waits for services to stop.";
        }

        public override string SupportedOS() => "Windows 10, Windows 11";

        public override Task<bool> CheckFeature()
        {
            return Task.FromResult(
                   Utils.StringEquals(keyName, valueName, recommendedValue)
             );
        }

        public override Task<bool> DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, valueName, recommendedValue, RegistryValueKind.String);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Logger.Log("Error in SpeedUpShutdown: " + ex.Message, LogLevel.Error);
            }

            return Task.FromResult(false);
        }

        public override bool UndoFeature()
        {
            try
            {
                Registry.SetValue(keyName, valueName, "5000", RegistryValueKind.String); // Default value
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("Error in SpeedUpShutdown (Undo): " + ex.Message, LogLevel.Error);
            }

            return false;
        }
    }
}