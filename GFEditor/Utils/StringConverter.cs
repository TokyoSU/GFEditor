using System.Text;

namespace GFEditor.Utils
{
    public static class StringConverter
    {
        public static readonly Encoding Big5 = Encoding.GetEncoding("Big5");

        public static byte[] ToStringBig5(this string str)
        {
            return Big5.GetBytes(str);
        }


    }
}
