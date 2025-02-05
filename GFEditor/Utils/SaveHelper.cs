namespace GFEditor.Utils
{
    public static class SaveHelper
    {
        public static void SaveJson(string filePath, object value)
        {
            using var file = File.CreateText(filePath);
            var serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
            };
            serializer.Serialize(file, value);
        }
    }
}
