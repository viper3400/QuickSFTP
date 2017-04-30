# QuickSFTP

QuickSFTP is a tool, which allows an unexperienced person to upload files onto a server
using the SFTP protocol just by typing the password and choosing the file(s) from a standard Windows dialog.

Therfore, the tool has to be preconfigured by an experienced person.

## Scenario

I've tinkerd this tool quickly, because a friend of mine wanted to send me uncompressed audio WAV files 
he and his band recorded, recently. I supposed him to upload this to my server but he was
struggeling with FileZilla for reasons ...

With QuickSFTP he was able to upload me his files with just his password und one click.



## Dependencies
* .NET Framework 4.6.1

## Getting Started
* Rename the Settings.ini.example to Settings.ini
* Edit the Settings.ini 

```
[ServerSettings]
Server=your-sftp-server.com
Port=22
SSHFingerPrint=ssh-rsa 2048 af:cd:99:b5:a8:a8:a8:95:77:98:ed:90:bd:ed:e8:81

[UserSettings]
DefaultUser=username
RemotUploadPath=/
```

_Build with Visual Studio 2017 and tested on Windows 10 (1607)_



