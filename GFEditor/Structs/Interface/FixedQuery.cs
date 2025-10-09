namespace GFEditor.Structs.Interface
{
    public abstract class FixedQuery<KEY, VALUE>(string queryName, long columnCount, char delimiter = '|')
        where KEY : notnull
        where VALUE : class
    {
        protected Dictionary<KEY, VALUE> m_kMap = [];
        protected string m_queryName = queryName;
        protected Task? m_readFileTask = null;
        protected string m_fileName = string.Empty;
        protected long m_nColumnCount = columnCount;
        protected char m_Delimiter = delimiter;
        protected Action<List<List<string>>>? m_OnFileRead = null;

        public abstract bool Get(KEY index, out VALUE result);
        public abstract IOrderedEnumerable<VALUE> GetAllValues();
        protected abstract void OnFileRead(List<List<string>> listOfStrings);

        public long GetColumnCount() => m_nColumnCount;
        public char GetDelimiter() => m_Delimiter;
        public bool IsLoaded() => m_readFileTask != null && m_readFileTask.IsCompleted && HasValues();
        public bool HasValues() => m_kMap.Count > 0;

        private void Read()
        {
            var strm = new InTextStream(m_fileName, false, true);
            if (!strm.IsOpen())
                return;

            var splittedValues = strm.SplitByColumns(m_nColumnCount, m_Delimiter);
            if (splittedValues == null)
            {
                GuiNotify.Show(ImGuiToastType.Warning, m_queryName, "Failed to split ini data by columns, column count: {0}", m_nColumnCount);
                return;
            }

            m_OnFileRead?.Invoke(splittedValues);
        }

        public void ReadFile(string filePath)
        {
            m_fileName = filePath;
            m_OnFileRead = OnFileRead;
            m_readFileTask = Task.Run(Read);
        }
    }
}
