using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EBML
{
    /// <summary>
    /// Integer Utility Class
    /// </summary>
    public static class IntUtils
    {
        #region Padding

        // Unsigned
        /// <summary>
        /// Pads a non standard unsigned integer to 8 bit.
        /// </summary>
        /// <param name="dat">Byte containing non standard integer</param>
        /// <param name="width">Width of the non standard integer</param>
        /// <returns></returns>
        public static Byte PadU8(Byte dat, Int32 width)
        {
            return dat.Bits(width - 1, 0);
        }
        /// <summary>
        /// Pads a non standard unsigned integer to 16 bit.
        /// </summary>
        /// <param name="dat">UInt16 containing non standard integer</param>
        /// <param name="width">Width of the non standard integer</param>
        /// <returns></returns>
        public static UInt16 PadU16(UInt16 dat, Int32 width)
        {
            return dat.Bits(width - 1, 0);
        }
        /// <summary>
        /// Pads a non standard unsigned integer to 32 bit.
        /// </summary>
        /// <param name="dat">UInt32 containing non standard integer</param>
        /// <param name="width">Width of the non standard integer</param>
        /// <returns></returns>
        public static UInt32 PadU32(UInt32 dat, Int32 width)
        {
            return dat.Bits(width - 1, 0);
        }
        /// <summary>
        /// Pads a non standard unsigned integer to 64 bit.
        /// </summary>
        /// <param name="dat">UInt64 containing non standard integer</param>
        /// <param name="width">Width of the non standard integer</param>
        /// <returns></returns>
        public static UInt64 PadU64(UInt64 dat, Int32 width)
        {
            return dat.Bits(width - 1, 0);
        }

        // Signed
        /// <summary>
        /// Pads a non standard signed integer to 8 bit.
        /// </summary>
        /// <param name="dat">Byte containing non standard integer</param>
        /// <param name="width">Width of the non standard integer</param>
        /// <returns></returns>
        public static SByte PadS8(Byte dat, Int32 width)
        {
            // Assuming that highest bit is sign bit
            Boolean sign = (dat & (1 << width - 1)) != 0;
            Byte value = dat.Bits(width - 2, 0);

            // if the value is negative...
            if (sign) return (SByte)(value - (Byte)Math.Pow(2, width - 1)); // Get 2's complement of the value

            // if it is positive, return value
            return (SByte)value;
        }
        /// <summary>
        /// Pads a non standard signed integer to 16 bit.
        /// </summary>
        /// <param name="dat">UInt16 containing non standard integer</param>
        /// <param name="width">Width of the non standard integer</param>
        /// <returns></returns>
        public static Int16 PadS16(UInt16 dat, Int32 width)
        {
            // Assuming that highest bit is sign bit
            Boolean sign = (dat & (1 << width - 1)) != 0;
            UInt16 value = dat.Bits(width - 2, 0);

            // if the value is negative...
            if (sign) return (short) (value - Math.Pow(2, width - 1)); // Get 2's complement of the value
            
            // if it is positive, return value
            return (Int16) value;
        }
        /// <summary>
        /// Pads a non standard signed integer to 32 bit.
        /// </summary>
        /// <param name="dat">UInt32 containing non standard integer</param>
        /// <param name="width">Width of the non standard integer</param>
        /// <returns></returns>
        public static Int32 PadS32(UInt32 dat, Int32 width)
        {
            // Assuming that highest bit is sign bit
            Boolean sign = (dat & (1 << width - 1)) != 0;
            UInt32 value = dat.Bits(width - 2, 0);

            // if the value is negative...
            if (sign) return (Int32)(value - Math.Pow(2, width - 1)); // Get 2's complement of the value

            // if it is positive, return value
            return (Int32)value;
        }
        /// <summary>
        /// Pads a non standard signed integer to 64 bit.
        /// </summary>
        /// <param name="dat">UInt64 containing non standard integer</param>
        /// <param name="width">Width of the non standard integer</param>
        /// <returns></returns>
        public static Int64 PadS64(UInt64 dat, Int32 width)
        {
            // Assuming that highest bit is sign bit
            Boolean sign = (dat & (1UL << width - 1)) != 0;
            UInt64 value = dat.Bits(width - 2, 0);

            // if the value is negative...
            if (sign)
                return (long)(value - ((ulong)Math.Pow(2, width - 1))); // Get 2's complement of the value

            // if it is positive, return value
            return (Int64)value;
        }
        
        #endregion
    }
}
