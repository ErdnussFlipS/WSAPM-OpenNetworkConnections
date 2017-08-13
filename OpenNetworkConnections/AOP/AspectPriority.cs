using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.efsdev.wsapm.OpenNetworkConnections.AOP
{
    public class AspectPriority
    {
        public const int LastInvoke = 0;
        public const int FirstInvoke = int.MaxValue;

        public const int ViewModelProxy = FirstInvoke;
        public const int TrimWhitespace = ObservableType - 1;
        public const int ObservableType = LastInvoke;
    }
}
