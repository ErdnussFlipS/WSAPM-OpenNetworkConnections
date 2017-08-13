using de.efsdev.wsapm.OpenNetworkConnections.Library;
using de.efsdev.wsapm.OpenNetworkConnections.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wsapm.Extensions;

namespace de.efsdev.wsapm.OpenNetworkConnections.View
{
    // This is the UI class of your plugin (in this case, it is a WPF UserControl).
    // It only has to implement the interface IWsapmPluginSettingsControl.

    /// <summary>
    /// Interaktionslogik für PluginView.xaml
    /// </summary>
    public partial class PluginView : UserControl, IWsapmPluginSettingsControl
    {
        private PluginViewModel ViewModel;

        public PluginView()
        {
            InitializeComponent();

            ViewModel = ViewModelLocator.PluginViewModel;
            ViewModel.OnActiveConnectionsRefreshed += ViewModel_OnActiveConnectionsRefreshed;
            ViewModel.OnAddNewRuleAction += ViewModel_OnAddNewRuleAction;
            this.UpdateDataContext();
        }

        private void ViewModel_OnActiveConnectionsRefreshed(object sender, EventArgs e)
        {
            this.UpdateDataContext();
        }

        private void ViewModel_OnAddNewRuleAction(object sender, GenericEventArgs<NetworkConnectionRuleViewModel> e)
        {
            this.dataGridRules.SelectedItem = e.EventData;
        }

        private void UpdateDataContext()
        {
            this.DataContext = null;
            this.DataContext = ViewModel;
        }

        public object GetSettingsBeforeSave()
        {
            // Build up a new instance of your settings class here 
            // and fill it with the elements from your UI.
            return ViewModel.Settings;
        }

        public void SetSettings(object settings)
        {
            // In this method, the current settings of your plugin gets injected.
            // Use this method to initialize the UI, i.e. filling the UI elements from the current settings.
            ViewModel.SetSettingsFromObject(settings);
        }
    }
}
