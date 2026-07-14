# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2026-07-14

### Added
- Initial release of JamLib
- Global keyboard hook implementation for capturing all keyboard input
- Log management system with automatic daily log file creation
- WPF user interface for viewing and managing logs
- Real-time keyboard activity monitoring
- Log file browser with content viewer
- Auto-refresh functionality for log files
- Open log folder in File Explorer
- Administrator privileges detection
- MSIX packaging support for Windows 11
- Comprehensive documentation (README, BUILDING, SECURITY guides)
- GitHub Actions CI/CD workflow
- MIT License
- Contributing guidelines

### Features
- **Keyboard Logging**: Captures all keyboard input system-wide
- **Automatic Log Organization**: Creates dated log files in AppData folder
- **Local Storage Only**: All logs stored locally, no cloud sync
- **WPF Interface**: Clean, modern Windows 11 compatible UI
- **Log Viewing**: Browse and view log file contents in application
- **Parental Control**: Designed specifically for parent-child device monitoring

### Technical Details
- Built with C# and .NET 8
- Uses Windows API SetWindowsHookEx for keyboard capture
- WPF for user interface
- MSIX for modern Windows installation
- Cross-project architecture (Core library + WPF app)

## [Unreleased]

### Planned Features
- [ ] Encryption support for log files
- [ ] Application usage tracking
- [ ] Website/URL blocking capability
- [ ] Time-based restrictions
- [ ] Multi-user profiles
- [ ] Remote parent portal (cloud sync)
- [ ] Custom keyword alerts
- [ ] Screenshot capability
- [ ] Activity reports and analytics
- [ ] Dark mode support

### Known Issues
- None reported yet

---

## Version History

### 1.0.0 (2026-07-14)
- Initial public release

---

## How to Report Changes

When contributing changes, please update this CHANGELOG:

1. Add an entry under "Unreleased" section
2. Categorize under: Added, Changed, Deprecated, Removed, Fixed, Security
3. Follow the Keep a Changelog format
4. Include PR/issue reference if applicable

### Example Entry
```markdown
### Added
- New feature description (#123)

### Fixed
- Bug fix description (#456)
```

## Release Process

1. Update version number in relevant files
2. Move entries from "Unreleased" to new version section
3. Include release date in format YYYY-MM-DD
4. Create GitHub release with changelog summary
5. Tag commit with version number (v1.0.0)
