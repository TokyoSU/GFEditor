namespace GFEditor.Utils
{
    public static class IntegerExtensions
    {
        public static int ReplaceIf(this int value, int from, int to)
        {
            if (value == from)
                value = to;
            return value;
        }
    }
}
