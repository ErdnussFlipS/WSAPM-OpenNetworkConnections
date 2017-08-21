using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.efsdev.MrAdviceExtensionLibrary
{
    public static class Priority
    {
        public const int LastInvoke = 0;
        public const int NeutralInvoke = int.MaxValue / 2;
        public const int FirstInvoke = int.MaxValue;
    }
}
