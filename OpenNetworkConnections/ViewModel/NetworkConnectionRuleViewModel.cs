using de.efsdev.wsapm.OpenNetworkConnections.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using de.efsdev.wsapm.OpenNetworkConnections.AOP.ViewModelProxy;

namespace de.efsdev.wsapm.OpenNetworkConnections.ViewModel
{
    public class NetworkConnectionRuleViewModel : INetworkConnectionRule, IViewModelProxy<NetworkConnectionRule>
    {
        public NetworkConnectionRule ProxyModel { get; private set; }

        [ViewModelProxyProperty(PropertyName = nameof(ProxyModel))]
        public Guid ID { get; set; }

        [ViewModelProxyProperty(PropertyName = nameof(ProxyModel))]
        public bool Enabled { get; set; }

        [ViewModelProxyProperty(PropertyName = nameof(ProxyModel))]
        public string Description { get; set; }

        [ViewModelProxyProperty(PropertyName = nameof(ProxyModel))]
        public RuleInterpretationMode InterpretationMode { get; set; }

        [ViewModelProxyProperty(PropertyName = nameof(ProxyModel))]
        public string LocalAddress { get; set; }

        [ViewModelProxyProperty(PropertyName = nameof(ProxyModel))]
        public string LocalPort { get; set; }

        [ViewModelProxyProperty(PropertyName = nameof(ProxyModel))]
        public string RemoteAddress { get; set; }

        [ViewModelProxyProperty(PropertyName = nameof(ProxyModel))]
        public string RemotePort { get; set; }

        [ViewModelProxyProperty(PropertyName = nameof(ProxyModel))]
        public TcpState? State { get; set; }

        public IList<INetworkConnection> ApplicableConnections { get; set; }

        public int ApplicableConnectionsCount => CalculateApplicableConnectionsCount();

        public NetworkConnectionRuleViewModel() : this(new NetworkConnectionRule()) { }

        public NetworkConnectionRuleViewModel(NetworkConnectionRule rule)
        {
            ProxyModel = rule;
        }

        private int CalculateApplicableConnectionsCount()
        {
            return PluginHelper.CalculateMatchedConnections(ProxyModel);
        }
    }
}
