using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace NativeAppCleanup
{
    // Log level categories
    public enum LogLevel
    {
        Info,
        Warning,
        Error
    }

    public static class Logger
    {
        // Internal buffer to store all log entries
        private static readonly List<string> _logBuffer = new List<string>();

        // UI references for live logging
        private static TextBox _outputBox;    // TextBox in MainForm to display latest log
        private static Control _invoker;      // Used for thread-safe UI access

        /// <summary>
        /// Initializes the logger output target.
        /// </summary>
        /// <param name="outputBox">The TextBox control for displaying log messages</param>
        /// <param name="invokerForm">Usually the MainForm itself, for invoking UI updates</param>
        public static void Initialize(TextBox outputBox, Control invokerForm)
        {
            _outputBox = outputBox;
            _invoker = invokerForm;
        }

        /// <summary>
        /// Logs a message with timestamp and log level.
        /// Automatically updates the linked UI TextBox.
        /// </summary>
        public static void Log(string message, LogLevel level = LogLevel.Info)
        {
            var timestamp = DateTime.Now.ToString("HH:mm:ss");
            var levelStr = level.ToString().ToUpper();
            var logLine = $"[{timestamp}] [{levelStr}] {message}";

            _logBuffer.Add(logLine);               // Add to in-memory buffer
            //Debug.WriteLine(logLine);    // Also write to debug output

            // If UI not initialized, skip live update
            if (_outputBox == null || _invoker == null)
                return;

            if (_invoker.InvokeRequired)
            {
                _invoker.Invoke(new Action(() => _outputBox.Text = logLine));
            }
            else
            {
                _outputBox.Text = logLine;
            }
        }

        /// <summary>
        /// Returns the full log history as a single string.
        /// </summary>
        public static string GetLog()
        {
            return string.Join(Environment.NewLine, _logBuffer);
        }
    }
}
