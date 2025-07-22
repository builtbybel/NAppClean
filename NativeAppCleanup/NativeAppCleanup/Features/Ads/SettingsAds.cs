using Microsoft.Win32;
using NativeAppCleanup;
using System;
using System.Threading.Tasks;

namespace Settings.Ads
{
    internal class SettingsAds : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager";
        private const string valueName = "SubscribedContent-338393Enabled";
        private const string valueName2 = "SubscribedContent-353694Enabled";
        private const string valueName3 = "SubscribedContent-353696Enabled";

        private const int recommendedValue = 0;

        public override string ID() => "Disable Settings Ads";

        public override string Info() => "This feature will disable ads in settings.";

        public override string SupportedOS() => "Windows 11";

        public override string GetFeatureDetails()
        {
            return $"{keyName} | Value: {valueName} + {valueName2} + {valueName3} | Recommended Value: {recommendedValue}";
        }

        public override Task<bool> CheckFeature()
        {
            return Task.FromResult(Utils.IntEquals(keyName, valueName, recommendedValue) &&
                   Utils.IntEquals(keyName, valueName2, recommendedValue) &&
                   Utils.IntEquals(keyName, valueName3, recommendedValue)
            );
        }

        public override Task<bool> DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, valueName, 0, Microsoft.Win32.RegistryValueKind.DWord);
                Registry.SetValue(keyName, valueName2, 0, Microsoft.Win32.RegistryValueKind.DWord);
                Registry.SetValue(keyName, valueName3, 0, Microsoft.Win32.RegistryValueKind.DWord);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Logger.Log("Code red in " + ex.Message, LogLevel.Error);
            }

            return Task.FromResult(false);
        }

        public override bool UndoFeature()
        {
            try
            {
                Registry.SetValue(keyName, valueName, 1, Microsoft.Win32.RegistryValueKind.DWord);
                Registry.SetValue(keyName, valueName2, 1, Microsoft.Win32.RegistryValueKind.DWord);
                Registry.SetValue(keyName, valueName3, 1, Microsoft.Win32.RegistryValueKind.DWord);

                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("Code red in " + ex.Message, LogLevel.Error);
            }

            return false;
        }
    }
}