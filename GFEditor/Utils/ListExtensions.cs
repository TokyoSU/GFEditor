using System;
using System.Collections.Generic;
using System.Globalization;

namespace GFEditor.Utils
{
    public static class ListExtensions
    {
        /// <summary>
        /// Get int value from a string list based on index position.
        /// </summary>
        /// <param name="list">The list of strings.</param>
        /// <param name="index">A valid index, no check is being done except int.TryParse</param>
        /// <returns>Valid or 0</returns>
        public static int GetInt(this List<string> list, int index)
        {
            // Try parsing as a double with invariant culture
            if (double.TryParse(list[index], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var dResult))
            {
                // If double is parsed, convert to int (rounding the value)
                return Convert.ToInt32(dResult);
            }

            // If not a double, try parsing as an integer
            if (int.TryParse(list[index], out var value))
            {
                return value;
            }

            // Fallback value if both parsing attempts fail
            return 0;
        }

        public static double GetDouble(this List<string> list, int index)
        {
            // Try parsing as a double with invariant culture
            if (double.TryParse(list[index], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var dResult))
            {
                // If double is parsed, convert to int (rounding the value)
                return dResult;
            }

            // If not a double, try parsing as an integer
            if (int.TryParse(list[index], out var value))
            {
                return value;
            }

            // Fallback value if both parsing attempts fail
            return 0.0;
        }

        public static uint GetUInt(this List<string> list, int index)
        {
            // If not a double, try parsing as an integer
            if (uint.TryParse(list[index], out var value))
            {
                return value;
            }
            // Fallback value if parsing attempts fail
            return 0;
        }

        /// <summary>
        /// Get ulong value from a string list based on index position.
        /// </summary>
        /// <param name="list">The list of strings.</param>
        /// <param name="index">A valid index, no check is being done except ulong.TryParse</param>
        /// <returns>Valid or 0</returns>
        public static ulong GetULong(this List<string> list, int index)
        {
            if (ulong.TryParse(list[index], out var value))
                return value;
            return 0;
        }

        /// <summary>
        /// Get ulong value from a string list based on index position.
        /// </summary>
        /// <param name="list">The list of strings.</param>
        /// <param name="index">A valid index, no check is being done except ulong.TryParse</param>
        /// <returns>Valid or 0</returns>
        public static ulong GetHex(this List<string> list, int index)
        {
            if (string.IsNullOrEmpty(list[index]) || string.IsNullOrWhiteSpace(list[index]))
                return 0; // none
            return ulong.Parse(list[index], NumberStyles.HexNumber);
        }
    }
}
