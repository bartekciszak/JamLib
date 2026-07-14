# JamLib - Parental Control Keyboard Logger

A Windows 11 desktop application for parental monitoring that logs all keyboard input to organized text files.

## Features

- **Global Keyboard Logging**: Captures all keyboard input system-wide using low-level hooks
- **Automatic Log Management**: Creates organized log directories with timestamped daily logs
- **WPF User Interface**: Clean, intuitive interface for viewing and managing logs
- **MSIX Installation**: Professional Windows installer for easy deployment
- **Local Device Only**: Designed exclusively for single-device parental monitoring
- **Real-time Monitoring**: View logs as they're being created
- **Easy Log Access**: Quick access to log folder and log file contents

## System Requirements

- Windows 11 (Windows 10 build 19041 or later)
- .NET 8 runtime
- Administrator privileges (for keyboard hook functionality)

## Installation

### Via MSIX Package
1. Download the latest `.msix` file from releases
2. Double-click to install
3. Follow the installation wizard
4. Launch JamLib from Start Menu

### Manual Build
1. Clone this repository
2. Open `JamLib.sln` in Visual Studio 2022 or later
3. Build the solution (Release configuration recommended)
4. Run `JamLib.Wpf` project

## Usage

1. **Start Logging**: Click "Start Logging" button to begin capturing keyboard input
2. **View Logs**: Select log files from the list to view their contents
3. **Open Log Folder**: Click "Open Log Folder" to access logs in File Explorer
4. **Stop Logging**: Click "Stop Logging" to end the current logging session

## Log File Location

Logs are automatically stored in:
```
%APPDATA%\JamLib\Logs\keyboard_log_YYYY-MM-DD.txt
```

Example: `C:\Users\YourUsername\AppData\Roaming\JamLib\Logs\keyboard_log_2026-07-14.txt`

## Project Structure

```
JamLib/
├── JamLib.Core/              # Core logging and keyboard hook library
│   ├── KeyboardHook.cs       # Global keyboard capture implementation
│   └── LogManager.cs         # Log file management and organization
├── JamLib.Wpf/               # WPF desktop application
│   ├── App.xaml              # Application entry point
│   ├── MainWindow.xaml       # Main UI window
│   └── MainWindow.xaml.cs    # UI logic and event handlers
├── JamLib.Package/           # MSIX package configuration
│   └── Package.appxmanifest  # Package manifest for installer
└── JamLib.sln               # Solution file
```

## Key Technologies

- **.NET 8**: Modern, cross-platform framework
- **WPF**: Windows Presentation Foundation for desktop UI
- **Windows API**: Low-level keyboard hooking via `SetWindowsHookEx`
- **MSIX**: Modern Windows application package format

## Security & Privacy Notes

⚠️ **Important**: This application is designed for parental monitoring on personal devices only.

- The application requires **administrator privileges** to function properly
- Keyboard logs are stored **locally** on the device in plaintext
- No data is transmitted over the network
- This application is intended for **legal parental monitoring** purposes only

## Development

### Prerequisites
- Visual Studio 2022 (Community or higher)
- .NET 8 SDK
- Windows 11 SDK

### Building
```bash
dotnet build
```

### Running
```bash
dotnet run --project JamLib.Wpf
```

### Creating MSIX Package
```bash
dotnet publish -c Release -f net8.0-windows10.0.19041.0 -r win-x64
```

## Troubleshooting

### Application doesn't capture keyboard input
- Ensure the application is running with **administrator privileges**
- Check that no other keyboard hooks are interfering
- Restart the application

### Log files not appearing
- Verify that logs directory exists: `%APPDATA%\JamLib\Logs\`
- Check Windows Defender isn't blocking file creation
- Ensure user has write permissions to AppData folder

### MSIX Installation fails
- Ensure you're on Windows 11 or Windows 10 build 19041+
- Check that you have administrator privileges
- Disable SmartScreen if it's blocking installation

## License

This project is provided for educational and parental monitoring purposes on personal devices only.

## Disclaimer

This application is intended for use by parents to monitor their own children's device usage on devices they own. Unauthorized monitoring of others' activities may be illegal. Always ensure compliance with local laws and regulations.

## Support

For issues, questions, or feature requests, please open an issue on GitHub.
