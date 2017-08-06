using de.efsdev.wsapm.OpenNetworkConnections.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;

namespace de.efsdev.wsapm.OpenNetworkConnections
{
    public static class PluginHelper
    {
        public static IList<ActiveNetworkConnection> GetActiveTCPConnections()
        {
            var properties = IPGlobalProperties.GetIPGlobalProperties();
            var connections = properties.GetActiveTcpConnections();
            var wrappedActiveConnections = new List<ActiveNetworkConnection>();

            foreach (var connection in connections)
            {
                wrappedActiveConnections.Add(new ActiveNetworkConnection(connection));
            }

            return wrappedActiveConnections;
        }

        public static Tuple<bool, NetworkConnectionRule> AreRulesApplicable(IList<NetworkConnectionRule> rules)
        {
            var activeNetworkConnections = GetActiveTCPConnections();

            foreach (var activeConnection in activeNetworkConnections)
            {
                foreach (var rule in rules)
                {
                    if (rule.Matches(activeConnection))
                    {
                        return new Tuple<bool, NetworkConnectionRule>(true, rule);
                    }
                }
            }

            return new Tuple<bool, NetworkConnectionRule>(false, null);
        }

        public static IList<INetworkConnection> ApplicableOnConnections(NetworkConnectionRule rule)
        {
            var activeNetworkConnections = GetActiveTCPConnections();
            var matchedConnections = new List<INetworkConnection>();

            foreach (var activeConnection in activeNetworkConnections)
            {
                if (rule.Matches(activeConnection))
                {
                    matchedConnections.Add(activeConnection);
                }
            }

            return matchedConnections;
        }

        public static int CalculateMatchedConnections(NetworkConnectionRule rule)
        {
            return ApplicableOnConnections(rule)?.Count ?? 0;
        }
    }
}
