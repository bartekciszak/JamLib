# Contributing to JamLib

Thank you for your interest in contributing to JamLib! This document provides guidelines and instructions for contributing.

## Code of Conduct

All contributors are expected to:
- Treat all people with respect and dignity
- Be constructive and collaborative
- Welcome diverse perspectives and experiences
- Report inappropriate behavior to maintainers

## How to Contribute

### Reporting Issues

1. **Search existing issues** to avoid duplicates
2. **Provide detailed information**:
   - Operating system and version
   - .NET runtime version
   - Steps to reproduce
   - Expected vs. actual behavior
   - Log files or error messages

3. **Use clear, descriptive titles**
4. **Format code snippets** properly

### Feature Requests

1. **Clearly describe the feature** and its benefits
2. **Explain the use case** for parental monitoring
3. **Provide examples** of how it would work
4. **Consider security implications**

### Pull Requests

#### Before Starting
- Check for existing PRs addressing the same issue
- Create an issue first for major changes
- Discuss approach with maintainers

#### Process

1. **Fork the repository**
   ```bash
   git clone https://github.com/YOUR-USERNAME/JamLib.git
   cd JamLib
   ```

2. **Create a feature branch**
   ```bash
   git checkout -b feature/your-feature-name
   ```

3. **Make your changes**
   - Follow C# coding standards
   - Add comments for complex logic
   - Update documentation as needed
   - Test thoroughly

4. **Commit with clear messages**
   ```bash
   git commit -m "feat: add feature description"
   git commit -m "fix: resolve issue description"
   git commit -m "docs: update documentation"
   ```

5. **Push to your fork**
   ```bash
   git push origin feature/your-feature-name
   ```

6. **Create Pull Request**
   - Link related issues
   - Describe changes clearly
   - Explain testing approach
   - Include before/after if applicable

## Coding Standards

### C# Style Guidelines

```csharp
// Use meaningful names
private string _logDirectory;  // Private fields use _camelCase
public string LogDirectory { get; }  // Properties use PascalCase

// Use async/await for I/O operations
public async Task<string> ReadLogAsync(string path)
{
    return await File.ReadAllTextAsync(path);
}

// Use nullable reference types
public void ProcessLog(string? logPath)
{
    if (logPath == null) return;
}

// Add XML documentation
/// <summary>
/// Logs keyboard input to file.
/// </summary>
/// <param name="keyEvent">The keyboard event to log</param>
public void LogKey(KeyEventArgs keyEvent)
{
    // Implementation
}
```

### File Organization
- One class per file (with exceptions for small related classes)
- Namespace matches folder structure
- Use clear, descriptive names

## Testing

Before submitting a PR:

1. **Build successfully**
   ```bash
   dotnet build --configuration Release
   ```

2. **Test manually**
   - Test the feature/fix on Windows 11
   - Verify no regressions
   - Test edge cases

3. **Check for issues**
   - No compiler warnings
   - No unhandled exceptions
   - Proper error handling

## Documentation

Update documentation when:
- Adding new features
- Changing behavior
- Fixing significant bugs
- Improving clarity

Documentation files:
- `README.md` - Overview and basic usage
- `BUILDING.md` - Build and installation
- `SECURITY.md` - Security and privacy
- Inline code comments for complex logic

## Security Considerations

When contributing:

1. **Don't commit sensitive data** (keys, passwords, credentials)
2. **Consider security implications** of changes
3. **Use secure APIs** where available
4. **Handle errors safely** - don't expose sensitive information
5. **Test with malformed input** to prevent issues

## Licensing

By contributing, you agree that your contributions will be licensed under the MIT License.

## Questions?

Feel free to:
- Open an issue for questions
- Start a discussion
- Contact maintainers

## Recognition

Contributors will be recognized in:
- `CONTRIBUTORS.md` (when created)
- GitHub's contributors page
- Release notes

---

Thank you for helping make JamLib better! 🎉
