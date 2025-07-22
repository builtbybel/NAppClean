using Microsoft.Win32;
using NativeAppCleanup;
using System;
using System.Threading.Tasks;

namespace Settings.UI
{
    internal class DisableSearchBoxSuggestions : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\Explorer";
        private const string valueName = "DisableSearchBoxSuggestions";
        private const int recommendedValue = 1;

        public override string GetFeatureDetails()
        {
            return $"{keyName} | Value: {valueName} | Recommended Value: {recommendedValue}";
        }

        public override string ID()
        {
            return "Disable Search Box Suggestions";
        }

        public override string Info()
        {
            return "This feature disables Bing search and web suggestions in the Windows Start Menu.";
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
                Logger.Log("Error in DisableSearchBoxSuggestions: " + ex.Message, LogLevel.Error);
                return Task.FromResult(false);
            }
        }

        public override bool UndoFeature()
        {
            try
            {
                Registry.SetValue(keyName, valueName, 0, RegistryValueKind.DWord); // 0 = Enable suggestions
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("Error undoing DisableSearchBoxSuggestions: " + ex.Message, LogLevel.Error);
                return false;
            }
        }
    }
}