﻿using Microsoft.Win32;
using NativeAppCleanup;
using System;
using System.Threading.Tasks;

namespace Settings.System
{
    internal class MenuShowDelay : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Control Panel\Desktop";
        private const string valueName = "MenuShowDelay";
        private const string recommendedValue = "10";

        public override string GetFeatureDetails()
        {
            return $"{keyName} | Value: {valueName} | Recommended Value: \"{recommendedValue}\" (faster menu response)";
        }

        public override string ID()
        {
            return "Speed Up Menu Show Delay";
        }

        public override string Info()
        {
            return "Speeds up the appearance of menus and submenus by lowering the default delay. This improves the perceived responsiveness of the UI.";
        }

        public override string SupportedOS() => "Windows 10, Windows 11";

        public override Task<bool> CheckFeature()
        {
            return Task.FromResult(Utils.StringEquals(keyName, valueName, recommendedValue));
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
                Logger.Log("Code red in " + ex.Message, LogLevel.Error);
            }

            return Task.FromResult(false);
        }

        public override bool UndoFeature()
        {
            try
            {
                Registry.SetValue(keyName, valueName, "400", RegistryValueKind.String); // Default is 400 on Windows 11
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