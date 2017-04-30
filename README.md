# QuickSFTP

QuickSFTP is a tool, which allows an unexperienced person to upload files onto a server
using the SFTP protocol just by typing the password and choosing the file(s) from a standard Windows dialog.

Therrfore, the tool has to be preconfigured by a more experienced person.

## Scenario

I've tinkerd this tool quickly, because a friend of mine wanted to send me uncompressed audio WAV files 
he and his band recorded, recently. I supposed him to upload this to my server but he was
struggeling with FileZilla for reasons ...

With QuickSFTP he was able to upload me his files with just his password und one click.

## Dependencies
* .NET Framework 4.6.1

## Getting Started
* Dowload lates release of QuickSFTP from GitHub: https://github.com/viper3400/QuickSFTP/releases/latest
* Edit the Settings.ini and enter your data
* Start the QuickSFTP.exe (not the WinSCP.exe)

```
[ServerSettings]
Server=your-sftp-server.com
Port=22
SSHFingerPrint=ssh-rsa 2048 af:cd:99:b5:a8:a8:a8:95:77:98:ed:90:bd:ed:e8:81

[UserSettings]
DefaultUser=username
RemotUploadPath=/
```

### WinSCP.exe

QuickSFTP use the WinSCPnet.dll, a NET wrapper around WinSCP’s scripting interface: (https://winscp.net/eng/docs/library). Therefore, WinSCP.exe need to be delivered with every release of QuickSFTP.

## Developers
* When building from source you need to copy the Settings.ini.example to Settings.ini
* When restoring NuGet packages, WinSCP.exe is not copied to src directory
  * You need to copy the WinSCP.exe from packages directory into src directory manually
  * ```copy packages\WinSCP.5.9.5\content\WinSCP.exe WinSCP.exe ```
  * Version of package may diverge when updating NugGet packages
  * For further information on this have a look at the [discussion on stackoverflow](http://stackoverflow.com/questions/33264025/using-the-winscp-nuget-package-and-git-can-i-add-winscp-exe-to-my-git-ignore) 

_Build with Visual Studio 2017 and tested on Windows 10 (1607)_



