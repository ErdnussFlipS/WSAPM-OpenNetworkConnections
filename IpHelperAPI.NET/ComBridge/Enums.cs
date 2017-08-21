using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IpHelperAPI.ComBridge.Enums
{
    enum WINERROR : long
    {
        NO_ERROR = 0L,
        ERROR_INVALID_FUNCTION = 1L,
        ERROR_NOT_ENOUGH_MEMORY = 8L,
        ERROR_DEV_NOT_EXIST = 55L,
        ERROR_INVALID_PARAMETER = 87L,
        ERROR_INSUFFICIENT_BUFFER = 122L,
        ERROR_INVALID_NAME = 123L,
        ERROR_BUSY = 170L,
        ERROR_MORE_DATA = 234L,
        WAIT_TIMEOUT = 258L,
        ERROR_IO_PENDING = 997L,
        ERROR_DEVICE_REINITIALIZATION_NEEDED = 1164L,
        ERROR_CONTINUE = 1246L,
        ERROR_NO_MORE_DEVICES = 1248L,
    }

    enum IF_TYPE : int
    {
        OTHER = 1, // None of the below
        REGULAR_1822 = 2,
        HDH_1822 = 3,
        DDN_X25 = 4,
        RFC877_X25 = 5,
        ETHERNET_CSMACD = 6,
        IS088023_CSMACD = 7,
        ISO88024_TOKENBUS = 8,
        ISO88025_TOKENRING = 9,
        ISO88026_MAN = 10,
        STARLAN = 11,
        PROTEON_10MBIT = 12,
        PROTEON_80MBIT = 13,
        HYPERCHANNEL = 14,
        FDDI = 15,
        LAP_B = 16,
        SDLC = 17,
        DS1 = 18, // DS1-MIB
        E1 = 19, // Obsolete; see DS1-MIB
        BASIC_ISDN = 20,
        PRIMARY_ISDN = 21,
        PROP_POINT2POINT_SERIAL = 22, // proprietary serial
        PPP = 23,
        SOFTWARE_LOOPBACK = 24,
        EON = 25, // CLNP over IP
        ETHERNET_3MBIT = 26,
        NSIP = 27, // XNS over IP
        SLIP = 28, // Generic Slip
        ULTRA = 29, // ULTRA Technologies
        DS3 = 30, // DS3-MIB
        SIP = 31, // SMDS, coffee
        FRAMERELAY = 32, // DTE only
        RS232 = 33,
        PARA = 34, // Parallel port
        ARCNET = 35,
        ARCNET_PLUS = 36,
        ATM = 37, // ATM cells
        MIO_X25 = 38,
        SONET = 39, // SONET or SDH
        X25_PLE = 40,
        ISO88022_LLC = 41,
        LOCALTALK = 42,
        SMDS_DXI = 43,
        FRAMERELAY_SERVICE = 44, // FRNETSERV-MIB
        V35 = 45,
        HSSI = 46,
        HIPPI = 47,
        MODEM = 48, // Generic Modem
        AAL5 = 49, // AAL5 over ATM
        SONET_PATH = 50,
        SONET_VT = 51,
        SMDS_ICIP = 52, // SMDS InterCarrier Interface
        PROP_VIRTUAL = 53, // Proprietary virtual/internal
        PROP_MULTIPLEXOR = 54, // Proprietary multiplexing
        IEEE80212 = 55, // 100BaseVG
        FIBRECHANNEL = 56,
        HIPPIINTERFACE = 57,
        FRAMERELAY_INTERCONNECT = 58, // Obsolete, use 32 or 44
        AFLANE_8023 = 59, // ATM Emulated LAN for 802.3
        AFLANE_8025 = 60, // ATM Emulated LAN for 802.5
        CCTEMUL = 61, // ATM Emulated circuit
        FASTETHER = 62, // Fast Ethernet (100BaseT)
        ISDN = 63, // ISDN and X.25
        V11 = 64, // CCITT V.11/X.21
        V36 = 65, // CCITT V.36
        G703_64K = 66, // CCITT G703 at 64Kbps
        G703_2MB = 67, // Obsolete; see DS1-MIB
        QLLC = 68, // SNA QLLC
        FASTETHER_FX = 69, // Fast Ethernet (100BaseFX)
        CHANNEL = 70,
        IEEE80211 = 71, // Radio spread spectrum
        IBM370PARCHAN = 72, // IBM System 360/370 OEMI Channel
        ESCON = 73, // IBM Enterprise Systems Connection
        DLSW = 74, // Data Link Switching
        ISDN_S = 75, // ISDN S/T interface
        ISDN_U = 76, // ISDN U interface
        LAP_D = 77, // Link Access Protocol D
        IPSWITCH = 78, // IP Switching Objects
        RSRB = 79, // Remote Source Route Bridging
        ATM_LOGICAL = 80, // ATM Logical Port
        DS0 = 81, // Digital Signal Level 0
        DS0_BUNDLE = 82, // Group of ds0s on the same ds1
        BSC = 83, // Bisynchronous Protocol
        ASYNC = 84, // Asynchronous Protocol
        CNR = 85, // Combat Net Radio
        ISO88025R_DTR = 86, // ISO 802.5r DTR
        EPLRS = 87, // Ext Pos Loc Report Sys
        ARAP = 88, // Appletalk Remote Access Protocol
        PROP_CNLS = 89, // Proprietary Connectionless Proto
        HOSTPAD = 90, // CCITT-ITU X.29 PAD Protocol
        TERMPAD = 91, // CCITT-ITU X.3 PAD Facility
        FRAMERELAY_MPI = 92, // Multiproto Interconnect over FR
        X213 = 93, // CCITT-ITU X213
        ADSL = 94, // Asymmetric Digital Subscrbr Loop
        RADSL = 95, // Rate-Adapt Digital Subscrbr Loop
        SDSL = 96, // Symmetric Digital Subscriber Loop
        VDSL = 97, // Very H-Speed Digital Subscrb Loop
        ISO88025_CRFPRINT = 98, // ISO 802.5 CRFP
        MYRINET = 99, // Myricom Myrinet
        VOICE_EM = 100, // Voice recEive and transMit
        VOICE_FXO = 101, // Voice Foreign Exchange Office
        VOICE_FXS = 102, // Voice Foreign Exchange Station
        VOICE_ENCAP = 103, // Voice encapsulation
        VOICE_OVERIP = 104, // Voice over IP encapsulation
        ATM_DXI = 105, // ATM DXI
        ATM_FUNI = 106, // ATM FUNI
        ATM_IMA = 107, // ATM IMA
        PPPMULTILINKBUNDLE = 108, // PPP Multilink Bundle
        IPOVER_CDLC = 109, // IBM ipOverCdlc
        IPOVER_CLAW = 110, // IBM Common Link Access to Workstn
        STACKTOSTACK = 111, // IBM stackToStack
        VIRTUALIPADDRESS = 112, // IBM VIPA
        MPC = 113, // IBM multi-proto channel support
        IPOVER_ATM = 114, // IBM ipOverAtm
        ISO88025_FIBER = 115, // ISO 802.5j Fiber Token Ring
        TDLC = 116, // IBM twinaxial data link control
        GIGABITETHERNET = 117,
        HDLC = 118,
        LAP_F = 119,
        V37 = 120,
        X25_MLP = 121, // Multi-Link Protocol
        X25_HUNTGROUP = 122, // X.25 Hunt Group
        TRANSPHDLC = 123,
        INTERLEAVE = 124, // Interleave channel
        FAST = 125, // Fast channel
        IP = 126, // IP (for APPN HPR in IP networks)
        DOCSCABLE_MACLAYER = 127, // CATV Mac Layer
        DOCSCABLE_DOWNSTREAM = 128, // CATV Downstream interface
        DOCSCABLE_UPSTREAM = 129, // CATV Upstream interface
        A12MPPSWITCH = 130, // Avalon Parallel Processor
        TUNNEL = 131, // Encapsulation interface
        COFFEE = 132, // Coffee pot
        CES = 133, // Circuit Emulation Service
        ATM_SUBINTERFACE = 134, // ATM Sub Interface
        L2_VLAN = 135, // Layer 2 Virtual LAN using 802.1Q
        L3_IPVLAN = 136, // Layer 3 Virtual LAN using IP
        L3_IPXVLAN = 137, // Layer 3 Virtual LAN using IPX
        DIGITALPOWERLINE = 138, // IP over Power Lines
        MEDIAMAILOVERIP = 139, // Multimedia Mail over IP
        DTM = 140, // Dynamic syncronous Transfer Mode
        DCN = 141, // Data Communications Network
        IPFORWARD = 142, // IP Forwarding Interface
        MSDSL = 143, // Multi-rate Symmetric DSL
        IEEE1394 = 144, // IEEE1394 High Perf Serial Bus
        IF_GSN = 145,
        DVBRCC_MACLAYER = 146,
        DVBRCC_DOWNSTREAM = 147,
        DVBRCC_UPSTREAM = 148,
        ATM_VIRTUAL = 149,
        MPLS_TUNNEL = 150,
        SRP = 151,
        VOICEOVERATM = 152,
        VOICEOVERFRAMERELAY = 153,
        IDSL = 154,
        COMPOSITELINK = 155,
        SS7_SIGLINK = 156,
        PROP_WIRELESS_P2P = 157,
        FR_FORWARD = 158,
        RFC1483 = 159,
        USB = 160,
        IEEE8023AD_LAG = 161,
        BGP_POLICY_ACCOUNTING = 162,
        FRF16_MFR_BUNDLE = 163,
        H323_GATEKEEPER = 164,
        H323_PROXY = 165,
        MPLS = 166,
        MF_SIGLINK = 167,
        HDSL2 = 168,
        SHDSL = 169,
        DS1_FDL = 170,
        POS = 171,
        DVB_ASI_IN = 172,
        DVB_ASI_OUT = 173,
        PLC = 174,
        NFAS = 175,
        TR008 = 176,
        GR303_RDT = 177,
        GR303_IDT = 178,
        ISUP = 179,
        PROP_DOCS_WIRELESS_MACLAYER = 180,
        PROP_DOCS_WIRELESS_DOWNSTREAM = 181,
        PROP_DOCS_WIRELESS_UPSTREAM = 182,
        HIPERLAN2 = 183,
        PROP_BWA_P2MP = 184,
        SONET_OVERHEAD_CHANNEL = 185,
        DIGITAL_WRAPPER_OVERHEAD_CHANNEL = 186,
        AAL2 = 187,
        RADIO_MAC = 188,
        ATM_RADIO = 189,
        IMT = 190,
        MVL = 191,
        REACH_DSL = 192,
        FR_DLCI_ENDPT = 193,
        ATM_VCI_ENDPT = 194,
        OPTICAL_CHANNEL = 195,
        OPTICAL_TRANSPORT = 196,
        IEEE80216_WMAN = 237,
        WWANPP = 243, // WWAN devices based on GSM technology
        WWANPP2 = 244, // WWAN devices based on CDMA technology
        IEEE802154 = 259, // IEEE 802.15.4 WPAN interface
        XBOX_WIRELESS = 281,
    }

    enum IF_ACCESS_TYPE : int
    {
        LOOPBACK = 1,
        BROADCAST = 2,
        POINT_TO_POINT = 3, // New definition.
        POINTTOPOINT = 3, // Old definition.
        POINT_TO_MULTI_POINT = 4, // New definition.
        POINTTOMULTIPOINT = 4, // Old definition.
    }

    enum IF_CHECK : int
    {
        NONE = 0x00,
        NCAST = 0x01,
        SEND = 0x02,
    }

    enum IF_CONNECTION : int
    {
        DEDICATED = 1,
        PASSIVE = 2,
        DEMAND = 3,
    }

    enum IF_ADMIN_STATUS
    {
        UP = 1,
        DOWN = 2,
        TESTING = 3,
    }

    enum IF_OPER_STATUS
    {
        NON_OPERATIONAL = 0,
        UNREACHABLE = 1,
        DISCONNECTED = 2,
        CONNECTING = 3,
        CONNECTED = 4,
        OPERATIONAL = 5,
    }

    enum MIB_IF_TYPE
    {
        OTHER = 1,
        ETHERNET = 6,
        TOKENRING = 9,
        FDDI = 5,
        PPP = 3,
        LOOPBACK = 4,
        SLIP = 8,
    }

    enum MIB_IF_ADMIN_STATUS
    {
        UP = 1,
        DOWN = 2,
        TESTING = 3,
    }

    /// <summary>
    /// N.B. The name is a misnomer.  These are NOT the values used by MIB-II.
    /// </summary>
    enum MIB_IF_OPER_STATUS
    {
        NON_OPERATIONAL = IF_OPER_STATUS.NON_OPERATIONAL,
        UNREACHABLE = IF_OPER_STATUS.UNREACHABLE,
        DISCONNECTED = IF_OPER_STATUS.DISCONNECTED,
        CONNECTING = IF_OPER_STATUS.CONNECTING,
        CONNECTED = IF_OPER_STATUS.CONNECTED,
        OPERATIONAL = IF_OPER_STATUS.OPERATIONAL,
    }

    /// <summary>
    /// TCP states, as defined in the MIB.
    /// </summary>
    enum MIB_TCP_STATE : int
    {
        CLOSED = 1,
        LISTEN = 2,
        SYN_SENT = 3,
        SYN_RCVD = 4,
        ESTAB = 5,
        FIN_WAIT1 = 6,
        FIN_WAIT2 = 7,
        CLOSE_WAIT = 8,
        CLOSING = 9,
        LAST_ACK = 10,
        TIME_WAIT = 11,
        DELETE_TCB = 12,
        /// <summary>
        /// Extra TCP states not defined in the MIB
        /// </summary>
        RESERVED = 100
    }

    enum TCP_TABLE_CLASS
    {
        BASIC_LISTENER,
        BASIC_CONNECTIONS,
        BASIC_ALL,
        OWNER_PID_LISTENER,
        OWNER_PID_CONNECTIONS,
        OWNER_PID_ALL,
        OWNER_MODULE_LISTENER,
        OWNER_MODULE_CONNECTIONS,
        OWNER_MODULE_ALL
    }

    enum UDP_TABLE_CLASS
    {
        BASIC,
        OWNER_PID,
        OWNER_MODULE
    }

    enum TCPIP_OWNER_MODULE_INFO_CLASS
    {
        BASIC
    }

    enum AF
    {
        UNSPEC = 0,               // unspecified
        UNIX = 1,               // local to host (pipes, portals)
        INET = 2,               // internetwork: UDP, TCP, etc.
        IMPLINK = 3,               // arpanet imp addresses
        PUP = 4,               // pup protocols: e.g. BSP
        CHAOS = 5,               // mit CHAOS protocols
        NS = 6,               // XEROX NS protocols
        IPX = NS,           // IPX protocols: IPX, SPX, etc.
        ISO = 7,               // ISO protocols
        OSI = ISO,          // OSI is ISO
        ECMA = 8,               // european computer manufacturers
        DATAKIT = 9,               // datakit protocols
        CCITT = 10,              // CCITT protocols, X.25 etc
        SNA = 11,              // IBM SNA
        DECnet = 12,              // DECnet
        DLI = 13,              // Direct data link interface
        LAT = 14,              // LAT
        HYLINK = 15,              // NSC Hyperchannel
        APPLETALK = 16,              // AppleTalk
        NETBIOS = 17,              // NetBios-style addresses
        VOICEVIEW = 18,              // VoiceView
        FIREFOX = 19,              // Protocols from Firefox
        UNKNOWN1 = 20,              // Somebody is using this!
        BAN = 21,              // Banyan
        ATM = 22,              // Native ATM Services
        INET6 = 23,              // Internetwork Version 6
        CLUSTER = 24,              // Microsoft Wolfpack
        IEEE_12844 = 25,              // IEEE 1284.4 WG AF
        IRDA = 26,              // IrDA
        NETDES = 28,              // Network Designers OSI & gateway
        MAX_WINNT_0501 = 29,
        TCNPROCESS = 29,
        TCNMESSAGE = 30,
        ICLFXBM = 31,
        MAX_WINNT_0600 = 32,
        BTH = 32,              // Bluetooth RFCOMM/L2CAP protocols
        MAX_WINNT_0601 = 33,
        LINK = 33,
        MAX_WINNT_0604 = 34,
        HYPERV = 34,
        MAX = 35,
    }
}
