using de.efsdev.DotNetExtensionLibrary.Attributes;
using System;
using System.ComponentModel;
using System.Net;

namespace IpHelperAPI
{
    class MIB_TCP_STATEAttribute : UnderlyingValueAttribute
    {
        public MIB_TCP_STATEAttribute(object underlyingValue) : base(underlyingValue) { }
    }

    public enum State
    {
        [MIB_TCP_STATE(int.MinValue)]
        UNKNOWN,
        [MIB_TCP_STATE(IpHlpApiUtils.MIB_TCP_STATE_CLOSED)]
        CLOSED,
        [MIB_TCP_STATE(IpHlpApiUtils.MIB_TCP_STATE_LISTEN)]
        LISTEN,
        [MIB_TCP_STATE(IpHlpApiUtils.MIB_TCP_STATE_SYN_SENT)]
        SYN_SENT,
        [MIB_TCP_STATE(IpHlpApiUtils.MIB_TCP_STATE_SYN_RCVD)]
        SYN_RCVD,
        [MIB_TCP_STATE(IpHlpApiUtils.MIB_TCP_STATE_ESTAB)]
        ESTAB,
        [MIB_TCP_STATE(IpHlpApiUtils.MIB_TCP_STATE_FIN_WAIT1)]
        FIN_WAIT1,
        [MIB_TCP_STATE(IpHlpApiUtils.MIB_TCP_STATE_FIN_WAIT2)]
        FIN_WAIT2,
        [MIB_TCP_STATE(IpHlpApiUtils.MIB_TCP_STATE_CLOSE_WAIT)]
        CLOSE_WAIT,
        [MIB_TCP_STATE(IpHlpApiUtils.MIB_TCP_STATE_CLOSING)]
        CLOSING,
        [MIB_TCP_STATE(IpHlpApiUtils.MIB_TCP_STATE_LAST_ACK)]
        LAST_ACK,
        [MIB_TCP_STATE(IpHlpApiUtils.MIB_TCP_STATE_TIME_WAIT)]
        TIME_WAIT,
        [MIB_TCP_STATE(IpHlpApiUtils.MIB_TCP_STATE_DELETE_TCB)]
        DELETE_TCB
    }

    public enum Protocol
    {
        TCP,
        UDP,
        None
    };

    public interface INetworkTransmission
    {
        State State { get; }
        Protocol Protocol { get; }
        bool IsResolveIP { get; }
        IPEndPoint LocalEndpoint { get; }
        IPEndPoint RemoteEndpoint { get; }
        int ProcessId { get; }
        string ProcessName { get; }
    }

    class NetworkTransmission : INetworkTransmission
    {
        public State State { get; internal set; }

        public Protocol Protocol { get; internal set; }

        public bool IsResolveIP { get; internal set; }

        public IPEndPoint LocalEndpoint { get; internal set; }

        public IPEndPoint RemoteEndpoint { get; internal set; }

        public int ProcessId { get; internal set; }

        public string ProcessName { get; internal set; }
    }
}
