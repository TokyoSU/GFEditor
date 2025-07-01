namespace GFEditor.Structs
{
    public class ClassesTextures
    {
        private static readonly Logger m_Log = LogManager.GetCurrentClassLogger();
        private readonly Dictionary<ERestrictClass, Texture2D> m_ClassTextures = [];

        public void LoadTextures()
        {
            var values = Enum.GetValues<ERestrictClass>();
            foreach (var value in values)
            {
                if (value == ERestrictClass.None) continue;
                string filePath = string.Format("textures/classes/{0}.png", value.ToString().ToLower());
                if (filePath.FileExist())
                    m_ClassTextures.TryAdd(value, TextureUtils.LoadTextureFromFile(filePath));
                else
                    m_Log.Warn("Failed to load class image " + value.ToString() + ", file not found !");
            }
        }

        public Texture2D GetTextureByEnum(ERestrictClass value) => m_ClassTextures[value];

        public void Draw(ERestrictClass value)
        {
            ImGuiUtils.Image(GetTextureByEnum(value));
        }

        public void Dispose()
        {
            foreach (var texture in m_ClassTextures.Values)
                TextureUtils.DisposeTexture(texture);
            m_ClassTextures.Clear();
        }
    }
}
