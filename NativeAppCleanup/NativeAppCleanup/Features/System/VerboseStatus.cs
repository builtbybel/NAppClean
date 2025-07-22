﻿using Microsoft.Win32;
using NativeAppCleanup;
using System;
using System.Threading.Tasks;

namespace Settings.System
{
    internal class VerboseStatus : FeatureBase
    {
        private const string keyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System";
        private const string valueName = "VerboseStatus";
        private const int recommendedValue = 1;

        public override string GetFeatureDetails()
        {
            return $"{keyName} | Value: {valueName} | Recommended Value: {recommendedValue}";
        }

        public override string ID()
        {
            return "Enable Verbose Logon status messages";
        }

        public override string Info()
        {
            return "This method allows you to see what processes are hanging when shutting down and turning on the machine.";
        }

        public override string SupportedOS() => "Windows 10, Windows 11";

        public override Task<bool> CheckFeature()
        {
            return Task.FromResult(
               Utils.IntEquals(keyName, valueName, recommendedValue)
         );
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
                Logger.Log("Code red in " + ex.Message, LogLevel.Error);
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
                Logger.Log("Code red in " + ex.Message, LogLevel.Error);
            }

            return false;
        }
    }
}