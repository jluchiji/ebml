// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// EBML#/EBML/IntUtils.cs
// --------------------------------------------------------------------------------
// Copyright (C) 2013, Jieni Luchijinzhou a.k.a Aragorn Wyvernzora
// All rights reserved.
// 
// This file is part of EBML#.
// 
//     EBML# is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     EBML# is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with EBML#.  If not, see <http://www.gnu.org/licenses/>.
// 
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

using System;

namespace EBML
{
    /// <summary>
    ///     Integer Utility Class
    /// </summary>
    public static class IntUtils
    {
        #region Padding

        // Unsigned
        /// <summary>
        ///     Pads a non standard unsigned integer to 8 bit.
        /// </summary>
        /// <param name="dat">Byte containing non standard integer</param>
        /// <param name="width">Width of the non standard integer</param>
        /// <returns></returns>
        public static Byte PadU8(Byte dat, Int32 width)
        {
            return dat.Bits(width - 1, 0);
        }

        /// <summary>
        ///     Pads a non standard unsigned integer to 16 bit.
        /// </summary>
        /// <param name="dat">UInt16 containing non standard integer</param>
        /// <param name="width">Width of the non standard integer</param>
        /// <returns></returns>
        public static UInt16 PadU16(UInt16 dat, Int32 width)
        {
            return dat.Bits(width - 1, 0);
        }

        /// <summary>
        ///     Pads a non standard unsigned integer to 32 bit.
        /// </summary>
        /// <param name="dat">UInt32 containing non standard integer</param>
        /// <param name="width">Width of the non standard integer</param>
        /// <returns></returns>
        public static UInt32 PadU32(UInt32 dat, Int32 width)
        {
            return dat.Bits(width - 1, 0);
        }

        /// <summary>
        ///     Pads a non standard unsigned integer to 64 bit.
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
        ///     Pads a non standard signed integer to 8 bit.
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
            if (sign) return (SByte) (value - (Byte) Math.Pow(2, width - 1)); // Get 2's complement of the value

            // if it is positive, return value
            return (SByte) value;
        }

        /// <summary>
        ///     Pads a non standard signed integer to 16 bit.
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
        ///     Pads a non standard signed integer to 32 bit.
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
            if (sign) return (Int32) (value - Math.Pow(2, width - 1)); // Get 2's complement of the value

            // if it is positive, return value
            return (Int32) value;
        }

        /// <summary>
        ///     Pads a non standard signed integer to 64 bit.
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
                return (long) (value - ((ulong) Math.Pow(2, width - 1))); // Get 2's complement of the value

            // if it is positive, return value
            return (Int64) value;
        }

        #endregion

        #region Shrinking

        /// <summary>
        ///     Shrinks an unsigned integer to the specified width.
        /// </summary>
        /// <param name="dat">Integer to shrink</param>
        /// <param name="width">Bit width of the new representation</param>
        /// <exception cref="ArgumentException">Throws ArgumentException when value cannot fit in the specified width</exception>
        /// <returns>UInt64 containing shrinked representation of the integer</returns>
        public static UInt64 ShrinkUnsigned(UInt64 dat, Int32 width)
        {
            // Check if the value fits
            if (CompactWidthUnsigned(dat) > width)
                throw new ArgumentException(
                    String.Format(
                        "IntUtils.ShrinkUnsigned(Uint64, Int32) : Compact representation of the value is {0} bit wide, but only {1} bits are available.",
                        CompactWidthUnsigned(dat), width));

            // Shrink the value (do nothing since it's unsigned)
            return dat;
        }

        /// <summary>
        ///     Shrinks a signed integer to the specified width.
        /// </summary>
        /// <param name="dat">Integer to shrink</param>
        /// <param name="width">Bit width of the new representation</param>
        /// <exception cref="ArgumentException">Throws ArgumentException when value cannot fit in the specified width</exception>
        /// <returns>UInt64 containing shrinked representation of the integer</returns>
        public static UInt64 ShrinkSigned(Int64 dat, Int32 width)
        {
            // Check if the value fits
            if (CompactWidthSigned(dat) > width)
                throw new ArgumentException(
                    String.Format(
                        "IntUtils.ShrinkSigned(Uint64, Int32) : Compact representation of the value is {0} bit wide, but only {1} bits are available.",
                        CompactWidthSigned(dat), width));

            // Shrink the value
            if (dat >= 0) return (UInt64) dat; // if the value is positive no firther action needed
            UInt64 result = (UInt64) (Math.Pow(2, width - 1) + dat); // 2's complement of the value
            result |= 1UL << width - 1; // Put sign bit in place

            return result;
        }

        /// <summary>
        ///     Calculates the minimum number of bits necessary to represent a signed integer.
        /// </summary>
        /// <param name="dat">Integer</param>
        /// <returns>Minimum number of bits necessary to represent the integer</returns>
        public static Int32 CompactWidthSigned(Int64 dat)
        {
            return (Int32) Math.Ceiling(Math.Log(Math.Abs(dat) + 1, 2)) + 1;
        }

        /// <summary>
        ///     Calculates the minimum number of bits necessary to represent an unsigned integer.
        /// </summary>
        /// <param name="dat">Integer</param>
        /// <returns>Minimum number of bits necessary to represent the integer</returns>
        public static Int32 CompactWidthUnsigned(UInt64 dat)
        {
            return (Int32) Math.Ceiling(Math.Log(dat + 1, 2)) + 1;
        }

        #endregion
    }
}