namespace GFEditor.Utils
{
    public static class ComboBoxExtensions
    {
        public static void SelectIndexByName(this ComboBox box, string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                box.Items.ForEach((fileName, index) =>
                {
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        if (name.Equals(fileName, StringComparison.CurrentCultureIgnoreCase))
                            box.SelectedIndex = index;
                    }
                });
            }
            else
            {
                box.SelectedIndex = 0;
            }
        }

        public static void SelectIndexByEnum<TEnum>(this ComboBox box, TEnum value) where TEnum : Enum
        {
            if (!EqualityComparer<TEnum>.Default.Equals(value, default))
            {
                box.Items.ForEach((enumName, index) =>
                {
                    if (!string.IsNullOrEmpty(enumName))
                    {
                        if (value.ToString().ToLower().Equals(enumName.ToLower()))
                            box.SelectedIndex = index;
                    }
                });
            }
            else
            {
                box.SelectedIndex = 0;
            }
        }
    }
}
