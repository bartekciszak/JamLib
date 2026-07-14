# JamLib Project

**Status**: ✅ Active Development

## Quick Links

- 📖 [README](README.md) - Overview and features
- 🏗️ [Building Guide](BUILDING.md) - Build and installation instructions
- 🔒 [Security Policy](SECURITY.md) - Security and privacy information
- 🤝 [Contributing Guide](CONTRIBUTING.md) - How to contribute
- 📝 [Changelog](CHANGELOG.md) - Version history
- ⚖️ [License](LICENSE) - MIT License

## Getting Started

### For Users

1. **Download** the latest MSIX package from [Releases](https://github.com/bartekciszak/JamLib/releases)
2. **Install** by double-clicking the .msix file
3. **Launch** JamLib from the Start Menu
4. **Configure** to run as administrator for proper functionality
5. **Start Logging** to begin keyboard monitoring

### For Developers

1. **Clone** the repository
   ```bash
   git clone https://github.com/bartekciszak/JamLib.git
   cd JamLib
   ```

2. **Build** the solution
   ```bash
   dotnet build --configuration Release
   ```

3. **Run** the application
   ```bash
   dotnet run --project JamLib.Wpf
   ```

## Project Structure

```
JamLib/
├── JamLib.Core/                 # Core library
│   ├── KeyboardHook.cs          # Global keyboard capture
│   └── LogManager.cs            # Log file management
├── JamLib.Wpf/                  # WPF application
│   ├── App.xaml                 # Application definition
│   ├── MainWindow.xaml          # Main UI window
│   └── MainWindow.xaml.cs       # UI logic
├── JamLib.Package/              # MSIX package project
│   └── Package.appxmanifest     # Package manifest
├── .github/                     # GitHub configuration
│   └── workflows/               # CI/CD workflows
├── BUILDING.md                  # Build guide
├── CHANGELOG.md                 # Version history
├── CONTRIBUTING.md              # Contribution guidelines
├── SECURITY.md                  # Security policy
├── README.md                    # Project overview
└── LICENSE                      # MIT License
```

## Technology Stack

- **Framework**: .NET 8
- **UI**: WPF (Windows Presentation Foundation)
- **Packaging**: MSIX
- **Language**: C#
- **API**: Windows API (SetWindowsHookEx)
- **Version Control**: Git/GitHub

## Key Features

✅ Global keyboard logging
✅ Automatic log file management
✅ Clean WPF interface
✅ Local storage only
✅ MSIX installer
✅ Administrator aware
✅ Real-time monitoring
✅ Log viewing in-app

## System Requirements

- Windows 11 (or Windows 10 build 19041+)
- .NET 8 runtime
- Administrator privileges (for logging)
- 50 MB disk space minimum

## Support & Documentation

- 📚 [Full Documentation](BUILDING.md)
- 🐛 [Report Issues](https://github.com/bartekciszak/JamLib/issues)
- 💡 [Suggest Features](https://github.com/bartekciszak/JamLib/discussions)
- 📧 Questions? Check existing discussions first

## Legal Notice

⚠️ **This application is for parental monitoring on devices you own.** Unauthorized monitoring of others may be illegal. See [SECURITY.md](SECURITY.md) and [LICENSE](LICENSE) for complete details.

## License

MIT License - See [LICENSE](LICENSE) file for details.

Copyright © 2026 JamLib Contributors

## Contributors

- **Bartek Ciszak** - Creator & Maintainer

---

**Made with ❤️ for parental control monitoring**
