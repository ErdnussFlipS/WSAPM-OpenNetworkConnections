using de.efsdev.wsapm.OpenNetworkConnections.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using de.efsdev.wsapm.OpenNetworkConnections.AOP.ViewModelProxy;
using de.efsdev.wsapm.OpenNetworkConnections.AOP;
using de.efsdev.wsapm.OpenNetworkConnections.Library;
using System.Windows.Controls;
using System.Globalization;
using System.Windows.Data;

namespace de.efsdev.wsapm.OpenNetworkConnections.ViewModel
{
    public class NetworkConnectionRuleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var bindingGroup = value as BindingGroup;

            if (bindingGroup.Items.Count == 0 || !(bindingGroup.Items[0] is INetworkConnectionRule rule))
            {
                throw new InvalidProgramException($"Can not validate. Value type is {value?.GetType()} but doesn't implements {typeof(INetworkConnectionRule)}");
            }

            return new ValidationResult(!rule.IsEmpty(), null);
        }
    }

    [ObservableObject]
    public class NetworkConnectionRuleViewModel : ObservableObject, INetworkConnectionRule, IViewModelProxy<NetworkConnectionRule>
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

        public bool IsEmpty() => ProxyModel.IsEmpty();

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
