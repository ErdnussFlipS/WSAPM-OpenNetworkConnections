using de.efsdev.DotNetExtensionLibrary.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;

namespace IpHelperAPI.Deprecated
{
    static class IpHlpApiUtils
    {
        public const int NO_ERROR = 0;
        public const int MIB_TCP_STATE_CLOSED = 1;
        public const int MIB_TCP_STATE_LISTEN = 2;
        public const int MIB_TCP_STATE_SYN_SENT = 3;
        public const int MIB_TCP_STATE_SYN_RCVD = 4;
        public const int MIB_TCP_STATE_ESTAB = 5;
        public const int MIB_TCP_STATE_FIN_WAIT1 = 6;
        public const int MIB_TCP_STATE_FIN_WAIT2 = 7;
        public const int MIB_TCP_STATE_CLOSE_WAIT = 8;
        public const int MIB_TCP_STATE_CLOSING = 9;
        public const int MIB_TCP_STATE_LAST_ACK = 10;
        public const int MIB_TCP_STATE_TIME_WAIT = 11;
        public const int MIB_TCP_STATE_DELETE_TCB = 12;

        #region helper function

        public static UInt16 ConvertPort(UInt32 dwPort)
        {
            byte[] b = new Byte[2];
            // high weight byte
            b[0] = byte.Parse((dwPort >> 8).ToString());
            // low weight byte
            b[1] = byte.Parse((dwPort & 0xFF).ToString());
            return BitConverter.ToUInt16(b, 0);
        }

        public static int BufferToInt(byte[] buffer, ref int nOffset)
        {
            int res = (((int)buffer[nOffset])) + (((int)buffer[nOffset + 1]) << 8) +
                (((int)buffer[nOffset + 2]) << 16) + (((int)buffer[nOffset + 3]) << 24);
            nOffset += 4;
            return res;
        }

        public static string StateToStr(int state)
        {
            switch (state)
            {
                case MIB_TCP_STATE_CLOSED: return "CLOSED";
                case MIB_TCP_STATE_LISTEN: return "LISTEN";
                case MIB_TCP_STATE_SYN_SENT: return "SYN_SENT";
                case MIB_TCP_STATE_SYN_RCVD: return "SYN_RCVD";
                case MIB_TCP_STATE_ESTAB: return "ESTAB";
                case MIB_TCP_STATE_FIN_WAIT1: return "FIN_WAIT1";
                case MIB_TCP_STATE_FIN_WAIT2: return "FIN_WAIT2";
                case MIB_TCP_STATE_CLOSE_WAIT: return "CLOSE_WAIT";
                case MIB_TCP_STATE_CLOSING: return "CLOSING";
                case MIB_TCP_STATE_LAST_ACK: return "LAST_ACK";
                case MIB_TCP_STATE_TIME_WAIT: return "TIME_WAIT";
                case MIB_TCP_STATE_DELETE_TCB: return "DELETE_TCB";
            }

            return string.Empty;
        }

        public static State StateValueToState(int stateValue)
        {
            var enumValues = Enum.GetValues(typeof(State));
            foreach (State enumValue in enumValues)
            {
                var attribute = enumValue.GetAttribute<MIB_TCP_STATEAttribute>();
                var underlyingValue = attribute.GetUnderlyingValue<int>();

                if (stateValue.Equals(underlyingValue))
                {
                    return enumValue;
                }
            }

            return State.UNKNOWN;
        }

        public static IPEndPoint BufferToIPEndPoint(byte[] buffer, ref int nOffset, bool IsRemote)
        {
            //address
            Int64 m_Address = ((((buffer[nOffset + 3] << 0x18) | (buffer[nOffset + 2] << 0x10)) | (buffer[nOffset + 1] << 8)) | buffer[nOffset]) & ((long)0xffffffff);
            nOffset += 4;
            int m_Port = 0;
            m_Port = (IsRemote && (m_Address == 0)) ? 0 :
                        (((int)buffer[nOffset]) << 8) + (((int)buffer[nOffset + 1])) + (((int)buffer[nOffset + 2]) << 24) + (((int)buffer[nOffset + 3]) << 16);
            nOffset += 4;

            // store the remote endpoint
            IPEndPoint temp = new IPEndPoint(m_Address, m_Port);
            if (temp == null)
            {
                Debug.WriteLine("Parsed address is null. Addr=" + m_Address.ToString() + " Port=" + m_Port + " IsRemote=" + IsRemote.ToString());
            }

            return temp;
        }

        public static string GetHostName(IPEndPoint HostAddress, string LocalHostName)
        {
            try
            {
                if (HostAddress.Address.Equals(0))
                {
                    if (HostAddress.Port > 0)
                        return LocalHostName + ":" + HostAddress.Port.ToString();
                    else
                        return "Anyone";
                }
                return Dns.GetHostEntry(HostAddress.Address).HostName + ":" + HostAddress.Port.ToString();
            }
            catch
            {
                return HostAddress.ToString();
            }
        }

        public static string GetLocalHostName()
        {
            //IPGlobalProperties.GetIPGlobalProperties().DomainName +"." + IPGlobalProperties.GetIPGlobalProperties().HostName
            return Dns.GetHostEntry("localhost").HostName;
        }

        public static int CompareIPEndPoints(IPEndPoint first, IPEndPoint second)
        {
            int i;
            byte[] _first = first.Address.GetAddressBytes();
            byte[] _second = second.Address.GetAddressBytes();
            for (int j = 0; j < _first.Length; j++)
            {
                i = _first[j] - _second[j];
                if (i != 0)
                    return i;
            }
            i = first.Port - second.Port;
            if (i != 0)
                return i;
            return 0;
        }

        public static string GetProcessNameByPID(int processID)
        {
            //could be an error here if the process die before we can get his name
            try
            {
                Process p = Process.GetProcessById((int)processID);
                return p.ProcessName;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return "Unknown";
            }
        }
        #endregion
    }
}
