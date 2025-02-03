using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GFEditor.Utils
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (action == null) throw new ArgumentNullException(nameof(action));

            int index = 0;
            foreach (var item in source)
            {
                action(item, index);
                index++;
            }
        }

        public static void ForEach(this ComboBox.ObjectCollection source, Action<string, int> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (action == null) throw new ArgumentNullException(nameof(action));

            int index = 0;
            foreach (var item in source)
            {
                action(item.ToString(), index);
                index++;
            }
        }
    }
}
