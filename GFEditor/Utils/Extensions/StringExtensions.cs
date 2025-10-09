using System.Globalization;

namespace GFEditor.Extensions
{
    public static class StringExtensions
    {
        /// BASICS

        public static bool IsValid(this string value) => !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value);

        public static bool FileExist(this string value) => IsValid(value) && File.Exists(value);

        public static bool FolderExist(this string path) => IsValid(path) && Directory.Exists(path);

        private static bool IsDigitsOnly(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            for (int i = 0; i < input.Length; i++)
                if (!char.IsDigit(input[i])) return false;
            return true;
        }

        private static bool IsHexDigitsOnly(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (!(char.IsDigit(c) || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f')))
                    return false;
            }
            return true;
        }

        private static bool IsBinaryDigitsOnly(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            for (int i = 0; i < input.Length; i++)
                if (input[i] != '0' && input[i] != '1') return false;
            return true;
        }

        public static char AsChar(this string str) => str.Length > 0 ? str[0] : (char)0;

        public static byte AsByte(this string str) => byte.TryParse(str, out var value) ? value : (byte)0;

        public static sbyte AsSByte(this string str) => sbyte.TryParse(str, out var value) ? value : (sbyte)0;

        public static short AsShort(this string str) => short.TryParse(str, out var value) ? value : (short)0;

        public static ushort AsUShort(this string str) => ushort.TryParse(str, out var value) ? value : (ushort)0;

        public static int AsInt(this string str) => int.TryParse(str, out var value) ? value : 0;

        public static uint AsUInt(this string str) => uint.TryParse(str, out var value) ? value : 0;

        public static long AsLong(this string str) => long.TryParse(str, out var value) ? value : 0;

        public static ulong AsULong(this string str) => ulong.TryParse(str, out var value) ? value : 0;

        public static float AsSingle(this string str) => float.TryParse(str, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out var value) ? value : 0f;

        public static double AsDouble(this string str) => double.TryParse(str, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out var value) ? value : 0.0;

        public static ulong AsHex(this string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;

            if (str.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                str = str[2..];
            else if (str.StartsWith("#"))
                str = str[1..];

            return !IsHexDigitsOnly(str) ? 0 : ulong.TryParse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var value) ? value : 0;
        }

        public static BigInteger AsBigInteger(this string str)
        {
            if (string.IsNullOrEmpty(str)) return BigInteger.Zero;

            // Handle hexadecimal (0x)
            if (str.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                str = str[2..];
                return IsHexDigitsOnly(str) ? BigInteger.Parse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture) : BigInteger.Zero;
            }

            // Handle scientific notation (e.g., "1.23e10")
            if (str.Contains('e') || str.Contains('E'))
            {
                if (double.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out double dblValue))
                    return new BigInteger(dblValue);
                return BigInteger.Zero;
            }

            // Standard integer parsing
            return IsDigitsOnly(str) ? BigInteger.Parse(str, NumberStyles.Integer, CultureInfo.InvariantCulture) : BigInteger.Zero;
        }

        public static ulong AsBinary(this string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;

            // Remove "0b" prefix if present
            if (str.StartsWith("0b", StringComparison.OrdinalIgnoreCase))
                str = str[2..];

            // Ensure the remaining string contains only 0s and 1s
            if (!IsBinaryDigitsOnly(str)) return 0;

            // Convert binary string to number
            return Convert.ToUInt64(str, 2);
        }

        /// FROM ARRAYS

        public static string At(this string strings, int index, char separator)
        {
            var splitted = strings.Split(separator);
            if (index >= splitted.Length)
                return string.Empty;
            return splitted[index];
        }


    }
}
