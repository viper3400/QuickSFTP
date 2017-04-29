using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;

namespace Jaxx.QuickSFTP
{
    internal class SettingsProvider
    {
        IniData _settings;

        internal SettingsProvider(string SettingsFilePath)
        {
            var parser = new FileIniDataParser();
            _settings = parser.ReadFile(SettingsFilePath);
        }

        internal string Server
        {
            get { return _settings["ServerSettings"]["Server"]; }
        }

        internal int Port
        {
            get
            {
                var port = _settings["ServerSettings"]["Port"];
                return Int32.Parse(port);
            }
        }

        internal string SSHFingerPrint
        {
            get { return _settings["ServerSettings"]["SSHFingerPrint"]; }
        }

        internal string DefaultUser
        {
            get { return _settings["UserSettings"]["DefaultUser"]; }
        }

        internal string RemotUploadPath
        {
            get { return _settings["UserSettings"]["RemotUploadPath"]; }
        }       
    }
}
