using de.efsdev.DotNetExtensionLibrary.Extensions;
using IpHelperAPI.ComBridge;
using IpHelperAPI.ComBridge.Enums;
using IpHelperAPI.ComBridge.Structs;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace IpHelperAPI
{
    public static class IPHelperAPI
    {
        public static void TestAPI()
        {
            var tableInt4 = IpHlpApi.GetExtendedTcpTable(Methods.AF.INET, TCP_TABLE_CLASS.OWNER_PID_ALL);
            var tableInt6 = IpHlpApi.GetExtendedTcpTable(Methods.AF.INET6, TCP_TABLE_CLASS.OWNER_PID_ALL);
            Debugger.Break();
        }


        //private enum AF
        //{
        //    INET = 2,
        //    INET6 = 10
        //}

        //private static IList<INetworkTransmission> GetTcpConnections(AF ipVersion)
        //{
        //    int AF_INET = (int)ipVersion;
        //    int buffSize = 20000;
        //    byte[] buffer = new byte[buffSize];
        //    int res = IpHlpApiComBridge.GetExtendedTcpTable(buffer, out buffSize, true, AF_INET, IpHlpApiComBridge.TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL, 0);
        //    if (res != IpHlpApiUtils.NO_ERROR) //If there is no enough memory to execute function
        //    {
        //        throw new InsufficientMemoryException("Not enough memory to get tcp table from COM interface.");
        //    }

        //    IList<INetworkTransmission> transmissions = new List<INetworkTransmission>();

        //    int nOffset = 0;
        //    // number of entry in the table
        //    int NumEntries = Convert.ToInt32(buffer[nOffset]);
        //    nOffset += 4;
        //    for (int i = 0; i < NumEntries; i++)
        //    {
        //        int stateValue = Convert.ToInt32(buffer[nOffset]);
        //        State state = IpHlpApiUtils.StateValueToState(stateValue);

        //        nOffset += 4;
        //        IPEndPoint localEndpoint = IpHlpApiUtils.BufferToIPEndPoint(buffer, ref nOffset, false);
        //        IPEndPoint remoteEndpoint = IpHlpApiUtils.BufferToIPEndPoint(buffer, ref nOffset, true);
        //        int processId = IpHlpApiUtils.BufferToInt(buffer, ref nOffset);

        //        var tcpConnection = new NetworkTransmission
        //        {
        //            Protocol = Protocol.TCP,
        //            State = state,
        //            LocalEndpoint = localEndpoint,
        //            RemoteEndpoint = remoteEndpoint,
        //            ProcessId = processId
        //        };
        //        transmissions.Add(tcpConnection);
        //    }

        //    return transmissions;
        //}

        //public static IList<INetworkTransmission> GetTcpConnections()
        //{
        //    IList<INetworkTransmission> tcpConnections_ipv4 = GetTcpConnections(AF.INET);
        //    //IList<INetworkTransmission> tcpConnections_ipv6 = GetTcpConnections(AF.INET6);

        //    return tcpConnections_ipv4; //.Union(tcpConnections_ipv6) as IList<INetworkTransmission>;
        //}

        //public static IList<INetworkTransmission> GetUdpTransmissions()
        //{
        //    int AF_INET = 2; // IP_v4
        //    int buffSize = 20000;
        //    byte[] buffer = new byte[buffSize];
        //    int res = IpHlpApiComBridge.GetExtendedUdpTable(buffer, out buffSize, true, AF_INET, IpHlpApiComBridge.UDP_TABLE_CLASS.UDP_TABLE_OWNER_PID, 0);
        //    if (res != IpHlpApiUtils.NO_ERROR)
        //    {
        //        buffer = new byte;
        //        res = IpHlpApiComBridge.GetExtendedUdpTable(buffer, out buffSize, true, AF_INET, IpHlpApiComBridge.UDP_TABLE_CLASS.UDP_TABLE_OWNER_PID, 0);
        //        if (res != IpHlpApiUtils.NO_ERROR)
        //        {
        //            return;
        //        }
        //    }

        //    int nOffset = 0;
        //    int NumEntries = Convert.ToInt32(buffer[nOffset]);
        //    nOffset += 4;
        //    for (int i = 0; i < NumEntries; i++)
        //    {
        //        TCPUDPConnection row = new TCPUDPConnection();
        //        row.Protocol = Protocol.UDP;
        //        row.Local = Utils.BufferToIPEndPoint(buffer, ref nOffset, false);
        //        row.PID = Utils.BufferToInt(buffer, ref nOffset);
        //        this.Add(row);
        //    }




        //    IList<INetworkTransmission> transmissions = new List<INetworkTransmission>();

        //    int nOffset = 0;
        //    // number of entry in the table
        //    int NumEntries = Convert.ToInt32(buffer[nOffset]);
        //    nOffset += 4;
        //    for (int i = 0; i < NumEntries; i++)
        //    {
        //        int stateValue = Convert.ToInt32(buffer[nOffset]);
        //        State state = IpHlpApiUtils.StateValueToState(stateValue);

        //        nOffset += 4;
        //        IPEndPoint localEndpoint = IpHlpApiUtils.BufferToIPEndPoint(buffer, ref nOffset, false);
        //        IPEndPoint remoteEndpoint = IpHlpApiUtils.BufferToIPEndPoint(buffer, ref nOffset, true);
        //        int processId = IpHlpApiUtils.BufferToInt(buffer, ref nOffset);

        //        var tcpConnection = new NetworkTransmission
        //        {
        //            Protocol = Protocol.UDP,
        //            State = state,
        //            LocalEndpoint = localEndpoint,
        //            RemoteEndpoint = remoteEndpoint,
        //            ProcessId = processId
        //        };
        //        transmissions.Add(tcpConnection);
        //    }

        //    return transmissions;
        //}
    }
}
