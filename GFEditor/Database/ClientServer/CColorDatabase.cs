namespace GFEditor.Database.ClientServer
{
    public class CColorDatabaseJson
    {
        [JsonProperty]
        public List<StringColor> Colors = [];
        [JsonProperty]
        public int Version;
    }

    public static class CColorDatabase
    {
        private static readonly Logger m_Log = LogManager.GetLogger("C_Color");
        private static readonly string m_FilePath = Constants.Parameters.ClientPath + "\\Color.ini";
        private static CColorDatabaseJson m_Database = new();
        private static UI_Loader? m_Loader = null;

        public static void SetLoader(UI_Loader? loader)
        {
            m_Loader = loader;
            m_Loader?.IncreaseClassMax();
        }

        public static void Load()
        {
            m_Database?.Colors?.Clear(); // Clear previous database if we try to load again.
            m_Loader?.SetClassProgress("C_Color");

            if (File.Exists(Constants.AssetJCColor))
            {
                m_Loader?.SetCurProgress("Loading C_Color from json.", 0);
                m_Database = JsonConvert.DeserializeObject<CColorDatabaseJson>(File.ReadAllText(Constants.AssetJCColor, Encoding.UTF8));
                m_Loader?.SetCurProgress("Loaded C_Color from json.", 100);
            }
            else
            {
                LoadIni();
            }
        }

        private static void LoadIni()
        {
            var wholeFile = File.ReadAllLines(m_FilePath, StringConverter.GetChinese());

            m_Loader?.SetCurProgress("Loading C_Color.", 0);
            m_Loader?.EnableItem(true);
            m_Loader?.SetItemProgress(string.Empty, 0);
            m_Loader?.SetItemMaxProgress(wholeFile.Length - 1);

            // Get file version at line 1 second value.
            if (m_Database != null)
                m_Database.Version = int.Parse(wholeFile[1].Split('=')[1]);

            // Starting from 3, we skip version header.
            for (int index = 3; index < wholeFile.Length; index++)
            {
                // First we split by '='
                // Then we split second value by ','
                var table = wholeFile[index].Split('=');
                var values = table[1].Split(',').ToList();
                var item = new StringColor()
                {
                    Alpha = 255,
                    Red = values.GetInt(0),
                    Green = values.GetInt(1),
                    Blue = values.GetInt(2),
                    IndexInGame = values.GetInt(3, "-"),
                    Color = SColor.FromArgb(255, values.GetInt(0), values.GetInt(1), values.GetInt(2))
                };

                if (m_Database != null && m_Database.Colors != null)
                    m_Database.Colors.Add(item);

                m_Log.Info($"TableID: {table[0]}");
                m_Loader?.SetItemProgress($"Loading index: {table[0]}", index);
            }

            m_Loader?.EnableItem(false);
            m_Loader?.SetCurProgress("Loaded C_Color.", 100);
        }

        public static void Save()
        {
            // Save new ini file:
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("[INFO]");
            stringBuilder.AppendLine($"Version={m_Database?.Version}");
            stringBuilder.AppendLine("[Table]");
            if (m_Database != null && m_Database.Colors != null)
            {
                for (int index = 0; index < m_Database.Colors.Count; index++)
                {
                    stringBuilder.AppendLine($"{index}={m_Database.Colors[index].ToString()}");
                }
            }
            using (var fileStream = new FileStream(m_FilePath, FileMode.Create))
            using (var writer = new StreamWriter(fileStream, StringConverter.GetChinese()))
                writer.Write(stringBuilder.ToString());

            // Save json.
            if (m_Database != null)
                SaveHelper.SaveJson(Constants.AssetJCColor, m_Database);
        }

        public static StringColor GetByIndex(int index)
        {
            if (m_Database == null) throw new AccessViolationException($"Failed to find color at index: {index}, was it loaded ?");
            if (m_Database.Colors == null) throw new AccessViolationException($"Failed to find color at index: {index}, color list is null, was it loaded ?");

            for (int i = 0; i < m_Database.Colors.Count; i++)
            {
                var value = m_Database.Colors[i];
                if (value.IndexInGame == index)
                    return value;
            }

            m_Log.Warn($"Failed to get index: {index}, setting default index: 7, min: 1, max:{m_Database.Colors.Count}.");
            return m_Database.Colors[7];
        }
    }
}
