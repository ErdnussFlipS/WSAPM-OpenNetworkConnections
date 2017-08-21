using de.efsdev.DotNetExtensionLibrary.Extensions;
using IpHelperAPI.ComBridge.Enums;
using System;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Net;
using System.Linq;
using System.Numerics;

namespace IpHelperAPI.ComBridge.Structs
{
    [StructLayout(LayoutKind.Explicit)]
    internal struct MIB_IFROW
    {
        const int wszNameSize = 2 * sizeof(byte) * Constants.MAX_INTERFACE_NAME_LEN;
        const int bPhysAddrSize = sizeof(byte) * Constants.MAXLEN_PHYSADDR;

        [FieldOffset(0)] char[] wszName;
        [FieldOffset(wszNameSize)] UInt32 dwIndex;
        [FieldOffset(wszNameSize + sizeof(UInt32))] IF_TYPE dwType;
        [FieldOffset(wszNameSize + 2 * sizeof(UInt32))] UInt32 dwMtu;
        [FieldOffset(wszNameSize + 3 * sizeof(UInt32))] UInt32 dwSpeed;
        [FieldOffset(wszNameSize + 4 * sizeof(UInt32))] UInt32 dwPhysAddrLen;
        [FieldOffset(wszNameSize + 5 * sizeof(UInt32))] byte[] bPhysAddr;
        [FieldOffset(wszNameSize + 5 * sizeof(UInt32) + bPhysAddrSize)] UInt32 dwAdminStatus;
        [FieldOffset(wszNameSize + 6 * sizeof(UInt32) + bPhysAddrSize)] IF_OPER_STATUS dwOperStatus;
        [FieldOffset(wszNameSize + 7 * sizeof(UInt32) + bPhysAddrSize)] UInt32 dwLastChange;
        [FieldOffset(wszNameSize + 8 * sizeof(UInt32) + bPhysAddrSize)] UInt32 dwInOctets;
        [FieldOffset(wszNameSize + 9 * sizeof(UInt32) + bPhysAddrSize)] UInt32 dwInUcastPkts;
        [FieldOffset(wszNameSize + 10 * sizeof(UInt32) + bPhysAddrSize)] UInt32 dwInNUcastPkts;
        [FieldOffset(wszNameSize + 11 * sizeof(UInt32) + bPhysAddrSize)] UInt32 dwInDiscards;
        [FieldOffset(wszNameSize + 12 * sizeof(UInt32) + bPhysAddrSize)] UInt32 dwInErrors;
        [FieldOffset(wszNameSize + 13 * sizeof(UInt32) + bPhysAddrSize)] UInt32 dwInUnknownProtos;
        [FieldOffset(wszNameSize + 14 * sizeof(UInt32) + bPhysAddrSize)] UInt32 dwOutOctets;
        [FieldOffset(wszNameSize + 15 * sizeof(UInt32) + bPhysAddrSize)] UInt32 dwOutUcastPkts;
        [FieldOffset(wszNameSize + 16 * sizeof(UInt32) + bPhysAddrSize)] UInt32 dwOutNUcastPkts;
        [FieldOffset(wszNameSize + 17 * sizeof(UInt32) + bPhysAddrSize)] UInt32 dwOutDiscards;
        [FieldOffset(wszNameSize + 18 * sizeof(UInt32) + bPhysAddrSize)] UInt32 dwOutErrors;
        [FieldOffset(wszNameSize + 19 * sizeof(UInt32) + bPhysAddrSize)] UInt32 dwOutQLen;
        [FieldOffset(wszNameSize + 20 * sizeof(UInt32) + bPhysAddrSize)] UInt32 dwDescrLen;
        [FieldOffset(wszNameSize + 21 * sizeof(UInt32) + bPhysAddrSize)] byte[] bDescr;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct MIB_TCPTABLE : MarshalExtension.IDynamicStructure
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint dwNumEntries;
        public MIB_TCPROW[] table;

        public void SetFieldsWithPointer(IntPtr pointer)
        {
            IntPtr pointerValue = pointer;
            dwNumEntries = (uint)Marshal.ReadInt32(pointerValue);

            pointerValue += sizeof(uint);
            table = MarshalExtension.PtrToArray(pointerValue, (int)dwNumEntries, innerPointer => MarshalExtension.PtrToStructure<MIB_TCPROW>(innerPointer));
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct MIB_TCPROW
        {
            [FieldOffset(0)]
            [MarshalAs(UnmanagedType.U4)]
            public uint dwstate;

            [FieldOffset(0)]
            [MarshalAs(UnmanagedType.U4)]
            public MIB_TCP_STATE State;

            [FieldOffset(1 * sizeof(uint))]
            [MarshalAs(UnmanagedType.U4)]
            public uint dwLocalAddr;

            [FieldOffset(2 * sizeof(uint))]
            [MarshalAs(UnmanagedType.U4)]
            public uint dwLocalPort;

            [FieldOffset(3 * sizeof(uint))]
            [MarshalAs(UnmanagedType.U4)]
            public uint dwRemoteAddr;

            [FieldOffset(4 * sizeof(uint))]
            [MarshalAs(UnmanagedType.U4)]
            public uint dwRemotePort;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct MIB_TCP6TABLE_OWNER_PID : MarshalExtension.IDynamicStructure
    {
        public UInt32 dwNumEntries;
        public MIB_TCP6ROW_OWNER_PID[] table;

        public void SetFieldsWithPointer(IntPtr pointer)
        {
            IntPtr pointerValue = pointer;
            dwNumEntries = (uint)Marshal.ReadInt32(pointerValue);

            pointerValue += sizeof(uint);
            table = MarshalExtension.PtrToArray(pointerValue, (int)dwNumEntries, innerPointer => MarshalExtension.PtrToStructure<MIB_TCP6ROW_OWNER_PID>(innerPointer));
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct MIB_TCP6ROW_OWNER_PID
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] ucLocalAddr;
            public uint dwLocalScopeId;
            public uint dwLocalPort;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] ucRemoteAddr;
            public uint dwRemoteScopeId;
            public uint dwRemotePort;
            public uint dwState;
            public uint dwOwningPid;

            public BigInteger LocalAddress
            {
                get
                {
                    return new BigInteger(ucLocalAddr);
                }
            }

            public BigInteger RemoteAddress
            {
                get
                {
                    return new BigInteger(ucRemoteAddr);
                }
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct MIB_TCP6TABLE_OWNER_MODULE : MarshalExtension.IDynamicStructure
    {
        public UInt32 dwNumEntries;
        public MIB_TCP6ROW_OWNER_MODULE[] table;

        public void SetFieldsWithPointer(IntPtr pointer)
        {
            IntPtr pointerValue = pointer;
            dwNumEntries = (uint)Marshal.ReadInt32(pointerValue);

            pointerValue += sizeof(Int32);
            table = MarshalExtension.PtrToArray(pointerValue, (int)dwNumEntries, innerPointer => MarshalExtension.PtrToStructure<MIB_TCP6ROW_OWNER_MODULE>(innerPointer));
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct MIB_TCP6ROW_OWNER_MODULE
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] ucLocalAddr;
            public UInt32 dwLocalScopeId;
            public UInt32 dwLocalPort;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] ucRemoteAddr;
            public UInt32 dwRemoteScopeId;
            public UInt32 dwRemotePort;
            public UInt32 dwState;
            public UInt32 dwOwningPid;
            public Int64 liCreateTimestamp;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.TCPIP_OWNING_MODULE_SIZE)]
            UInt64[] OwningModuleInfo;
        }
    }
}
