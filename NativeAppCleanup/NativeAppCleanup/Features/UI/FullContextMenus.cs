using Microsoft.Win32;
using NativeAppCleanup;
using System;
using System.Threading.Tasks;

namespace Settings.Personalization
{
    internal class FullContextMenus : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\SOFTWARE\CLASSES\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32";

        public override string GetFeatureDetails()
        {
            return $"{keyName}";
        }

        public override string ID()
        {
            return "Show Full context menus in Windows 11";
        }

        public override string Info()
        {
            return "This feature will enable full context menus";
        }

        public override string SupportedOS() => "Windows 11";

        public override Task<bool> CheckFeature()
        {
            try
            {
                object value = Registry.GetValue(keyName, "", null);
                return Task.FromResult(value != null); // Return true if value is not null
            }
            catch (Exception ex)
            {
                Logger.Log("Error occurred while checking: " + ex.Message, LogLevel.Error);
                return Task.FromResult(false);
            }
        }

        public override Task<bool> DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "", "", RegistryValueKind.String);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Logger.Log("Error occurred while enabling: " + ex.Message, LogLevel.Error);
                return Task.FromResult(false);
            }
        }

        public override bool UndoFeature()
        {
            try
            {
                Registry.CurrentUser.DeleteSubKeyTree(@"Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}", false);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("Error occurred while disabling: " + ex.Message, LogLevel.Error);
                return false;
            }
        }
    }
}