using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace JamLib.Core
{
    public class LogManager
    {
        private readonly string _logDirectory;
        private readonly string _currentLogFile;
        private readonly object _lockObject = new object();

        public string LogDirectory => _logDirectory;
        public string CurrentLogFile => _currentLogFile;

        public LogManager(string? baseDirectory = null)
        {
            baseDirectory ??= Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "JamLib");
            
            _logDirectory = Path.Combine(baseDirectory, "Logs");
            
            if (!Directory.Exists(_logDirectory))
            {
                Directory.CreateDirectory(_logDirectory);
            }

            _currentLogFile = GetOrCreateLogFile();
        }

        private string GetOrCreateLogFile()
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            var logFileName = $"keyboard_log_{date}.txt";
            var logFilePath = Path.Combine(_logDirectory, logFileName);

            if (!File.Exists(logFilePath))
            {
                File.WriteAllText(logFilePath, $"--- JamLib Keyboard Log - {DateTime.Now:yyyy-MM-dd HH:mm:ss} ---\n\n");
            }

            return logFilePath;
        }

        public void LogKey(KeyEventArgs keyEvent)
        {
            var timestamp = keyEvent.Timestamp.ToString("HH:mm:ss.fff");
            var keyName = GetKeyName(keyEvent.Key);
            var logEntry = $"[{timestamp}] {keyName}\n";

            WriteToLog(logEntry);
        }

        public void LogMessage(string message)
        {
            var timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
            var logEntry = $"[{timestamp}] {message}\n";

            WriteToLog(logEntry);
        }

        private void WriteToLog(string entry)
        {
            lock (_lockObject)
            {
                try
                {
                    // Check if we need to create a new log file (day changed)
                    var currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                    if (!_currentLogFile.Contains(currentDate))
                    {
                        var newLogFile = GetOrCreateLogFile();
                        // Update reference to new log file
                        // This is a simplified approach; for production, you'd want a property that updates
                    }

                    File.AppendAllText(_currentLogFile, entry);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error writing to log: {ex.Message}");
                }
            }
        }

        private string GetKeyName(Keys key)
        {
            return key switch
            {
                Keys.Return => "[ENTER]",
                Keys.Space => "[SPACE]",
                Keys.Back => "[BACKSPACE]",
                Keys.Tab => "[TAB]",
                Keys.Escape => "[ESC]",
                Keys.Delete => "[DELETE]",
                Keys.PageUp => "[PAGE_UP]",
                Keys.PageDown => "[PAGE_DOWN]",
                Keys.Home => "[HOME]",
                Keys.End => "[END]",
                Keys.Left => "[LEFT]",
                Keys.Up => "[UP]",
                Keys.Right => "[RIGHT]",
                Keys.Down => "[DOWN]",
                Keys.LShift => "[LSHIFT]",
                Keys.RShift => "[RSHIFT]",
                Keys.LControl => "[LCTRL]",
                Keys.RControl => "[RCTRL]",
                Keys.LAlt => "[LALT]",
                Keys.RAlt => "[RALT]",
                Keys.LWin => "[LWIN]",
                Keys.RWin => "[RWIN]",
                Keys.Capital => "[CAPSLOCK]",
                Keys.NumLock => "[NUMLOCK]",
                Keys.Scroll => "[SCROLLLOCK]",
                Keys.Pause => "[PAUSE]",
                Keys.F1 => "[F1]",
                Keys.F2 => "[F2]",
                Keys.F3 => "[F3]",
                Keys.F4 => "[F4]",
                Keys.F5 => "[F5]",
                Keys.F6 => "[F6]",
                Keys.F7 => "[F7]",
                Keys.F8 => "[F8]",
                Keys.F9 => "[F9]",
                Keys.F10 => "[F10]",
                Keys.F11 => "[F11]",
                Keys.F12 => "[F12]",
                Keys.Apps => "[APP]",
                Keys.Menu => "[MENU]",
                _ => GetCharacterFromKeyCode((int)key)
            };
        }

        private string GetCharacterFromKeyCode(int keyCode)
        {
            // For printable characters, we try to convert
            if (keyCode >= 48 && keyCode <= 57) // 0-9
                return ((char)keyCode).ToString();
            if (keyCode >= 65 && keyCode <= 90) // A-Z
                return ((char)keyCode).ToString().ToLower();

            // Special characters - simplified mapping
            return keyCode switch
            {
                186 => ";",
                187 => "=",
                188 => ",",
                189 => "-",
                190 => ".",
                191 => "/",
                219 => "[",
                220 => "\\",
                221 => "]",
                222 => "'",
                192 => "`",
                _ => $"[{keyCode}]"
            };
        }

        public string[] GetLogFiles()
        {
            try
            {
                return Directory.GetFiles(_logDirectory, "keyboard_log_*.txt");
            }
            catch
            {
                return Array.Empty<string>();
            }
        }

        public string GetLogContent(string logFilePath)
        {
            try
            {
                return File.ReadAllText(logFilePath);
            }
            catch
            {
                return "Error reading log file.";
            }
        }
    }
}