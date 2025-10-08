using GFEditor.Renderer;

namespace GFEditor.Widgets
{
    public static class IconClass
    {
        private static readonly Logger m_Log = LogManager.GetCurrentClassLogger();
        private static readonly Dictionary<ERestrictClass, Texture2D> m_ClassIcons = [];

        public static void Initialize()
        {
            var values = Enum.GetValues<ERestrictClass>();
            foreach (var value in values)
            {
                if (m_ClassIcons.ContainsKey(value)) continue;
                if (value == ERestrictClass.None) continue;

                var filePath = Path.Combine(ConfigUtils.GetRelativePath("textures\\classes"), value.ToString().ToLower() + ".png");
                if (filePath.FileExist())
                    m_ClassIcons.TryAdd(value, TextureUtils.LoadTextureFromFile(filePath));
                else
                    m_Log.Warn("Failed to load class image " + value.ToString() + ", file not found !");
            }
        }

        public static Texture2D? GetByEnum(ERestrictClass restrictClass)
        {
            if (m_ClassIcons.TryGetValue(restrictClass, out var texture))
                return texture;
            return null;
        }

        public static void Dispose()
        {
            foreach (var texture in m_ClassIcons.Values)
                texture.Dispose();
            m_ClassIcons.Clear();
        }
    }
}
