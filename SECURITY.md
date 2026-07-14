# Security Policy

## Important Notice

JamLib is a parental control application designed for **monitoring children's device usage on devices owned by parents**. This application should only be used for lawful purposes with appropriate consent.

## Data Handling

### What JamLib Collects
- Keyboard input from the local device
- Timestamps of keyboard activity
- Log files stored locally in `%APPDATA%\JamLib\Logs\`

### What JamLib Does NOT Do
- Send data over the network
- Store data in the cloud
- Contact external services
- Transmit information to third parties

### Data Storage
- All logs are stored **locally** on the device
- Logs are in **plaintext** format
- Users have full control over log files
- Logs can be deleted manually at any time

## Privacy Considerations

1. **Consent**: Ensure appropriate consent before using this application
2. **Transparency**: Inform users that monitoring is active
3. **Legal Compliance**: Verify local laws permit parental monitoring
4. **Data Security**: Store logs securely and restrict access

## Application Security

### Requires Administrator Privileges
- Necessary for global keyboard hook functionality
- Only install from trusted sources
- Run only on devices you own or have permission to monitor

### Windows API Usage
- Uses `SetWindowsHookEx` for keyboard capture
- Operates at low level (WH_KEYBOARD_LL)
- Subject to Windows security policies

## Reporting Security Issues

If you discover a security vulnerability in JamLib:

1. Do NOT open a public GitHub issue
2. Email details to: [Your Email]
3. Include:
   - Description of the vulnerability
   - Steps to reproduce
   - Potential impact
   - Suggested fix (if available)

We will acknowledge receipt within 48 hours and work toward a resolution.

## Legal Disclaimer

**IMPORTANT**: This application is provided as-is for educational and parental monitoring purposes. Users are responsible for:

1. **Legal Compliance**: Ensuring use complies with all applicable laws
2. **Consent**: Obtaining appropriate consent for monitoring
3. **Data Protection**: Securely storing collected data
4. **Ethical Use**: Using the application responsibly and ethically

The developers and maintainers are not responsible for:
- Illegal use of this application
- Unauthorized monitoring
- Data breaches or loss
- Violation of privacy laws

## Updates & Support

- Keep JamLib updated for security patches
- Review privacy policy before use
- Report concerns to the development team
- Check GitHub for security announcements

---

**By using JamLib, you agree to use it only for lawful purposes with appropriate consent.**
