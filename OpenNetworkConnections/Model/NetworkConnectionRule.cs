using de.efsdev.wsapm.OpenNetworkConnections.AOP;
using de.efsdev.wsapm.OpenNetworkConnections.Library;
using de.efsdev.wsapm.OpenNetworkConnections.Library.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace de.efsdev.wsapm.OpenNetworkConnections.Model
{
    public enum RuleInterpretationMode
    {
        Normal, RegularExpression
    }

    public interface INetworkConnectionRule : INetworkConnection
    {
        Guid ID { get; }
        bool Enabled { get; }
        string Description { get; }
        RuleInterpretationMode InterpretationMode { get; }

        bool IsEmpty();
    }

    [Serializable]
    public class NetworkConnectionRule : INetworkConnectionRule
    {
        #region INetworkConnectionRule
        public Guid ID { get; set; } = Guid.NewGuid();

        public bool Enabled { get; set; }

        [TrimWhitespace]
        public string Description { get; set; }

        public RuleInterpretationMode InterpretationMode { get; set; } = RuleInterpretationMode.Normal;

        [TrimWhitespace]
        public string LocalAddress { get; set; }

        [TrimWhitespace]
        public string LocalPort { get; set; }

        [TrimWhitespace]
        public string RemoteAddress { get; set; }

        [TrimWhitespace]
        public string RemotePort { get; set; }

        public TcpState? State { get; set; }

        public bool IsEmpty()
        {
            var isEmpty = true;

            isEmpty &= string.IsNullOrEmpty(Description);
            isEmpty &= string.IsNullOrEmpty(LocalAddress);
            isEmpty &= string.IsNullOrEmpty(LocalPort);
            isEmpty &= string.IsNullOrEmpty(RemoteAddress);
            isEmpty &= string.IsNullOrEmpty(RemotePort);
            isEmpty &= State == null;

            return isEmpty;
        }
        #endregion

        public bool Matches(INetworkConnection obj)
        {
            if (obj == null)
            {
                return false;
            }

            var matches = new List<bool>();

            if (!string.IsNullOrEmpty(LocalAddress))
            {
                matches.Add(Match(LocalAddress, obj.LocalAddress, InterpretationMode));
            }

            if (!string.IsNullOrEmpty(LocalPort))
            {
                matches.Add(Match(LocalPort, obj.LocalPort, InterpretationMode));
            }

            if (!string.IsNullOrEmpty(RemoteAddress))
            {
                matches.Add(Match(RemoteAddress, obj.RemoteAddress, InterpretationMode));
            }

            if (!string.IsNullOrEmpty(RemotePort))
            {
                matches.Add(Match(RemotePort, obj.RemotePort, InterpretationMode));
            }

            if (State != null)
            {
                matches.Add(obj.State?.Equals(State) ?? false);
            }

            if (matches.Count == 0)
            {
                return false;
            }

            foreach (var match in matches)
            {
                if (!match)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool Match(string pattern, string value, RuleInterpretationMode mode)
        {
            if (mode == RuleInterpretationMode.Normal)
            {
                return value?.Equals(pattern, StringComparison.OrdinalIgnoreCase) ?? false;
            }

            return value?.Matches(pattern) ?? false;
        }
    }
}
