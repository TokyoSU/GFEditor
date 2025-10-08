using GFEditor.Renderer;

namespace GFEditor.Widgets
{
    public static class ImageChest
    {
        private static readonly Logger m_Log = LogManager.GetCurrentClassLogger();
        private static readonly Dictionary<string, Texture2D> m_ImageDrops = [];

        public static Texture2D? GetByName(string name)
        {
            if (m_ImageDrops == null) return null;

            // if exist check it..
            if (m_ImageDrops.TryGetValue(name, out Texture2D? value))
                return value;

            // Else add it !
            var dropPath = ConfigUtils.GetRelativePath(Path.Combine("textures\\chest", name + ".png"));
            if (dropPath.FileExist())
            {
                var fileName = Path.GetFileNameWithoutExtension(dropPath);
                if (fileName != name) return null;
                if (m_ImageDrops.TryAdd(name, TextureUtils.LoadTextureFromFile(dropPath)))
                    return m_ImageDrops[name];
            }

            // If either not added or found return null !
            return null;
        }

        public static void Dispose()
        {
            if (m_ImageDrops == null) return;
            foreach (var img in m_ImageDrops)
                img.Value.Dispose();
            m_ImageDrops.Clear();
        }
    }
}
