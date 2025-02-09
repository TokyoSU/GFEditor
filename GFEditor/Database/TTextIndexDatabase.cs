﻿namespace GFEditor.Database
{
    public static class TTextIndexDatabase
    {
        private static List<TTextIndex>? m_Database = [];

        public static void Load()
        {
            m_Database?.Clear(); // Clear previous database if we try to load again.

            if (!File.Exists(Constants.AssetJTTextIndex))
            {
                LoadIni();
            }
            else
            {
                m_Database = JsonConvert.DeserializeObject<List<TTextIndex>>(File.ReadAllText(Constants.AssetJTTextIndex, Encoding.UTF8));
            }
        }

        private static void LoadIni()
        {
            var wholeFile = File.ReadAllText(Constants.AssetOrigTTextIndex, StringConverter.GetChinese());
            var lines = wholeFile.Split('|').ToList();
            for (int index = 0; index < lines.Count - 1; index += 2)
            {
                m_Database?.Add(new TTextIndex()
                {
                    Index = lines.GetInt(index + 0),
                    Value = lines[index + 1]
                });
            }
            m_Database?.Sort();
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
            using (var fileStream = new FileStream(Constants.AssetTTextIndex, FileMode.Create))
            using (var writer = new StreamWriter(fileStream, StringConverter.GetChinese()))
                writer.Write(stringBuilder.ToString());

            if (m_Database != null) SaveHelper.SaveJson(Constants.AssetJTTextIndex, m_Database);
        }

        public static TTextIndex? GetByIndex(int index)
        {
            if (index < 1)
            {
                Console.WriteLine($"Failed to find index: {index}, Out of range, Min: {DATA_GetMinIndex()}, Max: {DATA_GetMaxIndex()}");
                return null; // NOTE: Index start at 1 not 0 !
            }
            if (m_Database == null)
            {
                Console.WriteLine($"Failed to find index: {index} in the TTextIndex::Index database, database is null, was it loaded ?");
                return null;
            }
            var result = m_Database.Find(e => e.Index == index);
            if (result != null) return result;
            Console.WriteLine($"Failed to find index: {index} in the TTextIndex::Index database !");
            return null;
        }

        public static TTextIndex? GetByStringInText(string text)
        {
            if (m_Database == null)
            {
                Console.WriteLine($"Failed to find string: {text} in the TTextIndex::Value database, database is null, was it loaded ?");
                return null;
            }
            for (int i = 0; i < m_Database.Count; i++)
            {
                var value = m_Database[i];
                if (value.Value.Contains(text))
                    return value;
            }
            Console.WriteLine($"Failed to find: {text} in the TTextIndex::Text database !");
            return null;
        }

        private static int DATA_GetMinIndex()
        {
            if (m_Database == null)
            {
                Console.WriteLine("Failed to get minimum index of TextIndex database, database is null, was it loaded ?");
                return 0;
            }
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
            if (m_Database == null)
            {
                Console.WriteLine("Failed to get minimum index of TextIndex database, database is null, was it loaded ?");
                return 0;
            }
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
