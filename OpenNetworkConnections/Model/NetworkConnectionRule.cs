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
    public interface INetworkConnectionRule : INetworkConnection
    {
        Guid ID { get; }
        bool Enabled { get; }
        string Description { get; }
    }

    [Serializable]
    [ObservableObject]
    public class NetworkConnectionRule : ObservableObject, INetworkConnectionRule
    {
        #region INetworkConnectionRule
        public Guid ID { get; set; } = Guid.NewGuid();

        public bool Enabled { get; set; }

        public string Description { get; set; }

        public string LocalAddress { get; set; }

        public string LocalPort { get; set; }

        public string RemoteAddress { get; set; }

        public string RemotePort { get; set; }

        public TcpState? State { get; set; }
        #endregion

        public bool Matches(INetworkConnection obj)
        {
            if (obj == null)
            {
                return false;
            }

            var matches = new List<bool>();

            if (!string.IsNullOrEmpty(this.LocalAddress))
            {
                matches.Add(obj.LocalAddress?.Matches(this.LocalAddress) ?? false);
            }

            if (!string.IsNullOrEmpty(this.LocalPort))
            {
                matches.Add(obj.LocalPort?.Matches(this.LocalPort) ?? false);
            }

            if (!string.IsNullOrEmpty(this.RemoteAddress))
            {
                matches.Add(obj.RemoteAddress?.Matches(this.RemoteAddress) ?? false);
            }

            if (!string.IsNullOrEmpty(this.RemotePort))
            {
                matches.Add(obj.RemotePort?.Matches(this.RemotePort) ?? false);
            }

            if (this.State != null)
            {
                matches.Add(obj.State?.Equals(this.State) ?? false);
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
    }
}
