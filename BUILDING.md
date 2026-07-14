# JamLib Build & Installation Guide

## Prerequisites

- Windows 11 or Windows 10 (build 19041 or later)
- Visual Studio 2022 (Community or higher) or Visual Studio Code
- .NET 8 SDK
- Windows 11 SDK (for MSIX packaging)

## Building from Source

### Step 1: Clone Repository
```bash
git clone https://github.com/bartekciszak/JamLib.git
cd JamLib
```

### Step 2: Build Solution
```bash
dotnet build --configuration Release
```

### Step 3: Run Application
```bash
dotnet run --project JamLib.Wpf --configuration Release
```

## Creating MSIX Package

### Method 1: Using Visual Studio (Recommended)

1. Open `JamLib.sln` in Visual Studio 2022
2. Right-click on `JamLib.Wpf` project → **Publish**
3. Select **Windows Application Packaging Project**
4. Follow the wizard to create MSIX package
5. Package will be created in the output directory

### Method 2: Command Line

```bash
# Publish the application
dotnet publish JamLib.Wpf/JamLib.Wpf.csproj -c Release -f net8.0-windows -r win-x64 --self-contained false

# Package as MSIX (requires Windows SDK)
makeappx pack -d "JamLib.Wpf\bin\Release\net8.0-windows\win-x64\publish" -o JamLib.msix
```

### Method 3: Using GitHub Actions

The repository includes a GitHub Actions workflow that automatically builds on push. Download artifacts from:
- **Actions** → Latest workflow run → **Artifacts**

## Installation Options

### Option 1: MSIX Installation (Recommended)

1. Download `JamLib.msix` file
2. Double-click the `.msix` file
3. Click **Install** in the installation dialog
4. Launch JamLib from Start Menu

### Option 2: Direct Execution

After building:
```bash
cd JamLib.Wpf/bin/Release/net8.0-windows/win-x64/publish
JamLib.exe
```

## Post-Installation Setup

### Administrator Privileges

JamLib requires administrator privileges to capture global keyboard input.

**To enable automatically:**

1. Right-click JamLib shortcut → **Properties**
2. Click **Advanced**
3. Check **Run as an administrator**
4. Click **OK** → **Apply** → **OK**

**Or create a batch launcher:**

Create `RunJamLib.bat`:
```batch
@echo off
cd %APPDATA%\JamLib
JamLib.exe
pause
```

Right-click → **Send to** → **Desktop (Create shortcut)**

### Auto-start Configuration

To launch JamLib on Windows startup:

1. Press `Win + R`, type `shell:startup`
2. Create shortcut to `JamLib.exe` in this folder
3. Right-click → **Properties** → **Advanced** → **Run as administrator** → **OK**

## Troubleshooting

### Build Fails
- Ensure .NET 8 SDK is installed: `dotnet --version`
- Clean and rebuild: `dotnet clean && dotnet build`
- Check Visual Studio is up to date

### Application Won't Start
- Run as administrator
- Check Windows Defender isn't blocking execution
- Verify .NET 8 runtime is installed

### Keyboard Hook Not Working
- Application must run as administrator
- Only one keyboard hook can be active at a time
- Disable other monitoring software temporarily
- Try restarting the application

### Log Files Not Created
- Check `%APPDATA%\JamLib\Logs\` exists
- Verify NTFS file system permissions
- Check disk space availability

## Next Steps

1. **Run the Application**: Open JamLib from Start Menu
2. **Start Logging**: Click "Start Logging" button
3. **View Logs**: Type something and observe in log files
4. **Configure Auto-start**: Follow setup above for automatic launching

## Additional Resources

- [.NET 8 Documentation](https://learn.microsoft.com/en-us/dotnet/)
- [WPF Documentation](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/)
- [MSIX Documentation](https://learn.microsoft.com/en-us/windows/msix/)
- [Windows API Reference](https://learn.microsoft.com/en-us/windows/win32/api/)

## Support

For issues or questions, please visit: [GitHub Issues](https://github.com/bartekciszak/JamLib/issues)
