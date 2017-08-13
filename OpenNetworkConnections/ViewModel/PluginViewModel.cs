using de.efsdev.wsapm.OpenNetworkConnections.AOP;
using de.efsdev.wsapm.OpenNetworkConnections.Library;
using de.efsdev.wsapm.OpenNetworkConnections.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Input;

namespace de.efsdev.wsapm.OpenNetworkConnections.ViewModel
{
    public class PluginViewModel : ObservableObject
    {
        public PluginSettings Settings { get; set; }

        [ObservableProperty]
        public ObservableCollection<NetworkConnectionRuleViewModel> Rules { get; set; }

        public string PluginVersion => PluginHelper.GetPluginAssemblyVersion().ToString();

        public IList<ActiveNetworkConnection> ActiveConnections => PluginHelper.GetActiveTCPConnections();

        public ICommand ResetToDefaults => new RelayCommand<object>((object data) =>
        {
            SetSettingsFromObject(PluginSettings.DefaultSettingsWebserver());
        });

        public ICommand AddNewRuleCommand => new RelayCommand<object>(new Action<object>((object data) =>
        {
            var ruleViewModel = new NetworkConnectionRuleViewModel();
            Rules.Add(ruleViewModel);
            OnAddNewRuleAction.Invoke(this, new GenericEventArgs<NetworkConnectionRuleViewModel>(ruleViewModel));
        }));

        public ICommand DeleteAllRulesCommand => new RelayCommand<object>(new Action<object>((object data) =>
        {
            Rules.Clear();
        }));

        public ICommand DeleteRuleCommand => new RelayCommand<NetworkConnectionRuleViewModel>(new Action<NetworkConnectionRuleViewModel>((NetworkConnectionRuleViewModel ruleViewModel) =>
        {
            Rules.Remove(ruleViewModel);
        }));

        public ICommand AddActiveRuleCommand { get; set; }

        public ICommand RefreshCommand => new RelayCommand<object>(new Action<object>((object data) =>
        {
            this.OnDataRefresh(this, null);
        }));

        public event EventHandler OnDataRefresh;
        public event EventHandler<GenericEventArgs<NetworkConnectionRuleViewModel>> OnAddNewRuleAction;

        public void SetSettingsFromObject(object settings)
        {
            Settings = (PluginSettings)settings;

            var rules = new ObservableCollection<NetworkConnectionRuleViewModel>();
            foreach (var rule in Settings.NetworkConnectionRules)
            {
                rules.Add(new NetworkConnectionRuleViewModel(rule));
            }

            Rules = rules;
            Rules.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (var item in e.NewItems) AddRule((item as NetworkConnectionRuleViewModel).ProxyModel);
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (var item in e.OldItems) RemoveRule((item as NetworkConnectionRuleViewModel).ProxyModel);
                }
            };
        }

        private void AddRule(NetworkConnectionRule connection)
        {
            Settings.NetworkConnectionRules.Add(connection);
        }

        private void RemoveRule(NetworkConnectionRule connection)
        {
            Settings.NetworkConnectionRules.Remove(connection);
        }
    }
}
