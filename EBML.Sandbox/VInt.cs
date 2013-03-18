using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EBML.Sandbox
{
    /*
    /// <summary>
    /// Variable Width Integer
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    public struct VInt
    {
        private Int64 value;
        private Byte width;
        private Byte headWidth;

        #region Constructors

        /// <summary>
        /// Constructor.
        /// Reades a VInt from stream.
        /// </summary>
        /// <param name="input">Input Stream</param>
        public VInt(Stream input)
        {
            
        }

        public VInt(Byte[] rawData)
        {
            // Check Argument
            if (rawData == null)
                throw new ArgumentNullException();
            if (rawData.Length < 1)
                throw new ArgumentException();

            // Calculate Integer Width
            width = (Byte) CalculateWidth(rawData[0]);
            headWidth = (Byte) ((width / 8 + 1) * 8 - width);

            // Calculate Integer Value (Unsigned, Little Endian)
            value = 0;
            value |= (rawData[0] & (0xFF >> headWidth));
            for (int i = 1; i < (headWidth + width) / 8; i++)
            {
                value <<= 8;
                value |= rawData[i];
            }

            // TODO is value even little endian? if it's not, figure out how to read it
        }

        #endregion

        #region Utility Methods

        /// <summary>
        /// Calculates the width of the VInt from the first byte
        /// </summary>
        /// <param name="head">First byte of the VInt</param>
        /// <returns>Width of integer part in bits</returns>
        public static Int32 CalculateWidth(Byte head)
        {
            for (int i = 0; i < 8; i++) // Max Width = 64bit
                if ((head & (0x80 >> i)) != 0) return (byte)((i + 1) * 8 - i - 1);
            return 0;
        }

        #endregion
    }
     * */
}
