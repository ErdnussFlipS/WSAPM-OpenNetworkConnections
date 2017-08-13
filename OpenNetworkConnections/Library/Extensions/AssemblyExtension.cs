using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace de.efsdev.wsapm.OpenNetworkConnections.Library.Extensions
{
    public static class AssemblyExtension
    {
        public static Version GetVersion(this Assembly assembly)
        {
            return assembly.GetName().Version;
        }

        public static Version GetFileVersion(this Assembly assembly)
        {
            return new Version(FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion);
        }

        public static Version GetProductVersion(this Assembly assembly)
        {
            return new Version(FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion);
        }
    }
}
