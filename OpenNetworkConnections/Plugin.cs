using de.efsdev.wsapm.OpenNetworkConnections.Model;
using de.efsdev.wsapm.OpenNetworkConnections.View;
using de.efsdev.wsapm.OpenNetworkConnections.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Wsapm.Extensions;

namespace de.efsdev.wsapm.OpenNetworkConnections
{
    [Export(typeof(WsapmPluginBase))]
    [WsapmPlugin("Open network connections", "v1.0.3", "6f7db30d-eb20-46fa-97c1-4bcfabfe8c99")]
    public class Plugin : WsapmPluginAdvancedBase
    {
        private PluginView _settingsControl;
        public override object SettingsControl
        {
            // Method to obtain the settings control for the plugin.
            //
            // Make sure that there will always be only one instance of your settings control,
            // i.e. create a new instance if it does not exist already, and return that instance on all following situations.
            //
            // IMPORTANT: This is the only place where you should do any UI related stuff, e.g. you must not create an instance of your UI class anywhere else!

            get
            {
                if (_settingsControl == null)
                {
                    _settingsControl = new PluginView();
                }
                return _settingsControl;
            }
        }

        public Plugin() : base(typeof(PluginSettings))
        {
            // This is the constructor of you plugin class.
            // You have to call the base class' constructor with the type of your settings class here.
            // Do NOT create an instance of your UI class here or call any UI related code here, 
            // as this will throw an InvalidOperationException when your plugin is loaded by the WSAPM service!
        }

        protected override PluginCheckSuspendResult CheckPluginPolicy()
        {
            // Method which is called to check the plugin's policy.
            //
            // Check you policy and create a PluginCheckSuspendResult:
            //      The fist parameter of the constructor indicates if standby should be suppressed.
            //      The second one gives the reason for suppression of standby - should be String.Empty if the first argument is 'false'.
            //
            // You can access your plugin's settings by using property 'CurrentSettings' from the base class (you will need a cast).

            var rulesApplied = PluginHelper.AreRulesApplicable(((PluginSettings)CurrentSettings).NetworkConnectionRules);

            if (rulesApplied.Item1)
            {
                return new PluginCheckSuspendResult(true, $"Active network connections. First match on rule: {rulesApplied.Item2.ID} ({rulesApplied.Item2.Description})");
            }

            return new PluginCheckSuspendResult(false, "No active network connections.");
        }

        protected override bool Initialize()
        {
            // Method which is called at least once after the plugin was loaded.
            //
            // Use this method to execute any one-time initialization code.
            // The return code indicates if initialization was successful.
            //
            // When your plugin does not need specific initialization, just return true.
            return true;
        }

        protected override object LoadDefaultSettings()
        {
            // Method which get the default settings for the plugin.
            //
            // Use this method to provide the default settings for your plugin.
            // These default settings are loaded when there are no settings available, e.g. the plugin is started for the first time.

            return PluginSettings.DefaultSettingsWebserver();
        }

        protected override bool Prepare()
        {
            // Method which is always called just before the plugin policy is checked.
            //
            // Use this method to prepare your plugin for the subsequent check of the plugin policy.
            // The return code indicates if preparation was successful.
            //
            // When your plugin does not need specific preparation, just return true:
            return true;
        }

        protected override bool TearDown()
        {
            // Method which is called after the plugin policy was checked.
            //
            // Use this method to dispose all resources which were created during the preparation or check of the plugin policy.
            // The return code indicates if tearing down was successful.
            //
            // When your plugin does not need specific tearing down, just return true:
            return true;
        }
    }
}
