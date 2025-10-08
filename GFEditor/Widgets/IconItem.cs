using GFEditor.Renderer;

namespace GFEditor.Widgets
{
    public static class IconItem
    {
        private static readonly Dictionary<string, Texture2D> m_ItemIcons = [];

        public static Texture2D? GetByName(string name)
        {
            if (m_ItemIcons == null) return null;

            // if exist check it..
            if (m_ItemIcons.TryGetValue(name, out Texture2D? value))
                return value;

            // Else add it !
            var imagePath = ConfigUtils.GetPath("UI\\itemicon\\" + name + ".dds");
            if (imagePath.FileExist())
            {
                var fileName = Path.GetFileNameWithoutExtension(imagePath).ToLower();
                if (fileName != name) return null;
                if (m_ItemIcons.TryAdd(fileName, TextureUtils.LoadTextureFromFile(imagePath)))
                    return m_ItemIcons[fileName];
            }

            // If either not added or found return null !
            return null;
        }

        public static void Dispose()
        {
            foreach (var icon in m_ItemIcons.Values)
                icon.Dispose();
            m_ItemIcons.Clear();
        }
    }
}
