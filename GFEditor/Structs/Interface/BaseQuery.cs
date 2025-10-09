namespace GFEditor.Structs.Interface
{
    public abstract class BaseQuery<KEY, VALUE>(string queryName)
        where KEY: notnull
        where VALUE: class
    {
        protected Dictionary<KEY, VALUE> m_kMap = [];
        protected string m_queryName = queryName;
        protected Task? m_readFileTask = null;
        protected string m_fileName = string.Empty;
        protected string m_VerStr = string.Empty;
        protected long m_nVer = 0;
        protected long m_nColumnCount = 0;
        protected char m_Delimiter = '|';
        protected Action<List<List<string>>>? m_OnFileRead = null;

        public abstract bool Get(KEY index, out VALUE result);
        public abstract IOrderedEnumerable<VALUE> GetAllValues();
        protected abstract void OnFileRead(List<List<string>> listOfStrings);

        public string GetVersionStr() => m_VerStr;
        public long GetVersion() => m_nVer;
        public long GetColumnCount() => m_nColumnCount;
        public char GetDelimiter() => m_Delimiter;
        public bool IsLoaded() => m_readFileTask != null && m_readFileTask.IsCompleted && HasValues();
        public bool HasValues() => m_kMap.Count > 0;

        private void Read()
        {
            var strm = new InTextStream(m_fileName, true, true);
            if (!strm.IsOpen())
                return;

            m_Delimiter = strm.GetDelimiter();
            var headerString = strm.GetFirstLine();
            headerString = headerString[1..^1]; // Remove first | and last |.
            var splittedHeader = headerString.Split(m_Delimiter);
            m_VerStr = splittedHeader[0];
            m_nVer = m_VerStr.At(1, '.').AsLong();
            m_nColumnCount = splittedHeader[1].AsLong();

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
