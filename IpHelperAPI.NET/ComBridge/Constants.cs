using System;

namespace IpHelperAPI.ComBridge
{
    static class Constants
    {
        public const int ANY_SIZE = 1;

        public const int MAXLEN_PHYSADDR = 8;
        public const int MAXLEN_IFDESCR = 256;
        public const int MAX_INTERFACE_NAME_LEN = 256;

        public const int TCPIP_OWNING_MODULE_SIZE = 16;

        public const int FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100;
        public const int FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;
        public const int FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;
    }
}
