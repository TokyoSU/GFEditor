namespace GFEditor.Utils
{
    public class InTextStream
    {
        private string m_Text = string.Empty;
        private string m_FirstLine = string.Empty;
        private bool m_IsOpen = false;

        public InTextStream() {}
        public InTextStream(string filePath, bool isChineseFile = false) => LoadFile(filePath, isChineseFile);

        public void LoadFile(string filePath, bool isChineseFile = false)
        {
            try
            {
                // Read file, using chinese as encoding if required.
                var encoding = isChineseFile ? Encoding.GetEncoding("Big5") : Encoding.UTF8;
                m_FirstLine = File.ReadLines(filePath, encoding).First();
                m_Text = File.ReadAllText(filePath, encoding);

                // Remove first line in the text, since we get it manually !
                // The first line is usually the header.
                if (!string.IsNullOrEmpty(m_Text) && !string.IsNullOrEmpty(m_FirstLine))
                    m_Text = m_Text.Replace(m_FirstLine, string.Empty);
                
                m_IsOpen = true;
            }
            catch (Exception ex)
            {
                ImGuiNotify.Insert(new ImGuiToast(ImGuiToastType.Error, "Reading ini file", 3000, ex.Message));
                m_IsOpen = false;
            }
        }

        public bool IsOpen() => m_IsOpen;
        public string GetText() => m_Text;
        public string GetFirstLine() => m_FirstLine;

        public char GetDelimiter() {
            if (string.IsNullOrEmpty(m_FirstLine)) return '|';
            return m_FirstLine[0];
        }

        /// <summary>
        /// First is the line index, then the columns list.
        /// </summary>
        public List<List<string>> SplitByColumns(long columnCount, char delimiter)
        {
            if (string.IsNullOrEmpty(m_Text)) return []; // Return empty array.
            var splittedValues = m_Text.Split(delimiter);
            var columns = new List<List<string>>();
            for (long index = 0; index < splittedValues.Length - columnCount; index += columnCount)
            {
                var strings = new List<string>();
                for (long i = 0; i < columnCount; i++)
                    strings.Add(splittedValues[index + i]);
                columns.Add(strings);
            }
            return columns;
        }
    }
}
