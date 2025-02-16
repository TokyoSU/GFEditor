namespace GFEditor.Utils
{
    public static class StringConverter
    {
        /// <summary>
        /// Register code page encodings, required for big5 encoding type.
        /// </summary>
        public static void Initialize() => Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        public static Encoding GetChinese() => Encoding.GetEncoding("big5");

        public static byte[] ToStringBig5(this string str)
        {
            return GetChinese().GetBytes(str);
        }

        public static string RemoveString(this string str, string valueToRemove)
        {
            string result = str;
            if (str.Contains(valueToRemove))
                result = str.Replace(valueToRemove, "");
            return result;
        }
    }
}
