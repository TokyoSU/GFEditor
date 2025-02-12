namespace GFEditor.Database.Translate
{
    public static class TItemDatabase
    {
        private static readonly Logger m_Log = LogManager.GetCurrentClassLogger();
        private static readonly string m_FilePath = Constants.Parameters.TranslatePath + "\\T_Item.ini";
        private static List<TItem>? m_Database = [];
        private static UI_Loader? m_Loader = null;

        public static void SetLoader(UI_Loader? loader)
        {
            m_Loader = loader;
            m_Loader?.IncreaseClassMax();
        }

        public static void Load()
        {
            m_Database?.Clear(); // Clear previous database if we try to load again.
            m_Loader?.SetClassProgress("T_Item");

            if (File.Exists(Constants.AssetJTItem))
            {
                m_Loader?.SetCurProgress("Loading T_Item from json.", 0);
                m_Database = JsonConvert.DeserializeObject<List<TItem>>(File.ReadAllText(Constants.AssetJTItem, Encoding.UTF8));
                m_Loader?.SetCurProgress("Loaded T_Item from json.", 100);
            }
            else
            {
                LoadIni();
            }
        }

        private static void LoadIni()
        {
            var wholeFile = File.ReadAllText(m_FilePath, StringConverter.GetChinese());
            var lines = wholeFile.Split('|').ToList();
            m_Loader?.SetCurProgress("Loading T_Item.", 0);

            m_Loader?.EnableItem(true);
            m_Loader?.SetItemProgress(string.Empty, 0);
            m_Loader?.SetItemMaxProgress(lines.Count - 1);
            for (int index = 0; index < lines.Count - 1; index += 2)
            {
                var text = new TItem()
                {
                    Index = lines.GetInt(index + 0),
                    Name = lines[index + 1],
                    Description = lines[index + 2]
                };
                m_Loader?.SetItemProgress("Loading index: " + text.Index, index);
                m_Database?.Add(text);
            }
            m_Database?.Sort();
            m_Loader?.EnableItem(false);

            m_Loader?.SetCurProgress("Loaded T_Item.", 100);
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

            using (var fileStream = new FileStream(m_FilePath, FileMode.Create))
            using (var writer = new StreamWriter(fileStream, StringConverter.GetChinese()))
                writer.Write(stringBuilder.ToString());
            if (m_Database != null)
                SaveHelper.SaveJson(Constants.AssetJTItem, m_Database);
        }

        public static TItem? GetByIndex(int index)
        {
            if (index < 1) throw new ArgumentOutOfRangeException($"Failed to find index: {index}, Out of range, Min: {DATA_GetMinIndex()}, Max: {DATA_GetMaxIndex()}");
            if (m_Database == null) throw new AccessViolationException($"Failed to find index: {index} in the TItem::Index database, database is null, was it loaded ?");

            var result = m_Database.Find(e => e.Index == index);
            if (result != null) return result;

            m_Log.Warn($"Failed to find index: {index} in the TItem::Index database !");
            return null;
        }

        public static TItem? GetByStringInText(string text)
        {
            if (m_Database == null) throw new AccessViolationException($"Failed to find string: {text} in the TItem::Name database, database is null, was it loaded ?");
            for (int i = 0; i < m_Database.Count; i++)
            {
                var value = m_Database[i];
                if (value.Name.Contains(text))
                    return value;
            }
            throw new InvalidOperationException($"Failed to find: {text} in the TItem::Name database !");
        }

        private static int DATA_GetMinIndex()
        {
            if (m_Database == null) throw new AccessViolationException("Failed to get minimum index of TItem database, database is null, was it loaded ?");
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
            if (m_Database == null) throw new AccessViolationException("Failed to get maximum index of TItem database, database is null, was it loaded ?");
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
