using Microsoft.Win32;
using NativeAppCleanup;
using System;
using System.Threading.Tasks;

namespace Settings.System
{
    internal class TaskbarEndTask : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced\TaskbarDeveloperSettings";
        private const string valueName = "TaskbarEndTask";
        private const int recommendedValue = 1;

        public override string GetFeatureDetails()
        {
            return $"{keyName} | Value: {valueName} | Recommended Value: {recommendedValue}";
        }

        public override string ID()
        {
            return "Enable End Task";
        }

        public override string Info()
        {
            return "Adds 'End Task' to the Windows 11 taskbar context menu, allowing you to directly kill unresponsive apps.";
        }

        public override string SupportedOS() => "Windows 11";

        public override Task<bool> CheckFeature()
        {
            return Task.FromResult(Utils.IntEquals(keyName, valueName, recommendedValue));
        }

        public override Task<bool> DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, valueName, recommendedValue, RegistryValueKind.DWord);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Logger.Log("Failed to enable End Task: " + ex.Message, LogLevel.Error);
            }

            return Task.FromResult(false);
        }

        public override bool UndoFeature()
        {
            try
            {
                Registry.SetValue(keyName, valueName, 0, RegistryValueKind.DWord);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("Failed to disable End Task: " + ex.Message, LogLevel.Error);
            }

            return false;
        }
    }
}