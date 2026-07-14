using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using JamLib.Core;

namespace JamLib.Wpf
{
    public partial class MainWindow : Window
    {
        private KeyboardHook? _keyboardHook;
        private LogManager? _logManager;
        private ObservableCollection<string> _logFiles;

        public MainWindow()
        {
            InitializeComponent();
            _logFiles = new ObservableCollection<string>();
            LogFilesList.ItemsSource = _logFiles;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _logManager = new LogManager();
                UpdateLogFilesList();
                UpdateStatusBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing application: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_keyboardHook != null && _keyboardHook.IsHooked)
                    return;

                _keyboardHook = new KeyboardHook();
                _keyboardHook.KeyPressed += KeyboardHook_KeyPressed;
                _keyboardHook.Start();

                StartButton.IsEnabled = false;
                StopButton.IsEnabled = true;
                StatusText.Text = "Status: Logging Active";
                StatusText.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.LimeGreen);
                _logManager?.LogMessage("=== Logging Started ===");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting keyboard hook: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_keyboardHook != null)
                {
                    _logManager?.LogMessage("=== Logging Stopped ===");
                    _keyboardHook.Stop();
                    _keyboardHook.Dispose();
                    _keyboardHook = null;
                }

                StartButton.IsEnabled = true;
                StopButton.IsEnabled = false;
                StatusText.Text = "Status: Ready";
                StatusText.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(39, 174, 96));
                UpdateLogFilesList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error stopping keyboard hook: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void KeyboardHook_KeyPressed(object? sender, KeyEventArgs e)
        {
            _logManager?.LogKey(e);
        }

        private void OpenLogFolder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_logManager != null && Directory.Exists(_logManager.LogDirectory))
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "explorer.exe",
                        Arguments = _logManager.LogDirectory,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("Log directory does not exist.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening log folder: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshLogs_Click(object sender, RoutedEventArgs e)
        {
            UpdateLogFilesList();
        }

        private void LogFilesList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (LogFilesList.SelectedItem is string selectedFile)
            {
                try
                {
                    var content = _logManager?.GetLogContent(selectedFile) ?? "Error reading file.";
                    LogContent.Text = content;
                }
                catch (Exception ex)
                {
                    LogContent.Text = $"Error reading file: {ex.Message}";
                }
            }
        }

        private void UpdateLogFilesList()
        {
            _logFiles.Clear();
            if (_logManager != null)
            {
                var files = _logManager.GetLogFiles();
                Array.Sort(files, (a, b) => b.CompareTo(a)); // Sort descending (newest first)

                foreach (var file in files)
                {
                    _logFiles.Add(Path.GetFileName(file));
                }
            }
        }

        private void UpdateStatusBar()
        {
            if (_logManager != null)
            {
                LogPathText.Text = $"Logs Location: {_logManager.LogDirectory}";
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_keyboardHook != null && _keyboardHook.IsHooked)
            {
                _keyboardHook.Stop();
                _keyboardHook.Dispose();
            }
        }
    }
}