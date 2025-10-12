using GFEditor.Renderer;

namespace GFEditor.Widgets
{
    public static class IconSkill
    {
        private static readonly Dictionary<string, Texture2D> m_SkillIcons = [];

        public static Texture2D? GetByName(string name)
        {
            if (m_SkillIcons == null) return null;

            // if exist check it..
            if (m_SkillIcons.TryGetValue(name, out Texture2D? value))
                return value;

            // Else add it !
            var imagePath = ConfigUtils.GetPath("UI\\skillicon\\" + name + ".dds");
            if (imagePath.FileExist())
            {
                var fileName = Path.GetFileNameWithoutExtension(imagePath).ToLower();
                if (fileName != name) return null;
                if (m_SkillIcons.TryAdd(fileName, TextureUtils.LoadTextureFromFile(imagePath)))
                    return m_SkillIcons[fileName];
            }

            // If either not added or found return null !
            return null;
        }

        public static void Dispose()
        {
            foreach (var icon in m_SkillIcons.Values)
                icon.Dispose();
            m_SkillIcons.Clear();
        }
    }
}
