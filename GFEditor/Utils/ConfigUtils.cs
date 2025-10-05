using System.Diagnostics.CodeAnalysis;

namespace GFEditor.Utils
{
    public class CConfigPath
    {
        [JsonProperty("Game")]
        public string Game = string.Empty;
    }

    public class CConfigUbuntu
    {
        [JsonProperty("Host")]
        public string Host = string.Empty;

        [JsonProperty("HostKey")]
        public string HostKey = string.Empty;

        [JsonProperty("Username")]
        public string Username = string.Empty;

        [JsonProperty("Password")]
        public string Password = string.Empty;

        [JsonProperty("Port")]
        public int Port;

        [JsonProperty("AutoConnect")]
        public bool AutoConnect;
    }

    public class CConfigValues
    {
        [JsonProperty("Path")]
        public CConfigPath Path = new();

        [JsonProperty("Ubuntu")]
        public CConfigUbuntu Ubuntu = new();
    }

    public static class ConfigUtils
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private const string m_Filename = "GFEditor.configs.json";

        [JsonProperty("Configs")]
        [SuppressMessage("Usage", "CA2211:Non-constant fields should not be visible", Justification = "<Pending>")]
        public static CConfigValues Configs = new();

        public static string GetGamePath() => Configs.Path.Game;
        public static string GetPath(string path) => Path.Combine(Configs.Path.Game, path);
        public static string GetObjectPath(string path, string obj) => Path.Combine(Path.Combine(Configs.Path.Game, path), obj);

        public static string GetRelativePath(string filePath) => Path.Combine(Directory.GetCurrentDirectory(), filePath);

        public static void Load()
        {
            try
            {
                if (File.Exists(m_Filename))
                    Configs = JsonConvert.DeserializeObject<CConfigValues>(File.ReadAllText(m_Filename));
                else
                    Configs = new CConfigValues();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to load configuration file: {0}", m_Filename);
                Configs = new CConfigValues(); // Reset to default if loading fails
            }
        }

        public static void Save()
        {
            using var file = File.CreateText(m_Filename);
            var serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };
            serializer.Serialize(file, Configs);
        }
    }
}