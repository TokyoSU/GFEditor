namespace GFEditor.Utils
{
    public static class EditorHelper
    {
        public static void TranslateClassText(this Dictionary<ClassType, CheckBox> destDict, TEditorItemClassPanel translated)
        {
            foreach (var src in translated.GetValuesByClassTypes())
            {
                foreach (var dest in destDict)
                {
                    if (dest.Key == src.Key)
                        dest.Value.Text = src.Value;
                }
            }
        }

    }
}
