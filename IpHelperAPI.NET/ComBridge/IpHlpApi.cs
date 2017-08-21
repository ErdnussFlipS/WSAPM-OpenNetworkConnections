using de.efsdev.DotNetExtensionLibrary.Extensions;
using IpHelperAPI.ComBridge.Enums;
using IpHelperAPI.ComBridge.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace IpHelperAPI.ComBridge
{
    static class IpHlpApi
    {
        public static string GetAPIErrorMessageDescription(int ApiErrNumber)
        {
            StringBuilder sError = new StringBuilder(512);
            int lErrorMessageLength;
            lErrorMessageLength = Methods.FormatMessage(Constants.FORMAT_MESSAGE_FROM_SYSTEM, IntPtr.Zero, ApiErrNumber, 0, sError, sError.Capacity, IntPtr.Zero);

            if (lErrorMessageLength > 0)
            {
                string strgError = sError.ToString();
                strgError = strgError.Substring(0, strgError.Length - 2);
                return strgError + " (" + ApiErrNumber.ToString() + ")";
            }
            return "none";
        }

        public static MIB_TCPTABLE GetTcpTable()
        {
            ulong SizePointer = 0;
            IntPtr pTcpTable = IntPtr.Zero;
            var errorCode = (WINERROR)Methods.GetTcpTable(pTcpTable, ref SizePointer, true);

            if (errorCode == WINERROR.ERROR_INSUFFICIENT_BUFFER)
            {
                pTcpTable = Marshal.AllocHGlobal((int)SizePointer);
                errorCode = (WINERROR)Methods.GetTcpTable(pTcpTable, ref SizePointer, true);
            }

            if (errorCode != WINERROR.NO_ERROR)
            {
                throw new InvalidOperationException("Something went wrong, while getting tcp table");
            }

            var tcpTable = MarshalExtension.PtrToStructure<MIB_TCPTABLE>(pTcpTable);
            Marshal.FreeHGlobal(pTcpTable);

            return tcpTable;
        }

        public static object GetExtendedTcpTable(Methods.AF ulAf, TCP_TABLE_CLASS TableClass)
        {
            ulong pwdSize = 0;
            IntPtr pTcpTable = IntPtr.Zero;
            var errorCode = (WINERROR)Methods.GetExtendedTcpTable(pTcpTable, ref pwdSize, true, ulAf, TableClass, 0);

            if (errorCode == WINERROR.ERROR_INSUFFICIENT_BUFFER)
            {
                pTcpTable = Marshal.AllocHGlobal((int)pwdSize);
                errorCode = (WINERROR)Methods.GetExtendedTcpTable(pTcpTable, ref pwdSize, true, ulAf, TableClass, 0);
            }

            if (errorCode != WINERROR.NO_ERROR)
            {
                throw new InvalidOperationException("Something went wrong, while getting tcp table");
            }

            object value = null;

            if (ulAf == Methods.AF.INET)
            {
                value = MarshalExtension.PtrToStructure<MIB_TCPTABLE>(pTcpTable);
            }
            else if ((new List<TCP_TABLE_CLASS>() { TCP_TABLE_CLASS.OWNER_PID_ALL, TCP_TABLE_CLASS.OWNER_PID_CONNECTIONS, TCP_TABLE_CLASS.OWNER_PID_LISTENER }).Contains(TableClass))
            {
                value = MarshalExtension.PtrToStructure<MIB_TCP6TABLE_OWNER_PID>(pTcpTable);
            }
            else if ((new List<TCP_TABLE_CLASS>() { TCP_TABLE_CLASS.OWNER_MODULE_ALL, TCP_TABLE_CLASS.OWNER_MODULE_CONNECTIONS, TCP_TABLE_CLASS.OWNER_MODULE_LISTENER }).Contains(TableClass))
            {
                value = MarshalExtension.PtrToStructure<MIB_TCP6TABLE_OWNER_MODULE>(pTcpTable);
            }

            Marshal.FreeHGlobal(pTcpTable);

            return value;
        }
    }
}
