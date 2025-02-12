using GFEditor.Structs.Translate;

namespace GFEditor.Database.Translate
{
    public static class TTextIndexDatabase
    {
        //private static readonly Logger m_Log = LogManager.GetCurrentClassLogger();
        private static readonly string FilePath = Constants.Parameters.TranslatePath + "\\T_TextIndex.ini";
        private static List<TTextIndex>? m_Database = [];
        private static UI_Loader? m_Loader = null;

        public static void SetLoader(UI_Loader? loader)
        {
            m_Loader = loader;
            m_Loader?.IncreaseClassMax();
        }

        public static void Load()
        {
            m_Database?.Clear(); // Clear previous database if we try to load again.
            m_Loader?.SetClassProgress("T_TextIndex");

            if (File.Exists(Constants.AssetJTTextIndex))
            {
                m_Loader?.SetCurProgress("Loading T_TextIndex from json.", 0);
                m_Database = JsonConvert.DeserializeObject<List<TTextIndex>>(File.ReadAllText(Constants.AssetJTTextIndex, Encoding.UTF8));
                m_Loader?.SetCurProgress("Loaded T_TextIndex from json.", 100);
            }
            else
            {
                LoadIni();
            }
        }

        private static void LoadIni()
        {
            var wholeFile = File.ReadAllText(FilePath, StringConverter.GetChinese());
            var lines = wholeFile.Split('|').ToList();
            m_Loader?.SetCurProgress("Loading T_TextIndex.", 0);

            m_Loader?.EnableItem(true);
            m_Loader?.SetItemProgress(string.Empty, 0);
            m_Loader?.SetItemMaxProgress(lines.Count - 1);
            for (int index = 0; index < lines.Count - 1; index += 2)
            {
                var text = new TTextIndex()
                {
                    Index = lines.GetInt(index + 0),
                    Value = lines[index + 1]
                };
                m_Loader?.SetItemProgress("Loading index: " + text.Index, index);
                m_Database?.Add(text);
            }
            m_Database?.Sort();
            m_Loader?.EnableItem(false);

            m_Loader?.SetCurProgress("Loaded T_TextIndex.", 100);
        }

        public static void Save()
        {
            // Save new ini file:
            var stringBuilder = new StringBuilder();
            if (m_Database != null)
            {
                foreach (var item in m_Database)
                {
                    if (item != null)
                        stringBuilder.AppendLine(item.ToString());
                }
            }

            using (var fileStream = new FileStream(FilePath, FileMode.Create))
            using (var writer = new StreamWriter(fileStream, StringConverter.GetChinese()))
                writer.Write(stringBuilder.ToString());
            if (m_Database != null)
                SaveHelper.SaveJson(Constants.AssetJTTextIndex, m_Database);
        }

        public static TTextIndex? GetByIndex(int index)
        {
            if (index < 1) throw new ArgumentOutOfRangeException($"Failed to find index: {index}, Out of range, Min: {DATA_GetMinIndex()}, Max: {DATA_GetMaxIndex()}");
            if (m_Database == null) throw new AccessViolationException($"Failed to find index: {index} in the TTextIndex::Index database, database is null, was it loaded ?");

            var result = m_Database.Find(e => e.Index == index);
            if (result != null) return result;

            throw new InvalidOperationException($"Failed to find index: {index} in the TTextIndex::Index database !");
        }

        public static TTextIndex? GetByStringInText(string text)
        {
            if (m_Database == null) throw new AccessViolationException($"Failed to find string: {text} in the TTextIndex::Value database, database is null, was it loaded ?");
            for (int i = 0; i < m_Database.Count; i++)
            {
                var value = m_Database[i];
                if (value.Value.Contains(text))
                    return value;
            }
            throw new InvalidOperationException($"Failed to find: {text} in the TTextIndex::Text database !");
        }

        private static int DATA_GetMinIndex()
        {
            if (m_Database == null) throw new AccessViolationException("Failed to get minimum index of TextIndex database, database is null, was it loaded ?");
            int min = int.MaxValue;
            m_Database.ForEach(e =>
            {
                if (min > e.Index)
                    min = e.Index;
            });
            return min;
        }

        private static int DATA_GetMaxIndex()
        {
            if (m_Database == null) throw new AccessViolationException("Failed to get maximum index of TextIndex database, database is null, was it loaded ?");
            int max = 0;
            m_Database.ForEach(e =>
            {
                if (max < e.Index)
                    max = e.Index;
            });
            return max;
        }
    }
}
