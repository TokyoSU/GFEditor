namespace GFEditor.Utils.Extensions
{
    public static class ListExtensions
    {
        public static List<string> AsStringList(this List<ulong> values)
        {
            var list = new List<string>();
            foreach (var value in values)
                list.Add(value.ToString());
            return list;
        }

        public static IEnumerable<string>? ToStringEnumerable(this IEnumerable<ulong>? values)
        {
            if (values == null) return default;
            var list = new List<string>();
            foreach (var value in values)
                list.Add(value.ToString());
            return list;
        }

        public static string[] ToStringArray(this IEnumerable<uint>? values)
        {
            if (values == null) return [];
            var size = values.Count();
            var srcList = values.ToList();
            var result = new string[size];
            for (int i = 0; i < size; i++)
                result[i] = srcList[i].ToString();
            return result;
        }

        public static string[] ToStringArray(this IEnumerable<ulong>? values)
        {
            if (values == null) return [];
            var size = values.Count();
            var srcList = values.ToList();
            var result = new string[size];
            for (int i = 0; i < size; i++)
                result[i] = srcList[i].ToString();
            return result;
        }
    }
}
