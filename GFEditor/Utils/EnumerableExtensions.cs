namespace GFEditor.Utils
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(action);
            int index = 0;
            foreach (var item in source)
            {
                action(item, index);
                index++;
            }
        }

        public static void ForEach(this ComboBox.ObjectCollection source, Action<string?, int> action)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(action);
            int index = 0;
            foreach (var item in source)
            {
                action(item.ToString(), index);
                index++;
            }
        }
    }
}
