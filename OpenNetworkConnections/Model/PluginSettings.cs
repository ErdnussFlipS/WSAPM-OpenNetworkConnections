using de.efsdev.wsapm.OpenNetworkConnections.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.efsdev.wsapm.OpenNetworkConnections.Model
{
    [Serializable]
    public class PluginSettings : ObservableObject
    {
        public List<NetworkConnectionRule> NetworkConnectionRules { get; set; } = new List<NetworkConnectionRule>();

        public static PluginSettings DefaultSettingsWebserver()
        {
            var settings = new PluginSettings()
            {
                NetworkConnectionRules = new List<NetworkConnectionRule>() {
                    new NetworkConnectionRule() { LocalPort = "80", Description = "HTTP (incoming)" },
                    new NetworkConnectionRule() { LocalPort = "443", Description = "HTTPS (incoming)" }
                }
            };
            return settings;
        }
    }
}
