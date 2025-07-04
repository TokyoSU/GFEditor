﻿namespace GFEditor.Utils
{
    public class CConfigPath
    {
        [JsonProperty]
        public string Client = string.Empty;

        [JsonProperty]
        public string Server = string.Empty;

        [JsonProperty]
        public string Translate = string.Empty;

        [JsonProperty]
        public string Icons = string.Empty;
    }

    public class CConfigUbuntu
    {
        [JsonProperty]
        public string Host = string.Empty;

        [JsonProperty]
        public string HostKey = string.Empty;

        [JsonProperty]
        public string Username = string.Empty;

        [JsonProperty]
        public string Password = string.Empty;

        [JsonProperty]
        public int Port;

        [JsonProperty]
        public bool AutoConnect;
    }

    public class CConfigValues
    {
        [JsonProperty]
        public CConfigPath Path = new();

        [JsonProperty]
        public CConfigUbuntu Ubuntu = new();
    }

    public static class ConfigUtils
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private const string m_Filename = "GFEditor.configs.json";

        [JsonProperty]
        public static CConfigValues Configs = new();

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