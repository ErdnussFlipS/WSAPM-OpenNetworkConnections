using IpHelperAPI.ComBridge.Enums;
using IpHelperAPI.ComBridge.Structs;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace IpHelperAPI.ComBridge
{
    /// <summary>
    /// The GetXXXTable APIs take a buffer and a size of buffer.  If the buffer  
    /// is not large enough, the APIs return ERROR_INSUFFICIENT_BUFFER  and      
    /// *pdwSize is the required buffer size                                     
    /// The bOrder is a BOOLEAN, which if TRUE sorts the table according to      
    /// MIB-II (RFC XXXX) 
    /// </summary>
    static class Methods
    {
        public enum AF : uint
        {
            INET = (uint)Enums.AF.INET,
            INET6 = (uint)Enums.AF.INET6,
        }

        [DllImport("kernel32", SetLastError = true)]
        internal static extern int FormatMessage(int flags, IntPtr source, int messageId, int languageId, StringBuilder buffer, int size, IntPtr arguments);

        /// <summary>
        /// Retrieves the number of interfaces in the system. These include LAN and
        /// WAN interfaces
        /// </summary>
        /// <param name="pdwNumIf"></param>
        /// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, use FormatMessage to obtain the message string for the returned error.</returns>
        [DllImport("iphlpapi.dll", SetLastError = true)]
        public static extern UInt32 GetNumberOfInterfaces(out UInt32 pdwNumIf);

        /// <summary>
        /// <para>Gets the MIB-II ifEntry</para>
        /// <para>The dwIndex field of the MIB_IFROW should be set to the index of the
        /// interface being queried</para>  
        /// </summary>
        /// <param name="pIfRow"></param>
        /// <returns></returns>
        [DllImport("iphlpapi.dll", SetLastError = true)]
        public static extern UInt32 GetIfEntry(ref MIB_IFROW pIfRow);

        [DllImport("iphlpapi.dll", SetLastError = true)]
        public static extern UInt32 GetTcpTable(IntPtr pTcpTable, ref ulong SizePointer, bool Order);

        [DllImport("iphlpapi.dll", SetLastError = true)]
        public static extern UInt32 GetExtendedTcpTable(IntPtr pTcpTable, ref ulong pdwSize, bool bOrder, AF ulAf, TCP_TABLE_CLASS TableClass, uint Reserved);
    }
}
