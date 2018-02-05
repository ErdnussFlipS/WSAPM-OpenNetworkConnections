using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace de.efsdev.DotNetExtensionLibrary.Extensions
{
    public static class MarshalExtension
    {
        public interface IDynamicStructure
        {
            void SetFieldsWithPointer(IntPtr pointer);
        }

        public static T[] PtrToArray<T>(IntPtr pointer, uint arraySize, Func<IntPtr, T> readItem)
        {
            IntPtr currentPointer = pointer;

            T[] array = new T[arraySize];
            for (uint i = 0; i < array.Length; i++)
            {
                array[i] = readItem.Invoke(currentPointer);
                currentPointer += Marshal.SizeOf(typeof(T));
            }
            return array;
        }

        public static T PtrToStructure<T>(IntPtr pointer) where T : struct
        {
            T structure;
            if (typeof(T).GetInterfaces().Contains(typeof(IDynamicStructure)))
            {
                structure = new T();
                var dynamicStructure = (IDynamicStructure)structure;
                dynamicStructure.SetFieldsWithPointer(pointer);
                structure = (T)dynamicStructure;
            }
            else
            {
                structure = (T)Marshal.PtrToStructure(pointer, typeof(T));
            }

            return structure;
        }
    }
}
